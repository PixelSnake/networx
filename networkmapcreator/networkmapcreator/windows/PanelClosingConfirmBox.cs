using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator.Windows
{
    public partial class PanelClosingConfirmBox : Form
    {
        public PanelClosingConfirmBox()
        {
            InitializeComponent();
        }

        public PanelClosingConfirmBox(string title)
        {
            InitializeComponent();
            Text = title;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void PanelClosingConfirmBox_Activated(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}