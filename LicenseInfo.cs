using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RulePad
{
    class LicenseInfo
    {
        private String m_fileName;
        private String m_LicenseName;
        private List<String> m_licenseText;
        private bool m_plainText;

        LicenseInfo()
        {
            m_fileName = "";
            m_LicenseName = "";
            m_licenseText = new List<String>();
            m_plainText = false;
        }

        public String FileName
        {
            get
            {
                return m_fileName;
            }
            set
            {
                Load(value);
            }
        }

        public bool IsPlainText
        {
            get
            {
                return m_plainText;
            }
        }

        public List<String> LicenseText
        {
            get
            {
                return m_licenseText;
            }
        }

        public void Clear()
        {
            m_licenseText.Clear();
        }

        public void Add(String textLine)
        {
            m_licenseText.Add(textLine);
        }

        public void Load(String fileName)
        {
            bool success = false;
            m_fileName = fileName;
            if (fileName.Contains(".txt"))
            {
                m_plainText = true;
                success = LoadText();
            }
            else
            {
                m_plainText = false;
                success = LoadRTF();
            }
            if( success )
                m_LicenseName = StripFileName(fileName);
        }

        private bool LoadRTF()
        {
            // not implemented yet
            MessageBox.Show("Direct loading RTF files not yet implemented.", "Not Implemented");
            return false;
        }

        private bool LoadText()
        {
            Clear();
            StreamReader license = null;
            try
            {
                license = new StreamReader(@m_fileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "File Error");
                return false;
            }
            try
            {
                String line;
                while((line = license.ReadLine()) != null)
                {
                    Add(line);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "File Read Error");
                return false;
            }

            return true;
        }

        private String StripFileName(String name)
        {
            int slashIndex = 0;
            int dotIndex = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i].ToString() == "\\")
                    slashIndex = i + 1;
            }
            for (int j = 0; j < name.Length; j++)
            {
                if (name[j].ToString() == ".")
                    dotIndex = j;
            }
            return name.Substring(slashIndex, dotIndex - slashIndex);
        }
    }
}
