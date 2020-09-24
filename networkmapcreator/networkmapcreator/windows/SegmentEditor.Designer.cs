namespace NetworkMapCreator
{
    partial class SegmentEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SegmentEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboLineMode = new System.Windows.Forms.ComboBox();
            this.checkLineLabel = new System.Windows.Forms.CheckBox();
            this.Layout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Line mode";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboLineMode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkLineLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 70);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // comboLineMode
            // 
            this.comboLineMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboLineMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLineMode.FormattingEnabled = true;
            this.comboLineMode.Items.AddRange(new object[] {
            "<dont change>",
            "Straight",
            "Curved",
            "Steps",
            "Wave"});
            this.comboLineMode.Location = new System.Drawing.Point(86, 3);
            this.comboLineMode.Name = "comboLineMode";
            this.comboLineMode.Size = new System.Drawing.Size(164, 21);
            this.comboLineMode.TabIndex = 0;
            this.comboLineMode.SelectedIndexChanged += new System.EventHandler(this.comboLineMode_SelectedIndexChanged);
            // 
            // checkLineLabel
            // 
            this.checkLineLabel.AutoSize = true;
            this.checkLineLabel.Checked = true;
            this.checkLineLabel.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkLineLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkLineLabel.Location = new System.Drawing.Point(6, 35);
            this.checkLineLabel.Margin = new System.Windows.Forms.Padding(6);
            this.checkLineLabel.Name = "checkLineLabel";
            this.checkLineLabel.Size = new System.Drawing.Size(71, 17);
            this.checkLineLabel.TabIndex = 2;
            this.checkLineLabel.Text = "Line label";
            this.checkLineLabel.ThreeState = true;
            this.checkLineLabel.UseVisualStyleBackColor = true;
            this.checkLineLabel.CheckedChanged += new System.EventHandler(this.checkLineLabel_CheckedChanged);
            // 
            // Layout
            // 
            this.Layout.ColumnCount = 1;
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Layout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layout.Enabled = false;
            this.Layout.Location = new System.Drawing.Point(0, 0);
            this.Layout.Name = "Layout";
            this.Layout.RowCount = 1;
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Layout.Size = new System.Drawing.Size(258, 76);
            this.Layout.TabIndex = 12;
            // 
            // SegmentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 76);
            this.Controls.Add(this.Layout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SegmentEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Segment Editor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkLineLabel;
        private System.Windows.Forms.ComboBox comboLineMode;
        private System.Windows.Forms.TableLayoutPanel Layout;
    }
}