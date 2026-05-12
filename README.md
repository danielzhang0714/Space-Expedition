# Space Expedition Artifact Manager

## Overview

**Space Expedition Artifact Manager** is a C# console application that manages a collection of space artifacts stored in text files. The program reads artifact data from a main vault file, decodes encrypted artifact names, sorts the decoded artifact list, allows users to add new artifacts, and saves expedition activity summaries.

This project was built to practice file handling, arrays, sorting, searching, recursion, and menu-driven console application design in C#.

---

## Tech Stack

- **Language:** C#
- **Framework:** .NET Console Application
- **Core Concepts:**
  - File I/O
  - Arrays
  - Dynamic array resizing
  - Recursive methods
  - Custom decoding logic
  - Sorting
  - Binary search
  - Ordered insertion
  - Exception handling

---

## Features

- Reads artifact data from `galactic_vault.txt`
- Stores artifact information including:
  - Encoded artifact name
  - Planet
  - Discovery date
  - Storage location
  - Description
- Decodes artifact names using a custom recursive decoding system
- Sorts decoded artifact names
- Adds new artifacts from separate `.txt` files
- Prevents duplicate artifacts using binary search
- Displays all artifact information in the console
- Saves expedition activity records to `expedition_summary.txt`

---

## Screenshots

### Main Menu

```text
=== Space Expedition Menu ===
1. Add new artifact
2. Show all artifacts
3. Save summary
4. Save and Exit
