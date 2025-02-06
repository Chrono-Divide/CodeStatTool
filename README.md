# CodeStatTool

🚀 **CodeStatTool** is a powerful and visually appealing **code statistics tool** built with **WinForms + C#**. It is designed for **analyzing code lines (KLOC)**, supporting multiple programming languages and file types. The tool allows users to selectively choose which file types to include in the analysis.

## 🔥 Features

✅ **Sleek Black UI** - Terminal-style interface with a black background and green text  
✅ **Multi-language Support** - Analyze C#, C++, Java, Python, JavaScript, SQL, XML, and more  
✅ **Customizable Selection** - Checkboxes allow users to select file types for analysis  
✅ **Separate `.sln` and `.csproj` Analysis** - Solution files and C# project files are counted separately  
✅ **Distinguish C# and C# Designer Files** - `C# (.cs)` and `C# Designer (.designer.cs)` are counted separately  
✅ **Custom Title Bar** - No standard title bar; the window can be dragged using a panel  
✅ **Real-time Log Output** - Displays processing progress to avoid UI freezing  

---

## 🖥️ User Interface Preview

### 🔹 **Main Window**

![screenshot](https://via.placeholder.com/800x400?text=CodeStatTool+UI+Screenshot)

- **Left Side**: Buttons for folder selection and analysis  
- **Middle Section**: Log output area showing progress  
- **Right Side**: **CheckedListBox** for selecting file types to analyze  

---

## 📌 How to Use

### 1️⃣ **Download & Run**

- **Download the latest version** from the **[Releases](https://github.com/YOUR_GITHUB/CodeStatTool/releases)** page.  
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
Solution (.sln)                  1       10        0       50
-------------------------------------------------------------------
SUM:                            24      660      270     3650
```
