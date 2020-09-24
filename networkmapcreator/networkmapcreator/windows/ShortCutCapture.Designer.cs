namespace NetworkMapCreator
{
    partial class ShortCutCapture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortCutCapture));
            this.label1 = new System.Windows.Forms.Label();
            this.ShortcutDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press any shortcut, Escape to cancel and Backspace to delete";
            // 
            // ShortcutDisplay
            // 
            this.ShortcutDisplay.Location = new System.Drawing.Point(15, 41);
            this.ShortcutDisplay.Name = "ShortcutDisplay";
            this.ShortcutDisplay.Size = new System.Drawing.Size(389, 21);
            this.ShortcutDisplay.TabIndex = 1;
            this.ShortcutDisplay.Text = "None";
            this.ShortcutDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShortCutCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 86);
            this.Controls.Add(this.ShortcutDisplay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShortCutCapture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shortcut";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShortCutCapture_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShortCutCapture_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ShortcutDisplay;
    }
}