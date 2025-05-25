namespace NotesHelper
{
    partial class frmMainNotesHelper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStartStop = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // btnStartStop
            // 
            btnStartStop.Location = new Point(53, 53);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(158, 53);
            btnStartStop.TabIndex = 0;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(53, 112);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1402, 570);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // frmMainNotesHelper
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1467, 694);
            Controls.Add(richTextBox1);
            Controls.Add(btnStartStop);
            Name = "frmMainNotesHelper";
            Text = "NotesHelper";
            WindowState = FormWindowState.Maximized;
            Load += frmMainNotesHelper_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartStop;
        private RichTextBox richTextBox1;
    }
}
