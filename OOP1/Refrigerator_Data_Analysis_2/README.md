# Home Appliances Store – Refrigerator Inventory Analysis

A C# console application designed to analyze refrigerator inventory data for the store **"Viskas Namams"** to help students select an ideal refrigerator for dormitory rooms based on capacity, mounting type, and pricing.

---

## Problem Overview

Moving into a dormitory requires finding an efficient, budget-friendly freestanding refrigerator. This application reads inventory records, performs specific
filter queries, and outputs key findings to both the console and a standalone CSV report file.

### Dataset Attributes
The input CSV files (`Duomenys1.csv`, `Duomenys2.csv`, etc.) store the following details for each refrigerator:
* **Manufacturer** (`string`)
* **Model** (`string`)
* **Capacity** (liters, `int`)
* **Energy Class** (`string`)
* **Mounting Type** (e.g., Freestanding / Built-in, `string`)
* **Color** (`string`)
* **Has Freezer** (`bool`)
* **Price** (EUR, `double`)
* **Height, Width, Depth** (cm, `double`)

---

##  Program Functionality

1. **Siemens Model Counter:** Counts distinct refrigerator models manufactured by **Siemens** and prints the result to the console.
2. **Cheapest Freestanding Filter:** Identifies all freestanding refrigerators with a total capacity of **$\ge 80$ liters** that match the lowest available price. Displays Manufacturer, Model, Capacity, and Price.
3. **Data Export:** Filters all freestanding refrigerators with a capacity of **$\ge 80$ liters** and exports the complete records to `Pastatomi80.csv`.

---


## How to Run

1. Open `Lab1.Exercises.U1-10.sln` in **Visual Studio**.
2. Open **`Program.cs`** and locate the `Main` method. If needed, change the dataset file name in the code below to switch between input files (`Duomenys1.csv`, `Duomenys2.csv`, etc.):
   ```csharp
   List<Fridge> fridges = InOutUtils.ReadFridge("Duomenys1.csv");
3. Press `Ctrl + F5` to run without debugging.