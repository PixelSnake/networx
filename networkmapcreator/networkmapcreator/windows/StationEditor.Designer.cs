namespace NetworkMapCreator
{
    partial class StationEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StationEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.RotationTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.RotationNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoAnkerRB = new System.Windows.Forms.RadioButton();
            this.rdoAnkerMB = new System.Windows.Forms.RadioButton();
            this.rdoAnkerLB = new System.Windows.Forms.RadioButton();
            this.rdoAnkerLM = new System.Windows.Forms.RadioButton();
            this.rdoAnkerMM = new System.Windows.Forms.RadioButton();
            this.rdoAnkerRM = new System.Windows.Forms.RadioButton();
            this.rdoAnkerLU = new System.Windows.Forms.RadioButton();
            this.rdoAnkerMU = new System.Windows.Forms.RadioButton();
            this.rdoAnkerRU = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new NetworkMapCreator.StationLabelOffsetEditorPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.comboProminence = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(128, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(174, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RotationTrackBar
            // 
            this.RotationTrackBar.Location = new System.Drawing.Point(15, 85);
            this.RotationTrackBar.Maximum = 180;
            this.RotationTrackBar.Minimum = -180;
            this.RotationTrackBar.Name = "RotationTrackBar";
            this.RotationTrackBar.Size = new System.Drawing.Size(234, 45);
            this.RotationTrackBar.TabIndex = 4;
            this.RotationTrackBar.ValueChanged += new System.EventHandler(this.RotationTrackBar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rotation";
            // 
            // RotationNumber
            // 
            this.RotationNumber.Location = new System.Drawing.Point(128, 59);
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
            this.RotationNumber.TabIndex = 6;
            this.RotationNumber.ValueChanged += new System.EventHandler(this.RotationNumber_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Look at the editor window for a preview";
            // 
            // rdoAnkerRB
            // 
            this.rdoAnkerRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerRB.Location = new System.Drawing.Point(174, 303);
            this.rdoAnkerRB.Name = "rdoAnkerRB";
            this.rdoAnkerRB.Size = new System.Drawing.Size(77, 23);
            this.rdoAnkerRB.TabIndex = 17;
            this.rdoAnkerRB.UseVisualStyleBackColor = true;
            this.rdoAnkerRB.CheckedChanged += new System.EventHandler(this.rdoAnkerRB_CheckedChanged);
            // 
            // rdoAnkerMB
            // 
            this.rdoAnkerMB.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerMB.Location = new System.Drawing.Point(91, 303);
            this.rdoAnkerMB.Name = "rdoAnkerMB";
            this.rdoAnkerMB.Size = new System.Drawing.Size(77, 23);
            this.rdoAnkerMB.TabIndex = 18;
            this.rdoAnkerMB.TabStop = true;
            this.rdoAnkerMB.UseVisualStyleBackColor = true;
            this.rdoAnkerMB.CheckedChanged += new System.EventHandler(this.rdoAnkerMB_CheckedChanged);
            // 
            // rdoAnkerLB
            // 
            this.rdoAnkerLB.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerLB.Location = new System.Drawing.Point(8, 303);
            this.rdoAnkerLB.Name = "rdoAnkerLB";
            this.rdoAnkerLB.Size = new System.Drawing.Size(77, 23);
            this.rdoAnkerLB.TabIndex = 19;
            this.rdoAnkerLB.TabStop = true;
            this.rdoAnkerLB.UseVisualStyleBackColor = true;
            this.rdoAnkerLB.CheckedChanged += new System.EventHandler(this.rdoAnkerLB_CheckedChanged);
            // 
            // rdoAnkerLM
            // 
            this.rdoAnkerLM.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerLM.Location = new System.Drawing.Point(8, 274);
            this.rdoAnkerLM.Name = "rdoAnkerLM";
            this.rdoAnkerLM.Size = new System.Drawing.Size(77, 23);
            this.rdoAnkerLM.TabIndex = 22;
            this.rdoAnkerLM.UseVisualStyleBackColor = true;
            this.rdoAnkerLM.CheckedChanged += new System.EventHandler(this.rdoAnkerLM_CheckedChanged);
            // 
            // rdoAnkerMM
            // 
            this.rdoAnkerMM.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerMM.Location = new System.Drawing.Point(91, 274);
            this.rdoAnkerMM.Name = "rdoAnkerMM";
            this.rdoAnkerMM.Size = new System.Drawing.Size(77, 23);
            this.rdoAnkerMM.TabIndex = 21;
            this.rdoAnkerMM.UseVisualStyleBackColor = true;
            this.rdoAnkerMM.CheckedChanged += new System.EventHandler(this.rdoAnkerMM_CheckedChanged);
            // 
            // rdoAnkerRM
            // 
            this.rdoAnkerRM.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerRM.Location = new System.Drawing.Point(174, 274);
            this.rdoAnkerRM.Name = "rdoAnkerRM";
            this.rdoAnkerRM.Size = new System.Drawing.Size(77, 23);
            this.rdoAnkerRM.TabIndex = 20;
            this.rdoAnkerRM.TabStop = true;
            this.rdoAnkerRM.UseVisualStyleBackColor = true;
            this.rdoAnkerRM.CheckedChanged += new System.EventHandler(this.rdoAnkerRM_CheckedChanged);
            // 
            // rdoAnkerLU
            // 
            this.rdoAnkerLU.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerLU.Location = new System.Drawing.Point(8, 245);
            this.rdoAnkerLU.Name = "rdoAnkerLU";
            this.rdoAnkerLU.Size = new System.Drawing.Size(77, 23);
            this.rdoAnkerLU.TabIndex = 25;
            this.rdoAnkerLU.TabStop = true;
            this.rdoAnkerLU.UseVisualStyleBackColor = true;
            this.rdoAnkerLU.CheckedChanged += new System.EventHandler(this.rdoAnkerLU_CheckedChanged);
            // 
            // rdoAnkerMU
            // 
            this.rdoAnkerMU.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerMU.Location = new System.Drawing.Point(91, 245);
            this.rdoAnkerMU.Name = "rdoAnkerMU";
            this.rdoAnkerMU.Size = new System.Drawing.Size(77, 23);
            this.rdoAnkerMU.TabIndex = 24;
            this.rdoAnkerMU.TabStop = true;
            this.rdoAnkerMU.UseVisualStyleBackColor = true;
            this.rdoAnkerMU.CheckedChanged += new System.EventHandler(this.rdoAnkerMU_CheckedChanged);
            // 
            // rdoAnkerRU
            // 
            this.rdoAnkerRU.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerRU.Location = new System.Drawing.Point(174, 245);
            this.rdoAnkerRU.Name = "rdoAnkerRU";
            this.rdoAnkerRU.Size = new System.Drawing.Size(77, 23);
            this.rdoAnkerRU.TabIndex = 23;
            this.rdoAnkerRU.TabStop = true;
            this.rdoAnkerRU.UseVisualStyleBackColor = true;
            this.rdoAnkerRU.CheckedChanged += new System.EventHandler(this.rdoAnkerRU_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Label anker";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 93);
            this.panel1.TabIndex = 27;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(132, 332);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 23);
            this.button3.TabIndex = 28;
            this.button3.Text = "Doking Point Editor";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboProminence
            // 
            this.comboProminence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProminence.FormattingEnabled = true;
            this.comboProminence.Items.AddRange(new object[] {
            "Default",
            "None",
            "Ending Lines",
            "All"});
            this.comboProminence.Location = new System.Drawing.Point(128, 32);
            this.comboProminence.Name = "comboProminence";
            this.comboProminence.Size = new System.Drawing.Size(121, 21);
            this.comboProminence.TabIndex = 29;
            this.comboProminence.SelectedIndexChanged += new System.EventHandler(this.comboProminence_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Prominence";
            // 
            // StationEditor
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(261, 442);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboProminence);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdoAnkerLU);
            this.Controls.Add(this.rdoAnkerMU);
            this.Controls.Add(this.rdoAnkerRU);
            this.Controls.Add(this.rdoAnkerLM);
            this.Controls.Add(this.rdoAnkerMM);
            this.Controls.Add(this.rdoAnkerRM);
            this.Controls.Add(this.rdoAnkerLB);
            this.Controls.Add(this.rdoAnkerMB);
            this.Controls.Add(this.rdoAnkerRB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RotationNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RotationTrackBar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StationEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StationEditor";
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar RotationTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RotationNumber;
        private System.Windows.Forms.Label label3;
        private StationLabelOffsetEditorPanel StationLabelOffsetEditorPanel1;
        private System.Windows.Forms.RadioButton rdoAnkerRB;
        private System.Windows.Forms.RadioButton rdoAnkerMB;
        private System.Windows.Forms.RadioButton rdoAnkerLB;
        private System.Windows.Forms.RadioButton rdoAnkerLM;
        private System.Windows.Forms.RadioButton rdoAnkerMM;
        private System.Windows.Forms.RadioButton rdoAnkerRM;
        private System.Windows.Forms.RadioButton rdoAnkerLU;
        private System.Windows.Forms.RadioButton rdoAnkerMU;
        private System.Windows.Forms.RadioButton rdoAnkerRU;
        private System.Windows.Forms.Label label4;
        private StationLabelOffsetEditorPanel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboProminence;
        private System.Windows.Forms.Label label5;
    }
}