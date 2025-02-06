using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeStatTool
{
    public partial class frmMain : Form
    {
        private string selectedFolder = string.Empty;

        // 統計結果字典
        private Dictionary<string, FileStats> statsDict;

        // 自訂標題欄拖動
        private bool isTitleBarDragging = false;
        private Point lastLocation;

        // 垂直拉伸
        private bool isResizing = false;
        private Point resizeStartLocation;
        private int originalHeight;

        // 語言(檔案類型)清單
        private List<LanguageItem> languageConfig;

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 視窗載入時，將可統計的檔案類型/語言加入 CheckedListBox
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            // 這裡用新的命名，顯示在 UI 會帶副檔名，例如 "C# (.cs)"
            // 你可自行微調預設勾選 (DefaultChecked = true / false)
            languageConfig = new List<LanguageItem>()
            {
                new LanguageItem("C# (.cs)",                true, new[] { ".cs" }),
                new LanguageItem("C# Designer (.designer.cs)", true, new[] { ".designer.cs" }),
                new LanguageItem("C/C++ (.cpp/.h/.hpp)",    true, new[] { ".cpp", ".h", ".hpp" }),
                new LanguageItem("HTML (.htm/.html)",       true, new[] { ".html", ".htm" }),
                new LanguageItem("CSS (.css)",              true, new[] { ".css" }),
                new LanguageItem("JavaScript (.js)",        true, new[] { ".js" }),
                new LanguageItem("TypeScript (.ts)",        true, new[] { ".ts" }),
                new LanguageItem("Python (.py)",            true, new[] { ".py" }),
                new LanguageItem("Java (.java)",            true, new[] { ".java" }),
                new LanguageItem("PHP (.php)",              true, new[] { ".php" }),
                new LanguageItem("VB.NET (.vb)",            true, new[] { ".vb" }),
                new LanguageItem("SQL (.sql)",              true, new[] { ".sql" }),
                new LanguageItem("XAML (.xaml)",            true, new[] { ".xaml" }),
                new LanguageItem("XML (.xml)",              false,new[] { ".xml" }), // 預設不勾選
                new LanguageItem("XSD (.xsd)",              false,new[] { ".xsd" }),
                new LanguageItem("Text (.txt)",             false,new[] { ".txt" }),
                new LanguageItem("JSON (.json)",            false,new[] { ".json" }),
                // 分開顯示Solution和C# Project
                new LanguageItem("Solution (.sln)",         false,new[] { ".sln" }),
                new LanguageItem("C# Project (.csproj)",    false,new[] { ".csproj" }),
                // 其他
                new LanguageItem("Config (.config)",        false,new[] { ".config" }),
            };

            // 加入 CheckedListBox
            foreach (var lang in languageConfig)
            {
                clbLanguages.Items.Add(lang.LanguageName, lang.DefaultChecked);
            }
        }

        #region 自定義標題欄拖動
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isTitleBarDragging = true;
                lastLocation = e.Location;
            }
        }

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isTitleBarDragging)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y
                );
                this.Update();
            }
        }

        private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isTitleBarDragging = false;
            }
        }
        #endregion

        #region 垂直拉伸
        private void panelResize_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isResizing = true;
                resizeStartLocation = e.Location;
                originalHeight = this.Height;
            }
        }

        private void panelResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                int delta = e.Y - resizeStartLocation.Y;
                this.Height = originalHeight + delta;
                this.Update();
            }
        }

        private void panelResize_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isResizing = false;
            }
        }
        #endregion

        #region 按鈕事件
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select a folder to analyze:";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedFolder = fbd.SelectedPath;
                    lblSelectedFolder.Text = $"Selected Folder: {selectedFolder}";
                }
            }
        }

        private void btnGenerateStats_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolder) || !Directory.Exists(selectedFolder))
            {
                MessageBox.Show("Please select a valid folder first.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtOutput.Clear();
            statsDict = new Dictionary<string, FileStats>(StringComparer.OrdinalIgnoreCase);

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(selectedFolder);
            }
        }
        #endregion

        #region BackgroundWorker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string folderPath = (string)e.Argument;
            var allFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            backgroundWorker1.ReportProgress(0, $"Found {allFiles.Length} files in total.\r\n");

            // 收集使用者勾選的語言顯示名
            List<string> checkedLangs = new List<string>();
            this.Invoke((MethodInvoker)delegate
            {
                foreach (var item in clbLanguages.CheckedItems)
                {
                    checkedLangs.Add(item.ToString());
                }
            });

            for (int i = 0; i < allFiles.Length; i++)
            {
                var file = allFiles[i];
                backgroundWorker1.ReportProgress(
                    (int)((i + 1) / (float)allFiles.Length * 100),
                    $"Processing file {i + 1}/{allFiles.Length}: {Path.GetFileName(file)}\r\n"
                );

                // 判斷檔案屬於哪個語言(檔案類型)
                string language = DetermineLanguage(file);
                if (language == null)
                    continue; // 不在支援清單 => skip

                // 檢查是否在使用者勾選清單
                if (!checkedLangs.Contains(language))
                    continue;

                if (!statsDict.ContainsKey(language))
                {
                    statsDict[language] = new FileStats();
                }

                statsDict[language].FileCount++;

                CountLines(file, language, out int blank, out int comment, out int code);
                statsDict[language].BlankLines += blank;
                statsDict[language].CommentLines += comment;
                statsDict[language].CodeLines += code;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is string logMessage)
            {
                txtOutput.AppendText(logMessage);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtOutput.AppendText("\r\nAnalysis completed.\r\n\r\n");

            if (statsDict == null || statsDict.Count == 0)
            {
                txtOutput.AppendText("No statistics found.\r\n");
                return;
            }

            // 輸出對齊表格
            string result = GenerateOutputText(statsDict);
            txtOutput.AppendText(result);
        }
        #endregion

        /// <summary>
        /// 將檔案副檔名對應到我們 languageConfig 中的顯示名稱
        /// </summary>
        private string DetermineLanguage(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            string fileName = Path.GetFileName(filePath).ToLower();

            // 若帶有 .designer.cs 結尾 => 視為 "C# Designer (.designer.cs)"
            if (fileName.EndsWith(".designer.cs"))
            {
                var designerItem = languageConfig
                    .FirstOrDefault(x => x.LanguageName.Equals("C# Designer (.designer.cs)"));
                if (designerItem != null)
                    return designerItem.LanguageName;
            }

            // 一般情況：判斷 ext 是否出現在 languageConfig 的 Extensions 裡
            foreach (var lang in languageConfig)
            {
                if (lang.Extensions.Contains(ext))
                {
                    return lang.LanguageName;
                }
            }

            return null; // 不支援此檔案
        }

        /// <summary>
        /// 依語言(檔案類型)簡易判斷空行、註釋行、程式碼行
        /// </summary>
        private void CountLines(string filePath, string language,
            out int blankLines, out int commentLines, out int codeLines)
        {
            blankLines = 0;
            commentLines = 0;
            codeLines = 0;

            bool inBlockComment = false;
            var lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                {
                    blankLines++;
                    continue;
                }

                // 針對有 // 或 /*...*/ 的語言 
                if (language.StartsWith("C#") ||
                    language.StartsWith("C/C++") ||
                    language.StartsWith("Java (") ||  // "Java (.java)"
                    language.StartsWith("JavaScript (") ||
                    language.StartsWith("TypeScript (") ||
                    language.StartsWith("PHP (") ||
                    language.StartsWith("VB.NET ("))
                {
                    // 簡化C系註釋
                    if (inBlockComment)
                    {
                        commentLines++;
                        if (line.Contains("*/"))
                        {
                            inBlockComment = false;
                        }
                    }
                    else
                    {
                        if (line.StartsWith("//"))
                        {
                            commentLines++;
                        }
                        else if (line.StartsWith("/*") && !line.Contains("*/"))
                        {
                            commentLines++;
                            inBlockComment = true;
                        }
                        else if (line.StartsWith("/*") && line.Contains("*/"))
                        {
                            commentLines++;
                        }
                        else
                        {
                            codeLines++;
                        }
                    }
                }
                else if (language.StartsWith("HTML (")
                      || language.StartsWith("XML (")
                      || language.StartsWith("XAML (")
                      || language.StartsWith("XSD (")
                      || language.StartsWith("SQL ("))
                {
                    // 簡易判斷 <!-- ... -->
                    if (inBlockComment)
                    {
                        commentLines++;
                        if (line.Contains("-->"))
                        {
                            inBlockComment = false;
                        }
                    }
                    else
                    {
                        if (line.StartsWith("<!--") && !line.Contains("-->"))
                        {
                            commentLines++;
                            inBlockComment = true;
                        }
                        else if (line.StartsWith("<!--") && line.Contains("-->"))
                        {
                            commentLines++;
                        }
                        else
                        {
                            codeLines++;
                        }
                    }
                }
                else
                {
                    // 例如 .txt, .json, .sln, .csproj, .config 等 -> 無註釋，全部非空行當 code
                    codeLines++;
                }
            }
        }

        /// <summary>
        /// 輸出對齊的表格 (Language, Files, Blank, Comment, Code)
        /// </summary>
        private string GenerateOutputText(Dictionary<string, FileStats> stats)
        {
            string headerFormat = "{0,-30} {1,6} {2,8} {3,8} {4,8}";
            // 語言列寬擴大一點(30) 以免顯示不全

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(headerFormat, "Language (Ext)", "Files", "Blank", "Comment", "Code"));
            sb.AppendLine("-------------------------------------------------------------------");

            int totalFiles = 0;
            int totalBlank = 0;
            int totalComment = 0;
            int totalCode = 0;

            var sortedKeys = stats.Keys.OrderBy(k => k);
            foreach (var key in sortedKeys)
            {
                var fs = stats[key];
                totalFiles += fs.FileCount;
                totalBlank += fs.BlankLines;
                totalComment += fs.CommentLines;
                totalCode += fs.CodeLines;

                sb.AppendLine(
                    string.Format(headerFormat,
                        key,
                        fs.FileCount,
                        fs.BlankLines,
                        fs.CommentLines,
                        fs.CodeLines
                    )
                );
            }

            sb.AppendLine("-------------------------------------------------------------------");
            sb.AppendLine(
                string.Format(headerFormat,
                    "SUM:",
                    totalFiles,
                    totalBlank,
                    totalComment,
                    totalCode
                )
            );

            return sb.ToString();
        }
    }

    /// <summary>
    /// 儲存每種語言(檔案類型)的行數統計
    /// </summary>
    public class FileStats
    {
        public int FileCount { get; set; }
        public int BlankLines { get; set; }
        public int CommentLines { get; set; }
        public int CodeLines { get; set; }
    }

    /// <summary>
    /// 用於配置語言顯示名稱、預設勾選狀態、對應副檔名
    /// </summary>
    public class LanguageItem
    {
        public string LanguageName { get; set; }
        public bool DefaultChecked { get; set; }
        public string[] Extensions { get; set; }

        public LanguageItem(string name, bool defChecked, string[] exts)
        {
            LanguageName = name;
            DefaultChecked = defChecked;
            Extensions = exts;
        }
    }
}
