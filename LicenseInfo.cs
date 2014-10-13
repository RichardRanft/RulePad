using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulePad
{
    class LicenseInfo
    {
        private String m_fileName;
        private List<String> m_licenseText;
        private bool m_plainText;

        LicenseInfo()
        {
            m_fileName = "";
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
                m_fileName = value;
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
    }
}
