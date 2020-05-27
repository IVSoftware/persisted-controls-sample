using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static persisted_controls_sample.Form1;

namespace persisted_controls_sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Get a local AppData folder specific to this application.
            var assemblyName =
                    Assembly
                    .GetExecutingAssembly()
                    .FullName.Split(',')[0];
            FileDataStoreFolder =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData) + @"\" +
                    assemblyName + @"\";
            Directory
                .CreateDirectory(FileDataStoreFolder);
        }
        // App-specific folder path to store data.
        public static string FileDataStoreFolder { get; private set; } 
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            IterateControls(this);
        }
        void IterateControls(Control control)
        {
            if (control is IPersistCommon)
            {
                ((IPersistCommon)control).Load();
            }
            foreach (Control child in control.Controls)
            {
                IterateControls(child);
            }
        }
    }

    interface IPersistCommon // All our controls must implement this
    {
        SaveType SaveType { get; set; } // Possible ways to save
        void Save();                    // Save in the manner selected by SaveType
        void Load();                    // Load in the manner selected by SaveType
    }
    class PersistTextBox
        : TextBox           // Inherit the normal textbox
        , IPersistCommon    // But MUST implement 'SaveType' and 'Save()'
    {
        [Browsable(true)]
        public SaveType SaveType { get; set; } = SaveType.AppProperties;

        public void Save()
        {
            switch (SaveType)
            {
                case SaveType.AppProperties:
                    Properties.Settings.Default[Name] = Text;
                    Properties.Settings.Default.Save();
                    break;
                case SaveType.FileDataStore:
                case SaveType.FileDataStoreJSON:
                case SaveType.WindowsRegisty:
                case SaveType.SQLite:
                default:
                    throw new NotImplementedException("To do!");
            }
            // Select all text in a thread-friendly manner.
            BeginInvoke((MethodInvoker)delegate { SelectAll(); });
        }
        public void Load()
        {
            if (!DesignMode)
            {
                switch (SaveType)
                {
                    case SaveType.AppProperties:
                        Text = (string)Properties.Settings.Default[Name];
                        break;
                    case SaveType.FileDataStore:
                    case SaveType.FileDataStoreJSON:
                    case SaveType.WindowsRegisty:
                    case SaveType.SQLite:
                    default:
                        throw new NotImplementedException("To do!");
                }
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Save(); // If user leaves the control
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyData)
            {
                case Keys.Enter: // Pressed the Enter key
                    Save();
                    break;
            }
        }
    }

    class PersistRichTextBox
        : RichTextBox           // Inherit the standard version
        , IPersistCommon        // But MUST implement 'SaveType' and 'Save()'
        , ISupportInitialize    //
    {
        public PersistRichTextBox()
        {
            WDT = new Timer();
            WDT.Interval = 1000;
            WDT.Tick += WDT_Tick;
        }
        string FileName=> FileDataStoreFolder + Name + ".rtf";
        public SaveType SaveType { get; set; } = SaveType.AppProperties;

        public void Save()
        {
            switch (SaveType)
            {
                case SaveType.AppProperties:
                    Properties.Settings.Default[Name] = Rtf;
                    Properties.Settings.Default.Save();
                    break;
                case SaveType.File:
                    File.WriteAllText(FileName, Rtf);
                    break;
                case SaveType.FileDataStore:
                case SaveType.FileDataStoreJSON:
                case SaveType.WindowsRegisty:
                case SaveType.SQLite:
                default:
                    throw new NotImplementedException("To do!");
            }
            Debug.WriteLine("Saved");
        }
        public void Load()
        {
            if (!DesignMode)
            {
                BeginInit();
                switch (SaveType)
                {
                    case SaveType.AppProperties:
                        // This would be a concern if the RTF for example
                        // holds an image file making it gigantic.
                        Rtf = (string)Properties.Settings.Default[Name];
                        break;
                    case SaveType.File:
                        if(File.Exists(FileName))
                        {
                            Rtf = File.ReadAllText(FileName);
                        }
                        break;
                    case SaveType.FileDataStore:
                    case SaveType.FileDataStoreJSON:
                    case SaveType.WindowsRegisty:
                    case SaveType.SQLite:
                    default:
                        throw new NotImplementedException("To do!");
                }
                EndInit();
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            // This will pick up Paste operations, too.
            base.OnTextChanged(e);
            if(!_initializing)
            {
                // Restarts a short inactivity WDT and autosaves when done.
                WDT.Stop();
                WDT.Start(); 
            }
        }
        Timer WDT;

        // Timeout has expired since the last change to the document.
        private void WDT_Tick(object sender, EventArgs e)
        {
            WDT.Stop();
            Save();
        }

        public void BeginInit()
        {
            _initializing = true;
        }

        public void EndInit()
        {
            _initializing = false;
        }
        bool _initializing = false;
    }

    class PersistTabControl
        : TabControl
        , IPersistCommon
    {
        public SaveType SaveType { get; set; }

        public void Save()
        {
            switch (SaveType)
            {
                case SaveType.AppProperties:
                    Properties.Settings.Default[Name] = SelectedIndex;
                    Properties.Settings.Default.Save();
                    break;
                case SaveType.FileDataStore:
                case SaveType.FileDataStoreJSON:
                case SaveType.WindowsRegisty:
                case SaveType.SQLite:
                default:
                    throw new NotImplementedException("To do!");
            }
        }
        public void Load()
        {
            if(!DesignMode)
            {
                switch (SaveType)
                {
                    case SaveType.AppProperties:
                        BeginInvoke((MethodInvoker)delegate
                        {
                            int tabIndex = (int)Properties.Settings.Default[Name];
                            if (tabIndex < TabCount)
                            {
                                SelectedIndex = tabIndex;
                            }
                        });
                        break;
                    case SaveType.FileDataStore:
                    case SaveType.FileDataStoreJSON:
                    case SaveType.WindowsRegisty:
                    case SaveType.SQLite:
                    default:
                        throw new NotImplementedException("To do!");
                }
            }
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Save(); // Save when index chaged
        }
    }

    enum SaveType
    {
        AppProperties,      // Like the textbox code shown in you question
        WindowsRegisty,     // A traditional method, but Windows Only
        File,               // For example, an RTF file in Local AppData (cross-platform)
        FileDataStore,      // Mobile cross-platform
        FileDataStoreJSON,  // Serialize the object's content AND SETTINGS (like 'enabled', etc.)
        SQLite              // Mobile platforms also available
    }
}
