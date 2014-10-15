using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RulePad
{
    public class LicenseInfo
    {
        private String m_fileName;
        private String m_LicenseName;
        private List<String> m_licenseText;
        private String m_fullText;
        private bool m_plainText;

        public LicenseInfo()
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

        public String Name
        {
            get
            {
                return m_LicenseName;
            }
        }

        public bool IsPlainText
        {
            get
            {
                return m_plainText;
            }
        }

        public List<String> LicenseTextLines
        {
            get
            {
                return m_licenseText;
            }
        }

        public String LicenseText
        {
            get
            {
                return m_fullText;
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
            if (success)
            {
                m_LicenseName = StripFileName(fileName, false);
                UpdateFullText();
            }
        }

        private bool LoadRTF()
        {
            Clear();
            RichTextBox rtb = new RichTextBox();
            rtb.LoadFile(m_fileName);
            for(int i = 0; i < rtb.Lines.GetLength(0); i++)
            {
                Add(rtb.Lines[i]);
            }
            return true;
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

        private void UpdateFullText()
        {
            m_fullText = "";
            foreach( String line in m_licenseText )
            {
                // add comment and newline strings to text line
                if (line == "")
                    m_fullText += Environment.NewLine;
                else
                    m_fullText += "// " + line + Environment.NewLine;
            }
        }

        private String StripFileName(String name, bool stripExt)
        {
            int slashIndex = 0;
            int dotIndex = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i].ToString() == "\\")
                    slashIndex = i + 1;
            }
            if (stripExt)
            {
                for (int j = 0; j < name.Length; j++)
                {
                    if (name[j].ToString() == ".")
                        dotIndex = j;
                }
            }
            else
                dotIndex = name.Length;
            return name.Substring(slashIndex, dotIndex - slashIndex);
        }
    }
}
