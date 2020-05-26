using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace persisted_controls_sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            foreach(var control in Controls)
            {
                if(control is IPersistCommon)
                {
                    ((IPersistCommon)control).Load();
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
            public SaveType SaveType { get; set; } = SaveType.AppProperties;

            public void Save()
            {
                switch (SaveType)
                {
                    case SaveType.AppProperties:
                        Properties.Settings.Default["TextBoxValue"] = Text;
                        Properties.Settings.Default.Save();
                        break;
                    case SaveType.WindowsRegisty:
                    case SaveType.FileDataStore:
                    case SaveType.SQLite:
                        throw new NotImplementedException("To do!");
                }
                // Select all text in a thread-friendly manner.
                BeginInvoke((MethodInvoker)delegate { SelectAll(); });
            }
            public void Load()
            {
                switch (SaveType)
                {
                    case SaveType.AppProperties:
                        Text = (string)Properties.Settings.Default["TextBoxValue"];
                        break;
                    case SaveType.WindowsRegisty:
                    case SaveType.FileDataStore:
                    case SaveType.SQLite:
                        throw new NotImplementedException("To do!");
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


        enum SaveType
        {
            AppProperties,  // Like the textbox code shown in you question
            WindowsRegisty, // A traditional method, but Windows Only
            FileDataStore,  // Mobile platforms available
            SQLite          // Mobile platforms also available
        }
    }
}
