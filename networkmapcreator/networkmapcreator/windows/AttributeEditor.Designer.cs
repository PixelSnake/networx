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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoAnkerRB = new System.Windows.Forms.RadioButton();
            this.rdoAnkerMB = new System.Windows.Forms.RadioButton();
            this.rdoAnkerLB = new System.Windows.Forms.RadioButton();
            this.rdoAnkerRM = new System.Windows.Forms.RadioButton();
            this.rdoAnkerMM = new System.Windows.Forms.RadioButton();
            this.rdoAnkerLM = new System.Windows.Forms.RadioButton();
            this.rdoAnkerLU = new System.Windows.Forms.RadioButton();
            this.rdoAnkerMU = new System.Windows.Forms.RadioButton();
            this.rdoAnkerRU = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new NetworkMapCreator.StationLabelOffsetEditorPanel();
            this.RotationTrackBar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboProminence = new System.Windows.Forms.ComboBox();
            this.RotationNumber = new System.Windows.Forms.NumericUpDown();
            this.SegmentAttributes = new System.Windows.Forms.TableLayoutPanel();
            this.segmentOrderEditorPanel1 = new NetworkMapCreator.Controls.SegmentOrderEditorPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLineMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.ContentPanel.SuspendLayout();
            this.StationAttributes.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationNumber)).BeginInit();
            this.SegmentAttributes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
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
            this.ContentPanel.Size = new System.Drawing.Size(431, 691);
            this.ContentPanel.TabIndex = 0;
            // 
            // StationAttributes
            // 
            this.StationAttributes.ColumnCount = 1;
            this.StationAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StationAttributes.Controls.Add(this.tabControl1, 0, 3);
            this.StationAttributes.Controls.Add(this.RotationTrackBar, 0, 1);
            this.StationAttributes.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.StationAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.StationAttributes.Location = new System.Drawing.Point(0, 505);
            this.StationAttributes.Name = "StationAttributes";
            this.StationAttributes.RowCount = 4;
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StationAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StationAttributes.Size = new System.Drawing.Size(414, 491);
            this.StationAttributes.TabIndex = 12;
            this.StationAttributes.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 165);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(408, 323);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(400, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Label";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 291);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerRB, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerMB, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerLB, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerRM, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerMM, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerLM, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerLU, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerMU, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.rdoAnkerRU, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 169);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(388, 119);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // rdoAnkerRB
            // 
            this.rdoAnkerRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerRB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerRB.Location = new System.Drawing.Point(261, 81);
            this.rdoAnkerRB.Name = "rdoAnkerRB";
            this.rdoAnkerRB.Size = new System.Drawing.Size(124, 35);
            this.rdoAnkerRB.TabIndex = 23;
            this.rdoAnkerRB.UseVisualStyleBackColor = true;
            this.rdoAnkerRB.CheckedChanged += new System.EventHandler(this.rdoAnkerRB_CheckedChanged);
            // 
            // rdoAnkerMB
            // 
            this.rdoAnkerMB.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerMB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerMB.Location = new System.Drawing.Point(132, 81);
            this.rdoAnkerMB.Name = "rdoAnkerMB";
            this.rdoAnkerMB.Size = new System.Drawing.Size(123, 35);
            this.rdoAnkerMB.TabIndex = 24;
            this.rdoAnkerMB.TabStop = true;
            this.rdoAnkerMB.UseVisualStyleBackColor = true;
            this.rdoAnkerMB.CheckedChanged += new System.EventHandler(this.rdoAnkerMB_CheckedChanged);
            // 
            // rdoAnkerLB
            // 
            this.rdoAnkerLB.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerLB.Location = new System.Drawing.Point(3, 81);
            this.rdoAnkerLB.Name = "rdoAnkerLB";
            this.rdoAnkerLB.Size = new System.Drawing.Size(123, 35);
            this.rdoAnkerLB.TabIndex = 25;
            this.rdoAnkerLB.TabStop = true;
            this.rdoAnkerLB.UseVisualStyleBackColor = true;
            this.rdoAnkerLB.CheckedChanged += new System.EventHandler(this.rdoAnkerLB_CheckedChanged);
            // 
            // rdoAnkerRM
            // 
            this.rdoAnkerRM.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerRM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerRM.Location = new System.Drawing.Point(261, 42);
            this.rdoAnkerRM.Name = "rdoAnkerRM";
            this.rdoAnkerRM.Size = new System.Drawing.Size(124, 33);
            this.rdoAnkerRM.TabIndex = 26;
            this.rdoAnkerRM.TabStop = true;
            this.rdoAnkerRM.UseVisualStyleBackColor = true;
            this.rdoAnkerRM.CheckedChanged += new System.EventHandler(this.rdoAnkerRM_CheckedChanged);
            // 
            // rdoAnkerMM
            // 
            this.rdoAnkerMM.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerMM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerMM.Location = new System.Drawing.Point(132, 42);
            this.rdoAnkerMM.Name = "rdoAnkerMM";
            this.rdoAnkerMM.Size = new System.Drawing.Size(123, 33);
            this.rdoAnkerMM.TabIndex = 27;
            this.rdoAnkerMM.UseVisualStyleBackColor = true;
            this.rdoAnkerMM.CheckedChanged += new System.EventHandler(this.rdoAnkerMM_CheckedChanged);
            // 
            // rdoAnkerLM
            // 
            this.rdoAnkerLM.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerLM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerLM.Location = new System.Drawing.Point(3, 42);
            this.rdoAnkerLM.Name = "rdoAnkerLM";
            this.rdoAnkerLM.Size = new System.Drawing.Size(123, 33);
            this.rdoAnkerLM.TabIndex = 28;
            this.rdoAnkerLM.UseVisualStyleBackColor = true;
            this.rdoAnkerLM.CheckedChanged += new System.EventHandler(this.rdoAnkerLM_CheckedChanged);
            // 
            // rdoAnkerLU
            // 
            this.rdoAnkerLU.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerLU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerLU.Location = new System.Drawing.Point(3, 3);
            this.rdoAnkerLU.Name = "rdoAnkerLU";
            this.rdoAnkerLU.Size = new System.Drawing.Size(123, 33);
            this.rdoAnkerLU.TabIndex = 26;
            this.rdoAnkerLU.TabStop = true;
            this.rdoAnkerLU.UseVisualStyleBackColor = true;
            this.rdoAnkerLU.CheckedChanged += new System.EventHandler(this.rdoAnkerLU_CheckedChanged);
            // 
            // rdoAnkerMU
            // 
            this.rdoAnkerMU.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerMU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerMU.Location = new System.Drawing.Point(132, 3);
            this.rdoAnkerMU.Name = "rdoAnkerMU";
            this.rdoAnkerMU.Size = new System.Drawing.Size(123, 33);
            this.rdoAnkerMU.TabIndex = 27;
            this.rdoAnkerMU.TabStop = true;
            this.rdoAnkerMU.UseVisualStyleBackColor = true;
            this.rdoAnkerMU.CheckedChanged += new System.EventHandler(this.rdoAnkerMU_CheckedChanged);
            // 
            // rdoAnkerRU
            // 
            this.rdoAnkerRU.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAnkerRU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnkerRU.Location = new System.Drawing.Point(261, 3);
            this.rdoAnkerRU.Name = "rdoAnkerRU";
            this.rdoAnkerRU.Size = new System.Drawing.Size(124, 33);
            this.rdoAnkerRU.TabIndex = 28;
            this.rdoAnkerRU.TabStop = true;
            this.rdoAnkerRU.UseVisualStyleBackColor = true;
            this.rdoAnkerRU.CheckedChanged += new System.EventHandler(this.rdoAnkerRU_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Position";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Anker";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 114);
            this.panel1.TabIndex = 28;
            // 
            // RotationTrackBar
            // 
            this.RotationTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotationTrackBar.Location = new System.Drawing.Point(3, 114);
            this.RotationTrackBar.Maximum = 180;
            this.RotationTrackBar.Minimum = -180;
            this.RotationTrackBar.Name = "RotationTrackBar";
            this.RotationTrackBar.Size = new System.Drawing.Size(408, 45);
            this.RotationTrackBar.TabIndex = 5;
            this.RotationTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RotationTrackBar.ValueChanged += new System.EventHandler(this.RotationTrackBar_ValueChanged);
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
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(408, 105);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 52);
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
            this.txtName.Size = new System.Drawing.Size(333, 20);
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
            this.comboProminence.Size = new System.Drawing.Size(333, 21);
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
            this.RotationNumber.Size = new System.Drawing.Size(333, 20);
            this.RotationNumber.TabIndex = 34;
            this.RotationNumber.ValueChanged += new System.EventHandler(this.RotationNumber_ValueChanged);
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
            this.SegmentAttributes.Size = new System.Drawing.Size(414, 505);
            this.SegmentAttributes.TabIndex = 10;
            this.SegmentAttributes.Visible = false;
            // 
            // segmentOrderEditorPanel1
            // 
            this.segmentOrderEditorPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.segmentOrderEditorPanel1.Location = new System.Drawing.Point(3, 38);
            this.segmentOrderEditorPanel1.Name = "segmentOrderEditorPanel1";
            this.segmentOrderEditorPanel1.Size = new System.Drawing.Size(408, 14);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 29);
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
            this.comboLineMode.Size = new System.Drawing.Size(330, 21);
            this.comboLineMode.TabIndex = 0;
            this.comboLineMode.SelectedIndexChanged += new System.EventHandler(this.comboLineMode_SelectedIndexChanged);
            this.comboLineMode.SelectionChangeCommitted += new System.EventHandler(this.comboLineMode_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(414, 996);
            this.label3.TabIndex = 11;
            this.label3.Text = "Select one or multiple elements of the same type to edit their attributes";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(400, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Comment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComment.Location = new System.Drawing.Point(3, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 81);
            this.lblComment.TabIndex = 38;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment
            // 
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtComment.Location = new System.Drawing.Point(60, 3);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(325, 75);
            this.txtComment.TabIndex = 37;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(394, 291);
            this.tableLayoutPanel5.TabIndex = 39;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.lblComment, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.txtComment, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(388, 81);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // AttributeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 691);
            this.Controls.Add(this.ContentPanel);
            this.Name = "AttributeEditor";
            this.Text = "AttributeEditor";
            this.ContentPanel.ResumeLayout(false);
            this.StationAttributes.ResumeLayout(false);
            this.StationAttributes.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationNumber)).EndInit();
            this.SegmentAttributes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
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
        private StationLabelOffsetEditorPanel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdoAnkerLU;
        private System.Windows.Forms.RadioButton rdoAnkerMU;
        private System.Windows.Forms.RadioButton rdoAnkerRU;
        private System.Windows.Forms.RadioButton rdoAnkerRB;
        private System.Windows.Forms.RadioButton rdoAnkerMB;
        private System.Windows.Forms.RadioButton rdoAnkerLB;
        private System.Windows.Forms.RadioButton rdoAnkerRM;
        private System.Windows.Forms.RadioButton rdoAnkerMM;
        private System.Windows.Forms.RadioButton rdoAnkerLM;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
    }
}