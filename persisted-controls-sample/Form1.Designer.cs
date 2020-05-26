namespace persisted_controls_sample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.persistTextBox1 = new persisted_controls_sample.PersistTextBox();
            this.persistTabControl1 = new persisted_controls_sample.PersistTabControl();
            this.tabPageRTF1 = new System.Windows.Forms.TabPage();
            this.tabPageRTF2 = new System.Windows.Forms.TabPage();
            this.persistRichTextBox1 = new persisted_controls_sample.PersistRichTextBox();
            this.persistRichTextBox2 = new persisted_controls_sample.PersistRichTextBox();
            this.persistTabControl1.SuspendLayout();
            this.tabPageRTF1.SuspendLayout();
            this.tabPageRTF2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.persistTextBox1.Location = new System.Drawing.Point(30, 23);
            this.persistTextBox1.Name = "persistTextBox1";
            this.persistTextBox1.SaveType = persisted_controls_sample.SaveType.AppProperties;
            this.persistTextBox1.Size = new System.Drawing.Size(100, 20);
            this.persistTextBox1.TabIndex = 0;
            // 
            // persistTabControl1
            // 
            this.persistTabControl1.Controls.Add(this.tabPageRTF1);
            this.persistTabControl1.Controls.Add(this.tabPageRTF2);
            this.persistTabControl1.Location = new System.Drawing.Point(30, 73);
            this.persistTabControl1.Name = "persistTabControl1";
            this.persistTabControl1.SaveType = persisted_controls_sample.SaveType.AppProperties;
            this.persistTabControl1.SelectedIndex = 0;
            this.persistTabControl1.Size = new System.Drawing.Size(200, 100);
            this.persistTabControl1.TabIndex = 2;
            // 
            // tabPageRTF1
            // 
            this.tabPageRTF1.Controls.Add(this.persistRichTextBox1);
            this.tabPageRTF1.Location = new System.Drawing.Point(4, 22);
            this.tabPageRTF1.Name = "tabPageRTF1";
            this.tabPageRTF1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRTF1.Size = new System.Drawing.Size(192, 74);
            this.tabPageRTF1.TabIndex = 0;
            this.tabPageRTF1.Text = "RTF1";
            this.tabPageRTF1.UseVisualStyleBackColor = true;
            // 
            // tabPageRTF2
            // 
            this.tabPageRTF2.Controls.Add(this.persistRichTextBox2);
            this.tabPageRTF2.Location = new System.Drawing.Point(4, 22);
            this.tabPageRTF2.Name = "tabPageRTF2";
            this.tabPageRTF2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRTF2.Size = new System.Drawing.Size(192, 74);
            this.tabPageRTF2.TabIndex = 1;
            this.tabPageRTF2.Text = "RTF2";
            this.tabPageRTF2.UseVisualStyleBackColor = true;
            // 
            // persistRichTextBox1
            // 
            this.persistRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.persistRichTextBox1.Location = new System.Drawing.Point(3, 3);
            this.persistRichTextBox1.Name = "persistRichTextBox1";
            this.persistRichTextBox1.SaveType = persisted_controls_sample.SaveType.AppProperties;
            this.persistRichTextBox1.Size = new System.Drawing.Size(186, 68);
            this.persistRichTextBox1.TabIndex = 3;
            this.persistRichTextBox1.Text = "";
            // 
            // persistRichTextBox2
            // 
            this.persistRichTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.persistRichTextBox2.Location = new System.Drawing.Point(3, 3);
            this.persistRichTextBox2.Name = "persistRichTextBox2";
            this.persistRichTextBox2.SaveType = persisted_controls_sample.SaveType.AppProperties;
            this.persistRichTextBox2.Size = new System.Drawing.Size(186, 68);
            this.persistRichTextBox2.TabIndex = 0;
            this.persistRichTextBox2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 198);
            this.Controls.Add(this.persistTabControl1);
            this.Controls.Add(this.persistTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.persistTabControl1.ResumeLayout(false);
            this.tabPageRTF1.ResumeLayout(false);
            this.tabPageRTF2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersistTextBox persistTextBox1;
        private PersistTabControl persistTabControl1;
        private System.Windows.Forms.TabPage tabPageRTF1;
        private PersistRichTextBox persistRichTextBox1;
        private System.Windows.Forms.TabPage tabPageRTF2;
        private PersistRichTextBox persistRichTextBox2;
    }
}

