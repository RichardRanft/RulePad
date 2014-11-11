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
        private List<String> m_licenseList;
        private List<String> m_useList;
        private List<LicenseInfo> m_licenses;
        private String m_fullLicenseText;
        private Settings m_settings;

        public LicenseManager()
        {

            InitializeComponent();
            m_settings = null;
            m_licenseList = new List<String>();
            m_licenses = new List<LicenseInfo>();
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
            foreach( LicenseInfo lInfo in m_licenses )
            {
                if (name == lInfo.Name)
                    return lInfo;
            }

            return null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdOpenLicenseFile.InitialDirectory = m_settings.LicensePath;
            if(ofdOpenLicenseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // load license text for review/edit
                if(ofdOpenLicenseFile.FileName.Contains(".txt"))
                    rtbLicenseEditor.LoadFile(ofdOpenLicenseFile.FileName, RichTextBoxStreamType.PlainText);
                else
                    rtbLicenseEditor.LoadFile(ofdOpenLicenseFile.FileName);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbLicenseEditor.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdSaveLicenseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // save
                if (sfdSaveLicenseFile.FileName.Contains(".txt"))
                    rtbLicenseEditor.SaveFile(sfdSaveLicenseFile.FileName, RichTextBoxStreamType.PlainText);
                else
                {
                    sfdSaveLicenseFile.AddExtension = true;
                    rtbLicenseEditor.SaveFile(sfdSaveLicenseFile.FileName);
                }
            }
        }

        private void addToScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add license to list of licenses to prefix to output scripts
            String name = tscbLicenseList.Items[tscbLicenseList.SelectedIndex].ToString();
            if( name != null )
                m_useList.Add(name);

            tscbUseLicenses.Items.Clear();
            foreach(String lic in m_useList)
            {
                tscbUseLicenses.Items.Add(lic);
            }
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

            tscbUseLicenses.Items.Clear();
            foreach (String lic in m_useList)
            {
                tscbUseLicenses.Items.Add(lic);
            }
        }

        private void doneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseManager.ActiveForm.Hide();
        }

        private void UpdateLicenseText()
        {
            foreach( LicenseInfo lInfo in m_licenses )
            {
                m_fullLicenseText += lInfo.LicenseText + Environment.NewLine;
            }
        }

        private void LicenseManager_Shown(object sender, EventArgs e)
        {
            tscbLicenseList.Items.Clear();
            m_licenseList = m_settings.GetLicenses();

            m_licenses.Clear();
            foreach (String licFile in m_licenseList)
            {
                LicenseInfo info = new LicenseInfo();
                info.Load(licFile);
                m_licenses.Add(info);
            }

            foreach( LicenseInfo lInfo in m_licenses )
            {
                tscbLicenseList.Items.Add(lInfo.Name);
            }

            tscbUseLicenses.Items.Clear();
            m_useList = m_settings.GetLicenseLists();
            foreach( String lName in m_useList )
            {
                tscbUseLicenses.Items.Add(lName);
            }

            if(tscbLicenseList.Items.Count > 0)
                tscbLicenseList.SelectedIndex = 0;
            if(tscbUseLicenses.Items.Count > 0)
                tscbUseLicenses.SelectedIndex = 0;
        }

        private void saveUseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save list
            if (sfdSaveLicenseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter useList = new StreamWriter(sfdSaveLicenseFile.FileName))
                {
                    for(int i = 0; i < tscbUseLicenses.Items.Count; i++)
                    {
                        tscbUseLicenses.SelectedIndex = i;
                        useList.WriteLine(tscbUseLicenses.SelectedText);
                    }
                }
            }
        }

        private void openUseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open list

            if (ofdOpenLicenseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader useList = new StreamReader(ofdOpenLicenseFile.FileName))
                {
                    tscbUseLicenses.Items.Add(useList.ReadLine());
                }
            }
        }

        private void tscbLicenseList_Click(object sender, EventArgs e)
        {

        }
    }
}
