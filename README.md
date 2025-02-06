# CodeStatTool

🚀 **CodeStatTool** is a sleek and powerful **code statistics tool** built with **WinForms + C#**. It analyzes code lines (KLOC) across multiple programming languages and file types, allowing users to selectively choose which files to include.

## 🔥 Features

✅ **Sleek Black UI** - Terminal-style interface with a black background and green text  
✅ **Multi-language Support** - Analyze C#, C++, Java, Python, JavaScript, SQL, XML, JSP, ASP.NET, and more  
✅ **Customizable Selection** - Checkboxes allow users to select file types for analysis  
✅ **Separate `.sln` and `.csproj` Analysis** - Solution files and C# project files are counted separately  
✅ **Distinguish C# and C# Designer Files** - `C# (.cs)` and `C# Designer (.designer.cs)` are counted separately  
✅ **New Web Technologies Support** - Added support for **JSP, ASP Classic, ASP.NET Web Forms, and ASP.NET Razor**  
✅ **Custom Title Bar** - No standard title bar; the window can be dragged using a panel  
✅ **Real-time Log Output** - Displays processing progress to avoid UI freezing  

---

## 📌 How to Use

### 1️⃣ **Download & Run**

- **Download the latest version** from the **[Releases](https://github.com/Chrono-Divide/CodeStatTool/releases)** page.  
- Extract the ZIP file and run `CodeStatTool.exe`.  

### 2️⃣ **Usage**

1. Click **"Select Folder"** to choose the directory containing the code  
2. Check **the file types** you want to include in the analysis (right panel)  
3. Click **"Generate Statistics"** to start the analysis  
4. Wait for the results and view the report  

---

## 📊 Supported Languages & File Types

| Language / File Type           | Extensions           | Default |
| ------------------------------ | -------------------- | ------- |
| **C# (.cs)**                   | `.cs`                | ✅       |
| **C# Designer (.designer.cs)** | `.designer.cs`       | ✅       |
| **C++ (.cpp, .h, .hpp)**       | `.cpp`, `.h`, `.hpp` | ✅       |
| **Java (.java)**               | `.java`              | ✅       |
| **Python (.py)**               | `.py`                | ✅       |
| **JavaScript (.js)**           | `.js`                | ✅       |
| **TypeScript (.ts)**           | `.ts`                | ✅       |
| **HTML (.html, .htm)**         | `.html`, `.htm`      | ✅       |
| **CSS (.css)**                 | `.css`               | ✅       |
| **SQL (.sql)**                 | `.sql`               | ✅       |
| **XAML (.xaml)**               | `.xaml`              | ✅       |
| **XML (.xml)**                 | `.xml`               | ❌       |
| **XSD (.xsd)**                 | `.xsd`               | ❌       |
| **Text (.txt)**                | `.txt`               | ❌       |
| **JSON (.json)**               | `.json`              | ❌       |
| **Solution (.sln)**            | `.sln`               | ❌       |
| **C# Project (.csproj)**       | `.csproj`            | ❌       |
| **Config (.config)**           | `.config`            | ❌       |
| **JSP (.jsp)**                 | `.jsp`               | ❌       |
| **ASP Classic (.asp)**         | `.asp`               | ❌       |
| **ASP.NET Web Forms (.aspx)**  | `.aspx`              | ❌       |
| **Razor C# (.cshtml)**         | `.cshtml`            | ❌       |
| **Razor VB (.vbhtml)**         | `.vbhtml`            | ❌       |
| **Blazor (.razor)**            | `.razor`             | ❌       |

💡 **Users can manually select/deselect file types in the `CheckedListBox`!**  

---

## 📜 Sample Output

**Example Output:**

```plaintext
Language (Ext)               Files    Blank  Comment    Code
-------------------------------------------------------------------
C# (.cs)                        10      300      120     1500
C# Designer (.designer.cs)       5      150       60      800
JavaScript (.js)                 8      200       90     1300
ASP.NET Web Forms (.aspx)        3       50       30      400
Razor C# (.cshtml)               2       40       20      300
Solution (.sln)                  1       10        0       50
-------------------------------------------------------------------
SUM:                            29      750      320     4350
```
