using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RulePad
{
    public partial class LicenseManager : Form
    {
        private List<LicenseInfo> m_licenseList;
        private List<String> m_useList;
        private String m_fullLicenseText;
        private Settings m_settings;

        public LicenseManager()
        {

            InitializeComponent();
            m_settings = null;
            m_licenseList = new List<LicenseInfo>();
            m_fullLicenseText = "";
            m_useList = new List<String>();
        }

        public Settings AppSettings
        {
            get
            {
                return m_settings;
            }
            set
            {
                m_settings = value;
            }
        }

        public String GetLicenseText()
        {
            foreach( String lic in m_useList )
            {
                LicenseInfo license = FindLicense(lic);
                if( license != null )
                {
                    m_fullLicenseText += license.LicenseText;
                }
            }

            return m_fullLicenseText;
        }

        private LicenseInfo FindLicense(String name)
        {
            foreach( LicenseInfo lInfo in m_licenseList )
            {
                if (name == lInfo.Name)
                    return lInfo;
            }

            return null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ofdOpenLicenseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // load license text for review/edit
                rtbLicenseEditor.LoadFile(ofdOpenLicenseFile.FileName);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbLicenseEditor.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfdSaveLicenseFile.ShowDialog();
        }

        private void addToScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add license to list of licenses to prefix to output scripts
            String name = tscbLicenseList.Items[tscbLicenseList.SelectedIndex].ToString();
            if( name != null )
                m_useList.Add(name);
        }

        private void removeFromScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // remove from use list
            String name = tscbUseLicenses.Items[tscbUseLicenses.SelectedIndex].ToString();
            if (name != null)
            {
                foreach( String lic in m_useList )
                {
                    if ( name == lic )
                    {
                        m_useList.Remove(name);
                    }
                }
            }
        }

        private void doneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseManager.ActiveForm.Hide();
        }

        private void UpdateLicenseText()
        {
            foreach( LicenseInfo lInfo in m_licenseList )
            {
                m_fullLicenseText += lInfo.LicenseText + Environment.NewLine;
            }
        }

        private void LicenseManager_Shown(object sender, EventArgs e)
        {
            tscbLicenseList.Items.Clear();
            foreach( LicenseInfo lInfo in m_licenseList )
            {
                tscbLicenseList.Items.Add(lInfo.Name);
            }
        }

        private void saveUseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save list
            
        }
    }
}
