using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RulePad
{
    public class Settings
    {
        private String m_settingsPath;
        private String m_listsPath;
        private String m_licensePath;

        public String ListPath
        {
            get
            {
                return m_listsPath;
            }
        }
        public String LicensePath
        {
            get
            {
                return m_licensePath;
            }
            set
            {
                m_licensePath = value;
            }
        }
        
        public Settings()
        {
            String myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            m_settingsPath = myDocPath + "\\RulePad";
            m_listsPath = m_settingsPath + "\\Lists";
            m_licensePath = m_settingsPath + "\\Licenses";
        }

        public List<String> GetLicenseLists()
        {
            List<String> licenseLists = new List<String>();
            // get a list of all license list files from My Documents/RulePad/Lists
            String myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            IEnumerable<String> myDocFolders = Directory.EnumerateDirectories(myDocPath);

            if ( ! myDocFolders.Contains("RulePad") )
            {
                Directory.CreateDirectory(myDocPath + "\\RulePad");
                Directory.CreateDirectory(myDocPath + "\\RulePad\\Lists");
                Directory.CreateDirectory(myDocPath + "\\RulePad\\Licenses");
            }

            IEnumerable<String> lists = Directory.EnumerateFiles(myDocPath + "\\RulePad\\Lists");

            foreach( String fileName in lists )
            {
                licenseLists.Add(fileName);
            }

            return licenseLists;
        }

        public List<String> GetLicenses()
        {
            List<String> licenses = new List<String>();
            // get a list of all license list files from My Documents/RulePad/Lists
            String myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            IEnumerable<String> myDocFolders = Directory.EnumerateDirectories(myDocPath);

            if (!myDocFolders.Contains("RulePad"))
            {
                Directory.CreateDirectory(myDocPath + "\\RulePad");
                Directory.CreateDirectory(myDocPath + "\\RulePad\\Lists");
                Directory.CreateDirectory(myDocPath + "\\RulePad\\Licenses");
            }

            IEnumerable<String> lists = Directory.EnumerateFiles(myDocPath + "\\RulePad\\Licenses");

            foreach (String fileName in lists)
            {
                licenses.Add(fileName);
            }

            return licenses;
        }
    }
}
