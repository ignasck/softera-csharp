# Softera Baltic - Programming Assignment Solution 🚀

A clean-code C# (.NET) console application built as a technical assignment for the selection process at **UAB Softera Baltic**. The system processes, validates, and analyzes game participation and scoring data, delivering comprehensive analytics.

---

## ✨ Features

- **Automated Data Processing** — Reads, parses, and processes structured participant files (`.txt`) using robust I/O streams.
- **Strict Business Logic Validation** — Implements validation checks (minimum participant counts and valid category thresholds) to ensure data integrity.
- **Edge Case Management** — Automatically detects scenarios where multiple game categories score identical maximum or minimum total points, returning all tied results cleanly formatted.
- **Clean Architectural Separation** — Follows the **Single Responsibility Principle (SRP)**, dividing data structures, file management, and core calculations into separate testable modules.
- **Unit Test Suite** — Covers all critical path calculations, edge cases, and boundary inputs.

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Language | C# 12 |
| Framework | .NET 8.0 |
| IDE | Visual Studio 2022 |
| Testing | MSTest |
| Test Runner | Visual Studio Test Explorer |

---

## 📂 Project Structure

```
├── softera-task.sln            # Visual Studio Solution file
├── SolutionProject/            # Main Application Project
│   ├── Program.cs              # Application entry point and execution flow
│   ├── Data.cs                 # Participant data structures and models
│   ├── InOut.cs                # File I/O stream management (Read/Write)
│   ├── TaskUtils.cs            # Core business logic and calculations
│   └── homeworkT.csproj        # C# Project configuration
└── TestProject/                # Automated Test Suite
    ├── LogicTests.cs           # Unit Tests for TaskUtils and boundary conditions
    └── TestProject.csproj      # Test Project configuration
```

---

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK or newer
- Visual Studio 2022 with the *.NET desktop development* workload

### 1. Clone the Repository

```bash
git clone https://github.com/ignasck/softera-task.git
```

### 2. Build the Solution

Open `softera-task.sln` in Visual Studio 2022 and press `Ctrl + Shift + B`.

### 3. Run the Application

Press `Ctrl + F5`. The application will process the input files and generate the report in `results.txt`.

### 4. Run Unit Tests

Open Test Explorer (`Ctrl + R, T`) and click **Run All**.

---

## 📜 Assignment Context & Results

The application outputs analytical results containing:

1. Complete point totals per game category across all input variants.
2. Formatted reports separating valid outcomes from invalid ones.
3. Defensive validation that filters out corrupted or insufficient input before processing.

---

## 🔮 Future Improvements

- **Database Persistence** — Migrate from flat `.txt` files to a relational database using Entity Framework Core.
- **Web Dashboard** — Build a Blazor or React frontend to display game statistics visually.
- **Dockerization** — Containerize the application for automated deployment.

---

*Developed by Ignas 🚀*
