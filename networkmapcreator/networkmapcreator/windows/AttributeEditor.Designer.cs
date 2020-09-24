namespace NetworkMapCreator.Windows
{
    partial class AttributeEditor
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
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.StationAttributes = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoAnkerBL = new System.Windows.Forms.RadioButton();
            this.rdoAnkerBR = new System.Windows.Forms.RadioButton();
            this.rdoAnkerBC = new System.Windows.Forms.RadioButton();
            this.rdoAnkerCR = new System.Windows.Forms.RadioButton();
            this.rdoAnkerC = new System.Windows.Forms.RadioButton();
            this.rdoAnkerCL = new System.Windows.Forms.RadioButton();
            this.rdoAnkerTL = new System.Windows.Forms.RadioButton();
            this.rdoAnkerTC = new System.Windows.Forms.RadioButton();
            this.rdoAnkerTR = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RotationTrackBar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboProminence = new System.Windows.Forms.ComboBox();
            this.RotationNumber = new System.Windows.Forms.NumericUpDown();
            this.LabelOffsetPanel = new NetworkMapCreator.StationLabelOffsetEditorPanel();
            this.SegmentAttributes = new System.Windows.Forms.TableLayoutPanel();
            this.segmentOrderEditorPanel1 = new NetworkMapCreator.Controls.SegmentOrderEditorPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLineMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ContentPanel.SuspendLayout();
            this.StationAttributes.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationNumber)).BeginInit();
            this.SegmentAttributes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Controls.Add(this.StationAttributes);
            this.ContentPanel.Controls.Add(this.SegmentAttributes);
            this.ContentPanel.Controls.Add(this.label3);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(316, 543);
            this.ContentPanel.TabIndex = 0;
            // 
            // StationAttributes
            // 
            this.StationAttributes.ColumnCount = 1;
            this.StationAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StationAttributes.Controls.Add(this.tableLayoutPanel4, 0, 6);
            this.StationAttributes.Controls.Add(this.label7, 0, 5);
            this.StationAttributes.Controls.Add(this.label6, 0, 2);
            this.StationAttributes.Controls.Add(this.RotationTrackBar, 0, 1);
            this.StationAttributes.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.StationAttributes.Controls.Add(this.LabelOffsetPanel, 0, 3);
            this.StationAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.StationAttributes.Location = new System.Drawing.Point(0, 548);
            this.StationAttributes.Name = "StationAttributes";
            this.StationAttributes.RowCount = 7;
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.StationAttributes.Size = new System.Drawing.Size(299, 420);
            this.StationAttributes.TabIndex = 12;
            this.StationAttributes.Visible = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerBL, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerBR, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerBC, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerCR, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerC, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerCL, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerTL, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerTC, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerTR, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 306);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(293, 111);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // rdoAnkerBL
            // 
            this.rdoAnkerBL.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerBL.Location = new System.Drawing.Point(3, 77);
            this.rdoAnkerBL.Name = "rdoAnkerBL";
            this.rdoAnkerBL.Size = new System.Drawing.Size(91, 31);
            this.rdoAnkerBL.TabIndex = 29;
            this.rdoAnkerBL.TabStop = true;
            this.rdoAnkerBL.UseVisualStyleBackColor = true;
            // 
            // rdoAnkerBR
            // 
            this.rdoAnkerBR.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerBR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerBR.Location = new System.Drawing.Point(197, 77);
            this.rdoAnkerBR.Name = "rdoAnkerBR";
            this.rdoAnkerBR.Size = new System.Drawing.Size(93, 31);
            this.rdoAnkerBR.TabIndex = 23;
            this.rdoAnkerBR.UseVisualStyleBackColor = true;
            // 
            // rdoAnkerBC
            // 
            this.rdoAnkerBC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerBC.Location = new System.Drawing.Point(100, 77);
            this.rdoAnkerBC.Name = "rdoAnkerBC";
            this.rdoAnkerBC.Size = new System.Drawing.Size(91, 31);
            this.rdoAnkerBC.TabIndex = 24;
            this.rdoAnkerBC.TabStop = true;
            this.rdoAnkerBC.UseVisualStyleBackColor = true;
            // 
            // rdoAnkerCR
            // 
            this.rdoAnkerCR.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerCR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerCR.Location = new System.Drawing.Point(197, 40);
            this.rdoAnkerCR.Name = "rdoAnkerCR";
            this.rdoAnkerCR.Size = new System.Drawing.Size(93, 31);
            this.rdoAnkerCR.TabIndex = 26;
            this.rdoAnkerCR.TabStop = true;
            this.rdoAnkerCR.UseVisualStyleBackColor = true;
            // 
            // rdoAnkerC
            // 
            this.rdoAnkerC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerC.Location = new System.Drawing.Point(100, 40);
            this.rdoAnkerC.Name = "rdoAnkerC";
            this.rdoAnkerC.Size = new System.Drawing.Size(91, 31);
            this.rdoAnkerC.TabIndex = 27;
            this.rdoAnkerC.UseVisualStyleBackColor = true;
            // 
            // rdoAnkerCL
            // 
            this.rdoAnkerCL.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerCL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerCL.Location = new System.Drawing.Point(3, 40);
            this.rdoAnkerCL.Name = "rdoAnkerCL";
            this.rdoAnkerCL.Size = new System.Drawing.Size(91, 31);
            this.rdoAnkerCL.TabIndex = 28;
            this.rdoAnkerCL.UseVisualStyleBackColor = true;
            // 
            // rdoAnkerTL
            // 
            this.rdoAnkerTL.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerTL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerTL.Location = new System.Drawing.Point(3, 3);
            this.rdoAnkerTL.Name = "rdoAnkerTL";
            this.rdoAnkerTL.Size = new System.Drawing.Size(91, 31);
            this.rdoAnkerTL.TabIndex = 26;
            this.rdoAnkerTL.TabStop = true;
            this.rdoAnkerTL.UseVisualStyleBackColor = true;
            // 
            // rdoAnkerTC
            // 
            this.rdoAnkerTC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerTC.Location = new System.Drawing.Point(100, 3);
            this.rdoAnkerTC.Name = "rdoAnkerTC";
            this.rdoAnkerTC.Size = new System.Drawing.Size(91, 31);
            this.rdoAnkerTC.TabIndex = 27;
            this.rdoAnkerTC.TabStop = true;
            this.rdoAnkerTC.UseVisualStyleBackColor = true;
            // 
            // rdoAnkerTR
            // 
            this.rdoAnkerTR.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerTR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerTR.Location = new System.Drawing.Point(197, 3);
            this.rdoAnkerTR.Name = "rdoAnkerTR";
            this.rdoAnkerTR.Size = new System.Drawing.Size(93, 31);
            this.rdoAnkerTR.TabIndex = 28;
            this.rdoAnkerTR.TabStop = true;
            this.rdoAnkerTR.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Label Anker";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Label position";
            // 
            // RotationTrackBar
            // 
            this.RotationTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotationTrackBar.Location = new System.Drawing.Point(3, 89);
            this.RotationTrackBar.Maximum = 180;
            this.RotationTrackBar.Minimum = -180;
            this.RotationTrackBar.Name = "RotationTrackBar";
            this.RotationTrackBar.Size = new System.Drawing.Size(293, 45);
            this.RotationTrackBar.TabIndex = 5;
            this.RotationTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboProminence, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.RotationNumber, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(293, 80);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 27);
            this.label4.TabIndex = 33;
            this.label4.Text = "Rotation";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 27);
            this.label5.TabIndex = 31;
            this.label5.Text = "Prominence";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(72, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboProminence
            // 
            this.comboProminence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboProminence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProminence.FormattingEnabled = true;
            this.comboProminence.Items.AddRange(new object[] {
            "",
            "Default",
            "None",
            "Ending Lines",
            "All"});
            this.comboProminence.Location = new System.Drawing.Point(72, 29);
            this.comboProminence.Name = "comboProminence";
            this.comboProminence.Size = new System.Drawing.Size(218, 21);
            this.comboProminence.TabIndex = 32;
            this.comboProminence.SelectedIndexChanged += new System.EventHandler(this.comboProminence_SelectedIndexChanged);
            // 
            // RotationNumber
            // 
            this.RotationNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotationNumber.Location = new System.Drawing.Point(72, 56);
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
            this.RotationNumber.Size = new System.Drawing.Size(218, 20);
            this.RotationNumber.TabIndex = 34;
            // 
            // LabelOffsetPanel
            // 
            this.LabelOffsetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelOffsetPanel.Location = new System.Drawing.Point(3, 153);
            this.LabelOffsetPanel.Name = "LabelOffsetPanel";
            this.LabelOffsetPanel.Size = new System.Drawing.Size(293, 114);
            this.LabelOffsetPanel.TabIndex = 28;
            // 
            // SegmentAttributes
            // 
            this.SegmentAttributes.ColumnCount = 1;
            this.SegmentAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SegmentAttributes.Controls.Add(this.segmentOrderEditorPanel1, 0, 0);
            this.SegmentAttributes.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.SegmentAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.SegmentAttributes.Location = new System.Drawing.Point(0, 0);
            this.SegmentAttributes.Name = "SegmentAttributes";
            this.SegmentAttributes.RowCount = 3;
            this.SegmentAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SegmentAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SegmentAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SegmentAttributes.Size = new System.Drawing.Size(299, 548);
            this.SegmentAttributes.TabIndex = 10;
            this.SegmentAttributes.Visible = false;
            // 
            // segmentOrderEditorPanel1
            // 
            this.segmentOrderEditorPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.segmentOrderEditorPanel1.Location = new System.Drawing.Point(3, 38);
            this.segmentOrderEditorPanel1.Name = "segmentOrderEditorPanel1";
            this.segmentOrderEditorPanel1.Size = new System.Drawing.Size(293, 14);
            this.segmentOrderEditorPanel1.Source = null;
            this.segmentOrderEditorPanel1.TabIndex = 12;
            this.segmentOrderEditorPanel1.Text = "segmentOrderEditorPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboLineMode, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(293, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Line mode";
            // 
            // comboLineMode
            // 
            this.comboLineMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboLineMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLineMode.FormattingEnabled = true;
            this.comboLineMode.Items.AddRange(new object[] {
            "",
            "Straight",
            "Curved",
            "Steps",
            "Wave"});
            this.comboLineMode.Location = new System.Drawing.Point(75, 3);
            this.comboLineMode.Name = "comboLineMode";
            this.comboLineMode.Size = new System.Drawing.Size(215, 21);
            this.comboLineMode.TabIndex = 0;
            this.comboLineMode.SelectedIndexChanged += new System.EventHandler(this.comboLineMode_SelectedIndexChanged);
            this.comboLineMode.SelectionChangeCommitted += new System.EventHandler(this.comboLineMode_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 968);
            this.label3.TabIndex = 11;
            this.label3.Text = "Select one or multiple elements of the same type to edit their attributes";
            // 
            // AttributeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 543);
            this.Controls.Add(this.ContentPanel);
            this.Name = "AttributeEditor";
            this.Text = "AttributeEditor";
            this.ContentPanel.ResumeLayout(false);
            this.StationAttributes.ResumeLayout(false);
            this.StationAttributes.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationNumber)).EndInit();
            this.SegmentAttributes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.TableLayoutPanel SegmentAttributes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboLineMode;
        private System.Windows.Forms.Label label3;
        private Controls.SegmentOrderEditorPanel segmentOrderEditorPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel StationAttributes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboProminence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RotationNumber;
        private System.Windows.Forms.TrackBar RotationTrackBar;
        private StationLabelOffsetEditorPanel LabelOffsetPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdoAnkerTL;
        private System.Windows.Forms.RadioButton rdoAnkerTC;
        private System.Windows.Forms.RadioButton rdoAnkerTR;
        private System.Windows.Forms.RadioButton rdoAnkerBR;
        private System.Windows.Forms.RadioButton rdoAnkerBC;
        private System.Windows.Forms.RadioButton rdoAnkerXX;
        private System.Windows.Forms.RadioButton rdoAnkerCR;
        private System.Windows.Forms.RadioButton rdoAnkerC;
        private System.Windows.Forms.RadioButton rdoAnkerCL;
        private System.Windows.Forms.RadioButton rdoAnkerBL;
    }
}