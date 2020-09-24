namespace NetworkMapCreator
{
    partial class ExceptionInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnRestartAndSend = new System.Windows.Forms.Button();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oooooops. The program crashed.";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "You can help fixing the error by sending error information to the developer. No p" +
    "ersonal data will be sent.";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(317, 331);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(200, 331);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(111, 23);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Restart Application";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnRestartAndSend
            // 
            this.btnRestartAndSend.Location = new System.Drawing.Point(95, 331);
            this.btnRestartAndSend.Name = "btnRestartAndSend";
            this.btnRestartAndSend.Size = new System.Drawing.Size(99, 23);
            this.btnRestartAndSend.TabIndex = 5;
            this.btnRestartAndSend.Text = "Send Information";
            this.btnRestartAndSend.UseVisualStyleBackColor = true;
            this.btnRestartAndSend.Click += new System.EventHandler(this.btnRestartAndSend_Click);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(16, 75);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.Size = new System.Drawing.Size(376, 138);
            this.infoTextBox.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(291, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "What was the last thing you did? This could help finding the error:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 241);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(376, 84);
            this.textBox1.TabIndex = 9;
            // 
            // ExceptionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 366);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRestartAndSend);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionInfo";
            this.Text = "NetworX Crash Information";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnRestartAndSend;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}