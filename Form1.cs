using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Documents;
using System.IO;
using System.Windows.Data;
using System.Xml;

namespace RulePad
{
    public partial class Form1 : Form
    {
        private Settings m_settings;
        private String m_d20ScriptHeader;
        private String m_scriptHeader;
        private LicenseManager m_licMan;

        public Form1()
        {
            InitializeComponent();
            m_settings = new Settings();
            m_licMan = new LicenseManager();
            m_licMan.AppSettings = m_settings;
            m_scriptHeader = "";
            m_d20ScriptHeader = "//-----------------------------------------------------------------------------" + Environment.NewLine +
                                "// Copyright (c) 2014 Roostertail Games" + Environment.NewLine +
                                "//" + Environment.NewLine +
                                "// Permission is hereby granted, free of charge, to any person obtaining a copy" + Environment.NewLine +
                                "// of this software and associated documentation files (the \"Software\"), to" + Environment.NewLine +
                                "// deal in the Software without restriction, including without limitation the" + Environment.NewLine +
                                "// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or" + Environment.NewLine +
                                "// sell copies of the Software, and to permit persons to whom the Software is" + Environment.NewLine +
                                "// furnished to do so, subject to the following conditions:" + Environment.NewLine +
                                "//" + Environment.NewLine +
                                "// The above copyright notice and this permission notice shall be included in" + Environment.NewLine +
                                "// all copies or substantial portions of the Software." + Environment.NewLine +
                                "//" + Environment.NewLine +
                                "// THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR" + Environment.NewLine +
                                "// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY," + Environment.NewLine +
                                "// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE" + Environment.NewLine +
                                "// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER" + Environment.NewLine +
                                "// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING" + Environment.NewLine +
                                "// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS" + Environment.NewLine +
                                "// IN THE SOFTWARE." + Environment.NewLine +
                                "//-----------------------------------------------------------------------------" + Environment.NewLine +
                                Environment.NewLine +
                                "//OPEN GAME LICENSE Version 1.0a" + Environment.NewLine +
                                "//" + Environment.NewLine +
                                "//The following text is the property of Wizards of the Coast, Inc. and is Copyright " + Environment.NewLine +
                                "//2000 Wizards of the Coast, Inc (\"Wizards\"). All Rights Reserved." + Environment.NewLine +
                                Environment.NewLine +
                                "//1. Definitions: " + Environment.NewLine +
                                "//  (a)\"Contributors\" means the copyright and/or trademark owners who have contributed " + Environment.NewLine +
                                "//Open Game Content; " + Environment.NewLine +
                                "//  (b)\"Derivative Material\" means copyrighted material including derivative works and " + Environment.NewLine +
                                "//translations (including into other computer languages), potation, modification, correction, addition, " + Environment.NewLine +
                                "//extension, upgrade, improvement, compilation, abridgment or other form in which an existing work may be " + Environment.NewLine +
                                "//recast, transformed or adapted; " + Environment.NewLine +
                                "//  (c) \"Distribute\" means to reproduce, license, rent, lease, sell, broadcast, publicly display, transmit " + Environment.NewLine +
                                "//or otherwise distribute; " + Environment.NewLine +
                                "//  (d)\"Open Game Content\" means the game mechanic and includes the methods, procedures, processes and " + Environment.NewLine +
                                "//routines to the extent such content does not embody the Product Identity and is an enhancement over the " + Environment.NewLine +
                                "//prior art and any additional content clearly identified as Open Game Content by the Contributor, and means " + Environment.NewLine +
                                "//any work covered by this License, including translations and derivative works under copyright law, but " + Environment.NewLine +
                                "//specifically excludes Product Identity. " + Environment.NewLine +
                                "//  (e) \"Product Identity\" means product and product line names, logos and identifying marks including trade " + Environment.NewLine +
                                "//dress; artifacts; creatures characters; stories, storylines, plots, thematic elements, dialogue, incidents, " + Environment.NewLine +
                                "//language, artwork, symbols, designs, depictions, likenesses, formats, poses, concepts, themes and graphic, " + Environment.NewLine +
                                "//photographic and other visual or audio representations; names and descriptions of characters, spells, " + Environment.NewLine +
                                "//enchantments, personalities, teams, personas, likenesses and special abilities; places, locations, " + Environment.NewLine +
                                "//environments, creatures, equipment, magical or supernatural abilities or effects, logos, symbols, " + Environment.NewLine +
                                "//or graphic designs; and any other trademark or registered trademark clearly identified as Product identity " + Environment.NewLine +
                                "//by the owner of the Product Identity, and which specifically excludes the Open Game Content; " + Environment.NewLine +
                                "//  (f) \"Trademark\" means the logos, names, mark, sign, motto, designs that are used by a Contributor to identify " + Environment.NewLine +
                                "//itself or its products or the associated products contributed to the Open Game License by the Contributor " + Environment.NewLine +
                                "//  (g) \"Use\", \"Used\" or \"Using\" means to use, Distribute, copy, edit, format, modify, translate and otherwise " + Environment.NewLine +
                                "//create Derivative Material of Open Game Content. " + Environment.NewLine +
                                "//  (h) \"You\" or \"Your\" means the licensee in terms of this agreement." + Environment.NewLine +
                                Environment.NewLine +
                                "//2. The License: This License applies to any Open Game Content that contains a notice indicating that the Open Game " + Environment.NewLine +
                                "//Content may only be Used under and in terms of this License. You must affix such a notice to any Open Game Content " + Environment.NewLine +
                                "//that you Use. No terms may be added to or subtracted from this License except as described by the License itself. " + Environment.NewLine +
                                "//No other terms or conditions may be applied to any Open Game Content distributed using this License." + Environment.NewLine +
                                Environment.NewLine +
                                "//3.Offer and Acceptance: By Using the Open Game Content You indicate Your acceptance of the terms of this License." + Environment.NewLine +
                                Environment.NewLine +
                                "//4. Grant and Consideration: In consideration for agreeing to use this License, the Contributors grant You a perpetual, " + Environment.NewLine +
                                "//worldwide, royalty-free, non-exclusive license with the exact terms of this License to Use, the Open Game Content." + Environment.NewLine +
                                Environment.NewLine +
                                "//5.Representation of Authority to Contribute: If You are contributing original material as Open Game Content, You " + Environment.NewLine +
                                "//represent that Your Contributions are Your original creation and/or You have sufficient rights to grant the rights " + Environment.NewLine +
                                "//conveyed by this License." + Environment.NewLine +
                                Environment.NewLine +
                                "//6.Notice of License Copyright: You must update the COPYRIGHT NOTICE portion of this License to include the exact " + Environment.NewLine +
                                "//text of the COPYRIGHT NOTICE of any Open Game Content You are copying, modifying or distributing, and You must add " + Environment.NewLine +
                                "//the title, the copyright date, and the copyright holder's name to the COPYRIGHT NOTICE of any original Open Game " + Environment.NewLine +
                                "//Content you Distribute." + Environment.NewLine +
                                Environment.NewLine +
                                "//7. Use of Product Identity: You agree not to Use any Product Identity, including as an indication as to compatibility, " + Environment.NewLine +
                                "//except as expressly licensed in another, independent Agreement with the owner of each element of that Product Identity. " + Environment.NewLine +
                                "//You agree not to indicate compatibility or co-adaptability with any Trademark or Registered Trademark in conjunction " + Environment.NewLine +
                                "//with a work containing Open Game Content except as expressly licensed in another, independent Agreement with the owner " + Environment.NewLine +
                                "//of such Trademark or Registered Trademark. The use of any Product Identity in Open Game Content does not constitute a " + Environment.NewLine +
                                "//challenge to the ownership of that Product Identity. The owner of any Product Identity used in Open Game Content shall " + Environment.NewLine +
                                "//retain all rights, title and interest in and to that Product Identity." + Environment.NewLine +
                                Environment.NewLine +
                                "//8. Identification: If you distribute Open Game Content You must clearly indicate which portions of the work that you " + Environment.NewLine +
                                "//are distributing are Open Game Content." + Environment.NewLine +
                                Environment.NewLine +
                                "//9. Updating the License: Wizards or its designated Agents may publish updated versions of this License. You may use " + Environment.NewLine +
                                "//any authorized version of this License to copy, modify and distribute any Open Game Content originally distributed under " + Environment.NewLine +
                                "//any version of this License." + Environment.NewLine +
                                Environment.NewLine +
                                "//10. Copy of this License: You MUST include a copy of this License with every copy of the Open Game Content You Distribute." + Environment.NewLine +
                                Environment.NewLine +
                                "//11. Use of Contributor Credits: You may not market or advertise the Open Game Content using the name of any Contributor " + Environment.NewLine +
                                "//unless You have written permission from the Contributor to do so." + Environment.NewLine +
                                Environment.NewLine +
                                "//12 Inability to Comply: If it is impossible for You to comply with any of the terms of this License with respect to some " + Environment.NewLine +
                                "//or all of the Open Game Content due to statute, judicial order, or governmental regulation then You may not Use any Open " + Environment.NewLine +
                                "//Game Material so affected." + Environment.NewLine +
                                Environment.NewLine +
                                "//13 Termination: This License will terminate automatically if You fail to comply with all terms herein and fail to cure " + Environment.NewLine +
                                "//such breach within 30 days of becoming aware of the breach. All sublicenses shall survive the termination of this License." + Environment.NewLine +
                                Environment.NewLine +
                                "//14 Reformation: If any provision of this License is held to be unenforceable, such provision shall be reformed only to the " + Environment.NewLine +
                                "//extent necessary to make it enforceable." + Environment.NewLine +
                                Environment.NewLine +
                                "//15 COPYRIGHT NOTICE" + Environment.NewLine +
                                "//Open Game License v 1.0 Copyright 2000, Wizards of the Coast, Inc." + Environment.NewLine +
                                Environment.NewLine +
                                "// ----------------------------------------------------------------------------" + Environment.NewLine;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Clear();
                richTextBox1.LoadFile(openFileDialog1.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            exportTable();
        }

        private void exportTable()
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String xamlText = ConvertRtfToXaml(richTextBox1.Rtf);
                List<String> tables = getTables(xamlText);
                String name = "";
                String[] parts;
                foreach (String table in tables)
                {
                    String tsText = parseTableToTorqueScript(table, out name);
                    // figure out how to find tables and export them as TorqueScript data entity
                    //write to temp file
                    parts = saveFileDialog1.FileName.Split('.');
                    writeTorqueScript(parts[0] + "." + name + ".cs", tsText);
                }
            }
        }

        private int getCellCount(String rowText)
        {
            int cellCount = 0;
            int previousIndex = 0;
            int currentIndex = 0;
            while ((currentIndex = rowText.IndexOf("<Run>", previousIndex)) < rowText.Length && currentIndex >= 0)
            {
                previousIndex = currentIndex + 6;
                cellCount++;
            }
            return cellCount;
        }

        private List<String> getCells(String xamlText)
        {
            List<String> cellList = new List<String>();
            int cellCount = getCellCount(xamlText);
            for (int i = 0; i < cellCount; i++)
            {
                cellList.Add(getCell(i, xamlText));
            }
            return cellList;
        }

        private String getCell(int index, String xamlText)
        {
            int cellCount = 0;
            int previousIndex = 0;
            int currentIndex = 0;
            while (cellCount <= index && (currentIndex = xamlText.IndexOf("<Run>", previousIndex)) < xamlText.Length && currentIndex >= 0)
            {
                previousIndex = currentIndex + 6;
                cellCount++;
            }
            int endIndex = xamlText.IndexOf("</Run>", previousIndex) + 6;
            int tableLength = endIndex - currentIndex;
            if (tableLength <= 0 || currentIndex < 0 || endIndex >= xamlText.Length)
                return "";
            return xamlText.Substring(currentIndex, tableLength);
        }

        private int getRowCount(String tableText)
        {
            int rowCount = 0;
            int previousIndex = 0;
            int currentIndex = 0;
            while ((currentIndex = tableText.IndexOf("<TableRow>", previousIndex)) < tableText.Length && currentIndex >= 0)
            {
                previousIndex = currentIndex + 6;
                rowCount++;
            }
            return rowCount;
        }

        private List<String> getRows(String xamlText)
        {
            List<String> rowList = new List<String>();
            int rowCount = getRowCount(xamlText);
            for (int i = 0; i < rowCount; i++)
            {
                rowList.Add(getRow(i, xamlText));
            }
            return rowList;
        }

        private String getRow(int index, String xamlText)
        {
            int tableCount = 0;
            int previousIndex = 0;
            int currentIndex = 0;
            while (tableCount <= index && (currentIndex = xamlText.IndexOf("<TableRow>", previousIndex)) < xamlText.Length && currentIndex >= 0)
            {
                previousIndex = currentIndex + 6;
                tableCount++;
            }
            int endIndex = xamlText.IndexOf("</TableRow>", previousIndex) + 11;
            int tableLength = endIndex - currentIndex;
            return xamlText.Substring(currentIndex, tableLength);
        }

        private int getTableCount(String xamlText)
        {
            int tableCount = 0;
            int previousIndex = 0;
            int currentIndex = 0;
            while ((currentIndex = xamlText.IndexOf("<Table ", previousIndex)) < xamlText.Length && currentIndex >= 0)
            {
                previousIndex = currentIndex + 6;
                tableCount++;
            }
            return tableCount;
        }

        private List<String> getTables(String xamlText)
        {
            List<String> tableList = new List<String>();
            int tableCount = getTableCount(xamlText);
            for (int i = 0; i < tableCount; i++ )
            {
                tableList.Add(getTable(i, xamlText));
            }
            return tableList;
        }

        private String getTable(int index, String xamlText)
        {
            int tableCount = 0;
            int previousIndex = 0;
            int currentIndex = 0;
            while (tableCount <= index && (currentIndex = xamlText.IndexOf("<Table ", previousIndex)) < xamlText.Length && currentIndex >= 0)
            {
                previousIndex = currentIndex + 6;
                tableCount++;
            }
            int endIndex = xamlText.IndexOf("</Table>", previousIndex) + 8;
            int tableLength = endIndex - currentIndex;
            return xamlText.Substring(currentIndex, tableLength);
        }

        private static String ConvertRtfToXaml(String rtfText)
        {
            var richTextBox = new System.Windows.Controls.RichTextBox();
            if (string.IsNullOrEmpty(rtfText)) return "";
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            using (var rtfMemoryStream = new MemoryStream())
            {
                using (var rtfStreamWriter = new StreamWriter(rtfMemoryStream))
                {
                    rtfStreamWriter.Write(rtfText);
                    rtfStreamWriter.Flush();
                    rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                    textRange.Load(rtfMemoryStream, DataFormats.Rtf);
                }
            }
            using (var rtfMemoryStream = new MemoryStream())
            {
                textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                textRange.Save(rtfMemoryStream, System.Windows.DataFormats.Xaml);
                rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                using (var rtfStreamReader = new StreamReader(rtfMemoryStream))
                {
                    return rtfStreamReader.ReadToEnd();
                }
            }
        }

        private String parseTableToTorqueScript(String tableText, out String TableName)
        {
            String scriptText = m_licMan.GetLicenseText();//m_d20ScriptHeader;
            List<String> rows = getRows(tableText);
            String cell1 = rows[0];
            int cellStart = cell1.IndexOf("Run>") + 4;
            int cellEnd = cell1.IndexOf("<", cellStart);
            int length = cellEnd - cellStart;
            if (cellStart < 0 || cellStart >= cell1.Length || cellEnd < 0 || cellEnd >= cell1.Length || cellEnd <= cellStart)
            {
                MessageBox.Show("Error in parsing string: " + Environment.NewLine + "Cell Start: " + cellStart.ToString() + Environment.NewLine + "Cell End: " + cellEnd.ToString() +
                    "Source Length: " + cell1.Length.ToString() + Environment.NewLine + "Substring Length: " + (cellEnd - cellStart).ToString());
                TableName = "";
                return "";
            }
            TableName = stripChars(parseCell(cell1), ':', ' ');
            scriptText += Environment.NewLine + "// Table: " + TableName + Environment.NewLine;
            int startRow = 1;
            if (getCellCount(rows[startRow]) < 2)
                startRow = 2;
            List<String> cells = getCells(rows[startRow]);
            String cellName = "";
            String cellValue = "";
            String row = "";
            String rowText = "";
            for (int i = (startRow + 1); i < rows.Count; i++ )
            {
                row = rows[i];
                
                for (int j = 0; j < cells.Count; j++)
                {
                    cellName = stripChars(parseCell(cells[j]), ' ', ':', '/', '\\');
                    cellValue = parseCell(getCell(j, row)).Trim();
                    rowText = "$" + TableName + "::" + cellName + "[" + (i-2).ToString() + "] = \"" + cellValue + "\";" + Environment.NewLine;
                    scriptText += rowText;
                }
                scriptText += Environment.NewLine;
            }

            return scriptText;
        }

        private String parseCell(String cellText)
        {
            if (cellText.Length < 1)
                return "";
            int cellStart = cellText.IndexOf("Run>") + 4;
            int cellEnd = cellText.IndexOf("<", cellStart);
            int length = cellEnd - cellStart;
            String cell = cellText.Substring(cellStart, length);
            return cell;
        }

        private String stripSpaces(String text)
        {
            String temp = "";
            foreach(char c in text.ToCharArray())
            {
                if (c != ' ')
                {
                    temp += c;
                }
            }
            return temp;
        }

        private String stripChars(String text, params char[] args)
        {
            String temp = "";
            int argc = args.Length;
            bool found = false;
            foreach (char c in text.ToCharArray())
            {
                found = false;
                for (int i = 0; i < argc; i++ )
                {
                    if (c == args[i])
                        found = true;
                }
                if (!found)
                {
                    temp += c;
                }
            }
            return temp;
        }

        private String parseRow(String rowText)
        {
            String rowScript = "";

            return rowScript;
        }

        private void writeTorqueScript(String fileName, String tableText)
        {
            using (StreamWriter fs = new StreamWriter(fileName))
            {
                fs.Write(tableText);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // handle saving changes to the source RTF file here.
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                richTextBox1.SaveFile(saveFileDialog1.FileName);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // figure out how to select and export specific text.  Should be as simple as converting
            // the selected text to XAML and handling it just like the full document.
        }

        private void selectEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_licMan.ShowDialog();
        }
    }
}
