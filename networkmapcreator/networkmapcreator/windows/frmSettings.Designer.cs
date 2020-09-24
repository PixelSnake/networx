namespace NetworkMapCreator
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabShortcuts = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ScToolsConnect = new NetworkMapCreator.ShortCutButton();
            this.label16 = new System.Windows.Forms.Label();
            this.ScToolsCreate = new NetworkMapCreator.ShortCutButton();
            this.label17 = new System.Windows.Forms.Label();
            this.ScToolsSelect = new NetworkMapCreator.ShortCutButton();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ScViewSegmentsOverview = new NetworkMapCreator.ShortCutButton();
            this.label15 = new System.Windows.Forms.Label();
            this.ScViewStationsOverview = new NetworkMapCreator.ShortCutButton();
            this.label14 = new System.Windows.Forms.Label();
            this.ScViewLinesOverview = new NetworkMapCreator.ShortCutButton();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ScConnectionEditor = new NetworkMapCreator.ShortCutButton();
            this.label20 = new System.Windows.Forms.Label();
            this.ScEditSettings = new NetworkMapCreator.ShortCutButton();
            this.label12 = new System.Windows.Forms.Label();
            this.ScEditSelectStylesheet = new NetworkMapCreator.ShortCutButton();
            this.label11 = new System.Windows.Forms.Label();
            this.ScEditStationEditor = new NetworkMapCreator.ShortCutButton();
            this.label10 = new System.Windows.Forms.Label();
            this.ScEditTrackEditor = new NetworkMapCreator.ShortCutButton();
            this.label9 = new System.Windows.Forms.Label();
            this.ScEditRedo = new NetworkMapCreator.ShortCutButton();
            this.label8 = new System.Windows.Forms.Label();
            this.ScEditUndo = new NetworkMapCreator.ShortCutButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ScFileExportSVG = new NetworkMapCreator.ShortCutButton();
            this.label6 = new System.Windows.Forms.Label();
            this.ScFileExportImage = new NetworkMapCreator.ShortCutButton();
            this.label5 = new System.Windows.Forms.Label();
            this.ScFileSaveAs = new NetworkMapCreator.ShortCutButton();
            this.label4 = new System.Windows.Forms.Label();
            this.ScFileSave = new NetworkMapCreator.ShortCutButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ScFileOpen = new NetworkMapCreator.ShortCutButton();
            this.label2 = new System.Windows.Forms.Label();
            this.ScFileNew = new NetworkMapCreator.ShortCutButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabStylesheets = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.chkStylesheetAutoReloadChanges = new System.Windows.Forms.CheckBox();
            this.tabDebugging = new System.Windows.Forms.TabPage();
            this.chkDebugging = new System.Windows.Forms.CheckBox();
            this.chkFPS = new System.Windows.Forms.CheckBox();
            this.tabShortcuts.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabStylesheets.SuspendLayout();
            this.tabDebugging.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(350, 458);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabShortcuts
            // 
            this.tabShortcuts.Controls.Add(this.groupBox4);
            this.tabShortcuts.Controls.Add(this.groupBox3);
            this.tabShortcuts.Controls.Add(this.groupBox2);
            this.tabShortcuts.Controls.Add(this.groupBox1);
            this.tabShortcuts.Location = new System.Drawing.Point(4, 22);
            this.tabShortcuts.Name = "tabShortcuts";
            this.tabShortcuts.Size = new System.Drawing.Size(567, 414);
            this.tabShortcuts.TabIndex = 1;
            this.tabShortcuts.Text = "Shortcuts";
            this.tabShortcuts.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ScToolsConnect);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.ScToolsCreate);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.ScToolsSelect);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(287, 223);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 118);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tools";
            // 
            // ScToolsConnect
            // 
            this.ScToolsConnect.Location = new System.Drawing.Point(128, 77);
            this.ScToolsConnect.Name = "ScToolsConnect";
            this.ScToolsConnect.Shortcut = System.Windows.Forms.Keys.None;
            this.ScToolsConnect.Size = new System.Drawing.Size(144, 23);
            this.ScToolsConnect.TabIndex = 7;
            this.ScToolsConnect.Text = "None";
            this.ScToolsConnect.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Connect";
            // 
            // ScToolsCreate
            // 
            this.ScToolsCreate.Location = new System.Drawing.Point(128, 48);
            this.ScToolsCreate.Name = "ScToolsCreate";
            this.ScToolsCreate.Shortcut = System.Windows.Forms.Keys.None;
            this.ScToolsCreate.Size = new System.Drawing.Size(144, 23);
            this.ScToolsCreate.TabIndex = 5;
            this.ScToolsCreate.Text = "None";
            this.ScToolsCreate.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Create";
            // 
            // ScToolsSelect
            // 
            this.ScToolsSelect.Location = new System.Drawing.Point(128, 19);
            this.ScToolsSelect.Name = "ScToolsSelect";
            this.ScToolsSelect.Shortcut = System.Windows.Forms.Keys.None;
            this.ScToolsSelect.Size = new System.Drawing.Size(144, 23);
            this.ScToolsSelect.TabIndex = 3;
            this.ScToolsSelect.Text = "None";
            this.ScToolsSelect.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Select";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ScViewSegmentsOverview);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.ScViewStationsOverview);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.ScViewLinesOverview);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(3, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 118);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View";
            // 
            // ScViewSegmentsOverview
            // 
            this.ScViewSegmentsOverview.Location = new System.Drawing.Point(128, 77);
            this.ScViewSegmentsOverview.Name = "ScViewSegmentsOverview";
            this.ScViewSegmentsOverview.Shortcut = System.Windows.Forms.Keys.None;
            this.ScViewSegmentsOverview.Size = new System.Drawing.Size(144, 23);
            this.ScViewSegmentsOverview.TabIndex = 7;
            this.ScViewSegmentsOverview.Text = "None";
            this.ScViewSegmentsOverview.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Segments overview";
            // 
            // ScViewStationsOverview
            // 
            this.ScViewStationsOverview.Location = new System.Drawing.Point(128, 48);
            this.ScViewStationsOverview.Name = "ScViewStationsOverview";
            this.ScViewStationsOverview.Shortcut = System.Windows.Forms.Keys.None;
            this.ScViewStationsOverview.Size = new System.Drawing.Size(144, 23);
            this.ScViewStationsOverview.TabIndex = 5;
            this.ScViewStationsOverview.Text = "None";
            this.ScViewStationsOverview.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Stations overview";
            // 
            // ScViewLinesOverview
            // 
            this.ScViewLinesOverview.Location = new System.Drawing.Point(128, 19);
            this.ScViewLinesOverview.Name = "ScViewLinesOverview";
            this.ScViewLinesOverview.Shortcut = System.Windows.Forms.Keys.None;
            this.ScViewLinesOverview.Size = new System.Drawing.Size(144, 23);
            this.ScViewLinesOverview.TabIndex = 3;
            this.ScViewLinesOverview.Text = "None";
            this.ScViewLinesOverview.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Lines overview";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ScConnectionEditor);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.ScEditSettings);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.ScEditSelectStylesheet);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.ScEditStationEditor);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.ScEditTrackEditor);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ScEditRedo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ScEditUndo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(286, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit";
            // 
            // ScConnectionEditor
            // 
            this.ScConnectionEditor.Location = new System.Drawing.Point(128, 127);
            this.ScConnectionEditor.Name = "ScConnectionEditor";
            this.ScConnectionEditor.Shortcut = System.Windows.Forms.Keys.None;
            this.ScConnectionEditor.Size = new System.Drawing.Size(144, 23);
            this.ScConnectionEditor.TabIndex = 15;
            this.ScConnectionEditor.Text = "None";
            this.ScConnectionEditor.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 132);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 13);
            this.label20.TabIndex = 14;
            this.label20.Text = "Connection Editor";
            // 
            // ScEditSettings
            // 
            this.ScEditSettings.Location = new System.Drawing.Point(129, 185);
            this.ScEditSettings.Name = "ScEditSettings";
            this.ScEditSettings.Shortcut = System.Windows.Forms.Keys.None;
            this.ScEditSettings.Size = new System.Drawing.Size(144, 23);
            this.ScEditSettings.TabIndex = 13;
            this.ScEditSettings.Text = "None";
            this.ScEditSettings.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 190);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Settings";
            // 
            // ScEditSelectStylesheet
            // 
            this.ScEditSelectStylesheet.Location = new System.Drawing.Point(129, 156);
            this.ScEditSelectStylesheet.Name = "ScEditSelectStylesheet";
            this.ScEditSelectStylesheet.Shortcut = System.Windows.Forms.Keys.None;
            this.ScEditSelectStylesheet.Size = new System.Drawing.Size(144, 23);
            this.ScEditSelectStylesheet.TabIndex = 11;
            this.ScEditSelectStylesheet.Text = "None";
            this.ScEditSelectStylesheet.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Select Stylesheet";
            // 
            // ScEditStationEditor
            // 
            this.ScEditStationEditor.Location = new System.Drawing.Point(129, 98);
            this.ScEditStationEditor.Name = "ScEditStationEditor";
            this.ScEditStationEditor.Shortcut = System.Windows.Forms.Keys.None;
            this.ScEditStationEditor.Size = new System.Drawing.Size(144, 23);
            this.ScEditStationEditor.TabIndex = 9;
            this.ScEditStationEditor.Text = "None";
            this.ScEditStationEditor.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Station Editor";
            // 
            // ScEditTrackEditor
            // 
            this.ScEditTrackEditor.Location = new System.Drawing.Point(128, 69);
            this.ScEditTrackEditor.Name = "ScEditTrackEditor";
            this.ScEditTrackEditor.Shortcut = System.Windows.Forms.Keys.None;
            this.ScEditTrackEditor.Size = new System.Drawing.Size(144, 23);
            this.ScEditTrackEditor.TabIndex = 7;
            this.ScEditTrackEditor.Text = "None";
            this.ScEditTrackEditor.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Track Editor";
            // 
            // ScEditRedo
            // 
            this.ScEditRedo.Location = new System.Drawing.Point(128, 40);
            this.ScEditRedo.Name = "ScEditRedo";
            this.ScEditRedo.Shortcut = System.Windows.Forms.Keys.None;
            this.ScEditRedo.Size = new System.Drawing.Size(144, 23);
            this.ScEditRedo.TabIndex = 5;
            this.ScEditRedo.Text = "None";
            this.ScEditRedo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Redo";
            // 
            // ScEditUndo
            // 
            this.ScEditUndo.Location = new System.Drawing.Point(129, 11);
            this.ScEditUndo.Name = "ScEditUndo";
            this.ScEditUndo.Shortcut = System.Windows.Forms.Keys.None;
            this.ScEditUndo.Size = new System.Drawing.Size(144, 23);
            this.ScEditUndo.TabIndex = 3;
            this.ScEditUndo.Text = "None";
            this.ScEditUndo.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Undo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ScFileExportSVG);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ScFileExportImage);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ScFileSaveAs);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ScFileSave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ScFileOpen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ScFileNew);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // ScFileExportSVG
            // 
            this.ScFileExportSVG.Location = new System.Drawing.Point(128, 156);
            this.ScFileExportSVG.Name = "ScFileExportSVG";
            this.ScFileExportSVG.Shortcut = System.Windows.Forms.Keys.None;
            this.ScFileExportSVG.Size = new System.Drawing.Size(144, 23);
            this.ScFileExportSVG.TabIndex = 11;
            this.ScFileExportSVG.Text = "None";
            this.ScFileExportSVG.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Export -> SVG";
            // 
            // ScFileExportImage
            // 
            this.ScFileExportImage.Location = new System.Drawing.Point(128, 127);
            this.ScFileExportImage.Name = "ScFileExportImage";
            this.ScFileExportImage.Shortcut = System.Windows.Forms.Keys.None;
            this.ScFileExportImage.Size = new System.Drawing.Size(144, 23);
            this.ScFileExportImage.TabIndex = 9;
            this.ScFileExportImage.Text = "None";
            this.ScFileExportImage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Export -> Image";
            // 
            // ScFileSaveAs
            // 
            this.ScFileSaveAs.Location = new System.Drawing.Point(128, 98);
            this.ScFileSaveAs.Name = "ScFileSaveAs";
            this.ScFileSaveAs.Shortcut = System.Windows.Forms.Keys.None;
            this.ScFileSaveAs.Size = new System.Drawing.Size(144, 23);
            this.ScFileSaveAs.TabIndex = 7;
            this.ScFileSaveAs.Text = "None";
            this.ScFileSaveAs.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Save As";
            // 
            // ScFileSave
            // 
            this.ScFileSave.Location = new System.Drawing.Point(128, 69);
            this.ScFileSave.Name = "ScFileSave";
            this.ScFileSave.Shortcut = System.Windows.Forms.Keys.None;
            this.ScFileSave.Size = new System.Drawing.Size(144, 23);
            this.ScFileSave.TabIndex = 5;
            this.ScFileSave.Text = "None";
            this.ScFileSave.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Save";
            // 
            // ScFileOpen
            // 
            this.ScFileOpen.Location = new System.Drawing.Point(128, 40);
            this.ScFileOpen.Name = "ScFileOpen";
            this.ScFileOpen.Shortcut = System.Windows.Forms.Keys.None;
            this.ScFileOpen.Size = new System.Drawing.Size(144, 23);
            this.ScFileOpen.TabIndex = 3;
            this.ScFileOpen.Text = "None";
            this.ScFileOpen.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Open";
            // 
            // ScFileNew
            // 
            this.ScFileNew.Location = new System.Drawing.Point(128, 11);
            this.ScFileNew.Name = "ScFileNew";
            this.ScFileNew.Shortcut = System.Windows.Forms.Keys.None;
            this.ScFileNew.Size = new System.Drawing.Size(144, 23);
            this.ScFileNew.TabIndex = 1;
            this.ScFileNew.Text = "None";
            this.ScFileNew.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New";
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabShortcuts);
            this.tabControlSettings.Controls.Add(this.tabStylesheets);
            this.tabControlSettings.Controls.Add(this.tabDebugging);
            this.tabControlSettings.Location = new System.Drawing.Point(12, 12);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(575, 440);
            this.tabControlSettings.TabIndex = 3;
            // 
            // tabStylesheets
            // 
            this.tabStylesheets.Controls.Add(this.label19);
            this.tabStylesheets.Controls.Add(this.chkStylesheetAutoReloadChanges);
            this.tabStylesheets.Location = new System.Drawing.Point(4, 22);
            this.tabStylesheets.Name = "tabStylesheets";
            this.tabStylesheets.Padding = new System.Windows.Forms.Padding(3);
            this.tabStylesheets.Size = new System.Drawing.Size(567, 414);
            this.tabStylesheets.TabIndex = 2;
            this.tabStylesheets.Text = "Stylesheets";
            this.tabStylesheets.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(288, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(273, 44);
            this.label19.TabIndex = 1;
            this.label19.Text = "Changes made in the active CSS stylesheet file will immediately take place with t" +
    "his option enabled";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkStylesheetAutoReloadChanges
            // 
            this.chkStylesheetAutoReloadChanges.AutoSize = true;
            this.chkStylesheetAutoReloadChanges.Checked = true;
            this.chkStylesheetAutoReloadChanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStylesheetAutoReloadChanges.Location = new System.Drawing.Point(6, 6);
            this.chkStylesheetAutoReloadChanges.Name = "chkStylesheetAutoReloadChanges";
            this.chkStylesheetAutoReloadChanges.Size = new System.Drawing.Size(220, 17);
            this.chkStylesheetAutoReloadChanges.TabIndex = 0;
            this.chkStylesheetAutoReloadChanges.Text = "Automatically reload when file is changed";
            this.chkStylesheetAutoReloadChanges.UseVisualStyleBackColor = true;
            // 
            // tabDebugging
            // 
            this.tabDebugging.Controls.Add(this.chkFPS);
            this.tabDebugging.Controls.Add(this.chkDebugging);
            this.tabDebugging.Location = new System.Drawing.Point(4, 22);
            this.tabDebugging.Name = "tabDebugging";
            this.tabDebugging.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebugging.Size = new System.Drawing.Size(567, 414);
            this.tabDebugging.TabIndex = 3;
            this.tabDebugging.Text = "Debugging";
            this.tabDebugging.UseVisualStyleBackColor = true;
            // 
            // chkDebugging
            // 
            this.chkDebugging.AutoSize = true;
            this.chkDebugging.Location = new System.Drawing.Point(6, 6);
            this.chkDebugging.Name = "chkDebugging";
            this.chkDebugging.Size = new System.Drawing.Size(145, 17);
            this.chkDebugging.TabIndex = 0;
            this.chkDebugging.Text = "Enable debugging output";
            this.chkDebugging.UseVisualStyleBackColor = true;
            // 
            // chkFPS
            // 
            this.chkFPS.AutoSize = true;
            this.chkFPS.Location = new System.Drawing.Point(6, 29);
            this.chkFPS.Name = "chkFPS";
            this.chkFPS.Size = new System.Drawing.Size(121, 17);
            this.chkFPS.TabIndex = 1;
            this.chkFPS.Text = "Enable FPS counter";
            this.chkFPS.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 493);
            this.Controls.Add(this.tabControlSettings);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabShortcuts.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlSettings.ResumeLayout(false);
            this.tabStylesheets.ResumeLayout(false);
            this.tabStylesheets.PerformLayout();
            this.tabDebugging.ResumeLayout(false);
            this.tabDebugging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabShortcuts;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ShortCutButton ScFileExportSVG;
        private System.Windows.Forms.Label label6;
        private ShortCutButton ScFileExportImage;
        private System.Windows.Forms.Label label5;
        private ShortCutButton ScFileSaveAs;
        private System.Windows.Forms.Label label4;
        private ShortCutButton ScFileSave;
        private System.Windows.Forms.Label label3;
        private ShortCutButton ScFileOpen;
        private System.Windows.Forms.Label label2;
        private ShortCutButton ScFileNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlSettings;
        private ShortCutButton ScEditRedo;
        private System.Windows.Forms.Label label8;
        private ShortCutButton ScEditUndo;
        private System.Windows.Forms.Label label7;
        private ShortCutButton ScEditStationEditor;
        private System.Windows.Forms.Label label10;
        private ShortCutButton ScEditTrackEditor;
        private System.Windows.Forms.Label label9;
        private ShortCutButton ScEditSettings;
        private System.Windows.Forms.Label label12;
        private ShortCutButton ScEditSelectStylesheet;
        private System.Windows.Forms.Label label11;
        private ShortCutButton ScViewSegmentsOverview;
        private System.Windows.Forms.Label label15;
        private ShortCutButton ScViewStationsOverview;
        private System.Windows.Forms.Label label14;
        private ShortCutButton ScViewLinesOverview;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private ShortCutButton ScToolsConnect;
        private System.Windows.Forms.Label label16;
        private ShortCutButton ScToolsCreate;
        private System.Windows.Forms.Label label17;
        private ShortCutButton ScToolsSelect;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabStylesheets;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkStylesheetAutoReloadChanges;
        private ShortCutButton ScConnectionEditor;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tabDebugging;
        private System.Windows.Forms.CheckBox chkFPS;
        private System.Windows.Forms.CheckBox chkDebugging;
    }
}