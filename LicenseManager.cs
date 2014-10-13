using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RulePad
{
    public partial class LicenseManager : Form
    {
        public LicenseManager()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ofdOpenLicenseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // load license text for review/edit
                rtbLicenseEditor.LoadFile(ofdOpenLicenseFile.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfdSaveLicenseFile.ShowDialog();
        }

        private void addToScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add license to list of licenses to prefix to output scripts
        }
    }
}
