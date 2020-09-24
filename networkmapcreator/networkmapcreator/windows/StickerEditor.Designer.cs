namespace NetworkMapCreator
{
    partial class StickerEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StickerEditor));
            this.buttonImageBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RotationNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.RotationTrackBar = new System.Windows.Forms.TrackBar();
            this.WidthNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HeightNumber = new System.Windows.Forms.NumericUpDown();
            this.AspectToggle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.RotationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImageBrowse
            // 
            this.buttonImageBrowse.Location = new System.Drawing.Point(174, 12);
            this.buttonImageBrowse.Name = "buttonImageBrowse";
            this.buttonImageBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonImageBrowse.TabIndex = 0;
            this.buttonImageBrowse.Text = "Browse...";
            this.buttonImageBrowse.UseVisualStyleBackColor = true;
            this.buttonImageBrowse.Click += new System.EventHandler(this.buttonImageBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image";
            // 
            // RotationNumber
            // 
            this.RotationNumber.Location = new System.Drawing.Point(128, 41);
            this.RotationNumber.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RotationNumber.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.RotationNumber.Name = "RotationNumber";
            this.RotationNumber.Size = new System.Drawing.Size(120, 20);
            this.RotationNumber.TabIndex = 9;
            this.RotationNumber.ValueChanged += new System.EventHandler(this.RotationNumber_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Rotation";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(174, 210);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(93, 210);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // RotationTrackBar
            // 
            this.RotationTrackBar.Location = new System.Drawing.Point(15, 67);
            this.RotationTrackBar.Maximum = 180;
            this.RotationTrackBar.Minimum = -180;
            this.RotationTrackBar.Name = "RotationTrackBar";
            this.RotationTrackBar.Size = new System.Drawing.Size(234, 45);
            this.RotationTrackBar.TabIndex = 7;
            this.RotationTrackBar.ValueChanged += new System.EventHandler(this.RotationTrackBar_ValueChanged);
            // 
            // WidthNumber
            // 
            this.WidthNumber.Location = new System.Drawing.Point(124, 113);
            this.WidthNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.WidthNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthNumber.Name = "WidthNumber";
            this.WidthNumber.Size = new System.Drawing.Size(120, 20);
            this.WidthNumber.TabIndex = 12;
            this.WidthNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthNumber.ValueChanged += new System.EventHandler(this.WidthNumber_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Height";
            // 
            // HeightNumber
            // 
            this.HeightNumber.Location = new System.Drawing.Point(124, 139);
            this.HeightNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HeightNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightNumber.Name = "HeightNumber";
            this.HeightNumber.Size = new System.Drawing.Size(120, 20);
            this.HeightNumber.TabIndex = 14;
            this.HeightNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightNumber.ValueChanged += new System.EventHandler(this.HeightNumber_ValueChanged);
            // 
            // AspectToggle
            // 
            this.AspectToggle.AutoSize = true;
            this.AspectToggle.Checked = true;
            this.AspectToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AspectToggle.Location = new System.Drawing.Point(135, 165);
            this.AspectToggle.Name = "AspectToggle";
            this.AspectToggle.Size = new System.Drawing.Size(109, 17);
            this.AspectToggle.TabIndex = 16;
            this.AspectToggle.Text = "Keep aspect ratio";
            this.AspectToggle.UseVisualStyleBackColor = true;
            // 
            // StickerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 242);
            this.Controls.Add(this.AspectToggle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HeightNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WidthNumber);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.RotationNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RotationTrackBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonImageBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StickerEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StickerEditor";
            ((System.ComponentModel.ISupportInitialize)(this.RotationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImageBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown RotationNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TrackBar RotationTrackBar;
        private System.Windows.Forms.NumericUpDown WidthNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown HeightNumber;
        private System.Windows.Forms.CheckBox AspectToggle;
    }
}