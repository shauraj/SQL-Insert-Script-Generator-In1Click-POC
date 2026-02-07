
# SQL Insert Script Generator – In 1 Click (POC)

![GitHub Repo stars](https://img.shields.io/github/stars/shauraj/SQL-Insert-Script-Generator-In1Click-POC?style=social)
![GitHub forks](https://img.shields.io/github/forks/shauraj/SQL-Insert-Script-Generator-In1Click-POC?style=social)
![GitHub issues](https://img.shields.io/github/issues/shauraj/SQL-Insert-Script-Generator-In1Click-POC)
![License](https://img.shields.io/badge/license-MIT-blue.svg)

A lightweight utility designed for developers working in **restricted database environments** where **backup permissions are not available**.

This tool allows you to **generate SQL INSERT scripts for up to 50 tables in one click**, including **table-level filter criteria**, enabling faster debugging, data migration, and environment synchronization.

---

## 🚀 Why This Tool?

In many enterprise projects:

- Developers do not have access to database backups
- Only filtered subsets of data are required
- Manual script creation is slow and error-prone
- Up-To 50 Tables Insert Script In1Click 

This POC solves the problem by automatically generating **ready-to-run INSERT scripts** without requiring backup access.

---

## ✨ Key Features

- One-click INSERT script generation
- Supports **up to 50 tables**
- Table-level WHERE clause support
- Works in restricted-access environments
- Lightweight, extensible POC
- Ideal for enterprise SQL Server workflows

---
## 🚀 Demo

![Demo animation](./Docs/demo/demo.gif)

---

---

## 🖼️ Screenshots
```
/Docs/images/ui-1.png
/Docs/images/ui-2.png
/Docs/images/ui-3.png
/Docs/images/ui-4.png
/Docs/images/ui-5.png
/Docs/images/ui-6.png
```

---

## ⚙️ How It Works

1. Configure database connection
2. Select tables (up to 50)
3. Define optional filter criteria per table
4. Click **Generate SQL**
5. Execute the generated script in the target database

---

## 📌 Use Cases

- Moving filtered production data to UAT/QA
- Debugging production-only issues
- Sharing test datasets securely
- Creating repeatable data migration scripts
- Preparing controlled test data

---

## 🚀 Getting Started

```bash
git clone https://github.com/shauraj/SQL-Insert-Script-Generator-In1Click-POC.git
cd SQL-Insert-Script-Generator-In1Click-POC
```

Configure your database connection and start generating INSERT scripts.

---

## 🧱 Architecture (High Level)

```
UI / Input
   ↓
Table & Filter Processor
   ↓
SQL Script Generator
   ↓
Executable INSERT Script
```

---

## 🔮 Roadmap

- Support for 100+ tables
- Export scripts to `.sql`
- Performance optimizations
- Multi-database support
- Cloud & CI/CD integration

---

## 🤝 Contributing

Contributions are welcome!
Open issues, suggest enhancements, or submit pull requests.

---

## ⭐ Support the Project

If this tool helps you, please **star ⭐ the repository** and share it with your network.

---

## 🔗 Repository

https://github.com/shauraj/SQL-Insert-Script-Generator-In1Click-POC
