namespace NetworkMapCreator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noRecentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSVGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openTrackEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openStationEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConnectionEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectStylesheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.addIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wIndowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentsOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SelectionAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStation = new System.Windows.Forms.ToolStripButton();
            this.toolConnect = new System.Windows.Forms.ToolStripButton();
            this.toolComboLines = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.DockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.wIndowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1079, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.recentFilesToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // recentFilesToolStripMenuItem
            // 
            this.recentFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noRecentFilesToolStripMenuItem});
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.recentFilesToolStripMenuItem.Text = "Recent Files";
            this.recentFilesToolStripMenuItem.Click += new System.EventHandler(this.recentFilesToolStripMenuItem_Click);
            // 
            // noRecentFilesToolStripMenuItem
            // 
            this.noRecentFilesToolStripMenuItem.Enabled = false;
            this.noRecentFilesToolStripMenuItem.Name = "noRecentFilesToolStripMenuItem";
            this.noRecentFilesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.noRecentFilesToolStripMenuItem.Text = "No recent files";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportImageToolStripMenuItem,
            this.exportSVGToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportImageToolStripMenuItem
            // 
            this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
            this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exportImageToolStripMenuItem.Text = "Image";
            this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.pNGToolStripMenuItem_Click);
            // 
            // exportSVGToolStripMenuItem
            // 
            this.exportSVGToolStripMenuItem.Enabled = false;
            this.exportSVGToolStripMenuItem.Name = "exportSVGToolStripMenuItem";
            this.exportSVGToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exportSVGToolStripMenuItem.Text = "SVG";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator4,
            this.openTrackEditorToolStripMenuItem,
            this.openStationEditorToolStripMenuItem,
            this.openConnectionEditorToolStripMenuItem,
            this.toolStripSeparator2,
            this.selectStylesheetToolStripMenuItem,
            this.toolStripSeparator3,
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(240, 6);
            // 
            // openTrackEditorToolStripMenuItem
            // 
            this.openTrackEditorToolStripMenuItem.Name = "openTrackEditorToolStripMenuItem";
            this.openTrackEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.openTrackEditorToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.openTrackEditorToolStripMenuItem.Text = "Open Segment Editor";
            this.openTrackEditorToolStripMenuItem.Click += new System.EventHandler(this.openTrackEditorToolStripMenuItem_Click);
            // 
            // openStationEditorToolStripMenuItem
            // 
            this.openStationEditorToolStripMenuItem.Name = "openStationEditorToolStripMenuItem";
            this.openStationEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.openStationEditorToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.openStationEditorToolStripMenuItem.Text = "Open Station Editor";
            this.openStationEditorToolStripMenuItem.Click += new System.EventHandler(this.openStationEditorToolStripMenuItem_Click);
            // 
            // openConnectionEditorToolStripMenuItem
            // 
            this.openConnectionEditorToolStripMenuItem.Name = "openConnectionEditorToolStripMenuItem";
            this.openConnectionEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.openConnectionEditorToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.openConnectionEditorToolStripMenuItem.Text = "Open Connection Editor";
            this.openConnectionEditorToolStripMenuItem.Click += new System.EventHandler(this.openConnectionEditorToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(240, 6);
            // 
            // selectStylesheetToolStripMenuItem
            // 
            this.selectStylesheetToolStripMenuItem.Name = "selectStylesheetToolStripMenuItem";
            this.selectStylesheetToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.selectStylesheetToolStripMenuItem.Text = "Select Stylesheet";
            this.selectStylesheetToolStripMenuItem.Click += new System.EventHandler(this.selectStylesheetToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(240, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.createToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.toolStripSeparator6,
            this.addIconsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.createToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Enabled = false;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(135, 6);
            // 
            // addIconsToolStripMenuItem
            // 
            this.addIconsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFIleToolStripMenuItem,
            this.searchOnlineToolStripMenuItem});
            this.addIconsToolStripMenuItem.Name = "addIconsToolStripMenuItem";
            this.addIconsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.addIconsToolStripMenuItem.Text = "Add Icons";
            // 
            // fromFIleToolStripMenuItem
            // 
            this.fromFIleToolStripMenuItem.Name = "fromFIleToolStripMenuItem";
            this.fromFIleToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.fromFIleToolStripMenuItem.Text = "From File";
            this.fromFIleToolStripMenuItem.Click += new System.EventHandler(this.fromFIleToolStripMenuItem_Click);
            // 
            // searchOnlineToolStripMenuItem
            // 
            this.searchOnlineToolStripMenuItem.Name = "searchOnlineToolStripMenuItem";
            this.searchOnlineToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.searchOnlineToolStripMenuItem.Text = "Search Online";
            this.searchOnlineToolStripMenuItem.Click += new System.EventHandler(this.searchOnlineToolStripMenuItem_Click);
            // 
            // wIndowsToolStripMenuItem
            // 
            this.wIndowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linesToolStripMenuItem,
            this.stationsToolStripMenuItem,
            this.segmentsOverviewToolStripMenuItem});
            this.wIndowsToolStripMenuItem.Name = "wIndowsToolStripMenuItem";
            this.wIndowsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.wIndowsToolStripMenuItem.Text = "View";
            // 
            // linesToolStripMenuItem
            // 
            this.linesToolStripMenuItem.Name = "linesToolStripMenuItem";
            this.linesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.linesToolStripMenuItem.Text = "Lines Overview";
            this.linesToolStripMenuItem.Click += new System.EventHandler(this.linesToolStripMenuItem_Click);
            // 
            // stationsToolStripMenuItem
            // 
            this.stationsToolStripMenuItem.Name = "stationsToolStripMenuItem";
            this.stationsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.stationsToolStripMenuItem.Text = "Stations Overview";
            this.stationsToolStripMenuItem.Click += new System.EventHandler(this.stationsToolStripMenuItem_Click);
            // 
            // segmentsOverviewToolStripMenuItem
            // 
            this.segmentsOverviewToolStripMenuItem.Name = "segmentsOverviewToolStripMenuItem";
            this.segmentsOverviewToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.segmentsOverviewToolStripMenuItem.Text = "Segments Overview";
            this.segmentsOverviewToolStripMenuItem.Click += new System.EventHandler(this.segmentsOverviewToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportIssueToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // reportIssueToolStripMenuItem
            // 
            this.reportIssueToolStripMenuItem.Name = "reportIssueToolStripMenuItem";
            this.reportIssueToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.reportIssueToolStripMenuItem.Text = "Report Issue";
            this.reportIssueToolStripMenuItem.Click += new System.EventHandler(this.reportIssueToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SelectionAnimationTimer
            // 
            this.SelectionAnimationTimer.Enabled = true;
            this.SelectionAnimationTimer.Interval = 1000;
            this.SelectionAnimationTimer.Tick += new System.EventHandler(this.SelectionAnimationTimer_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSelect,
            this.toolStation,
            this.toolConnect,
            this.toolComboLines,
            this.toolStripButton4,
            this.toolStripSeparator5,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator7,
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1079, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSelect
            // 
            this.toolSelect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolSelect.Image")));
            this.toolSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelect.Name = "toolSelect";
            this.toolSelect.Size = new System.Drawing.Size(23, 22);
            this.toolSelect.Text = "toolStripButton1";
            this.toolSelect.ToolTipText = "Select Mode";
            this.toolSelect.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStation
            // 
            this.toolStation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStation.Image = ((System.Drawing.Image)(resources.GetObject("toolStation.Image")));
            this.toolStation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStation.Name = "toolStation";
            this.toolStation.Size = new System.Drawing.Size(23, 22);
            this.toolStation.Text = "toolStripButton2";
            this.toolStation.ToolTipText = "Create Mode";
            this.toolStation.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolConnect
            // 
            this.toolConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolConnect.Enabled = false;
            this.toolConnect.Image = ((System.Drawing.Image)(resources.GetObject("toolConnect.Image")));
            this.toolConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolConnect.Name = "toolConnect";
            this.toolConnect.Size = new System.Drawing.Size(23, 22);
            this.toolConnect.Text = "toolStripButton3";
            this.toolConnect.ToolTipText = "Connect Mode";
            this.toolConnect.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolComboLines
            // 
            this.toolComboLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolComboLines.Name = "toolComboLines";
            this.toolComboLines.Size = new System.Drawing.Size(121, 25);
            this.toolComboLines.SelectedIndexChanged += new System.EventHandler(this.comboLines_SelectedIndexChanged);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Add Line";
            this.toolStripButton4.ToolTipText = "Add Line";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Undo";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Redo";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // DockPanel
            // 
            this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPanel.Location = new System.Drawing.Point(0, 49);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(1079, 640);
            this.DockPanel.TabIndex = 9;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Toggle grid";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click_2);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Toggle grid in x-direction";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click_1);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Toggle grid in y-direction";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 689);
            this.Controls.Add(this.DockPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "NetworX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private WeifenLuo.WinFormsUI.Docking.DockPane dockPane;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wIndowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTrackEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openStationEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSVGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem segmentsOverviewToolStripMenuItem;
        private System.Windows.Forms.Timer SelectionAnimationTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectStylesheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noRecentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSelect;
        private System.Windows.Forms.ToolStripButton toolStation;
        private System.Windows.Forms.ToolStripButton toolConnect;
        private System.Windows.Forms.ToolStripComboBox toolComboLines;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem addIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConnectionEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
    }
}

