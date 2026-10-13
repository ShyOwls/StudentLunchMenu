# Student Lunch Menu

[![Build](https://github.com/ShyOwls/StudentLunchMenu/actions/workflows/build.yml/badge.svg)](https://github.com/ShyOwls/StudentLunchMenu/actions/workflows/build.yml)

A small Windows Forms app (C#, .NET 8) for building a student's school lunch order.

<!-- Add a screenshot here: ![Screenshot](docs/screenshot.png) -->

## What it does

- Enter the student's name.
- Pick one entrée, exactly two vegetables, one drink, and one fruit or dessert.
- **Submit** shows a summary of the order. If anything is missing, it lists what still needs to be filled in.
- **Clear** resets the form.

Selecting a third vegetable is blocked with a warning.

## Concepts practiced

- Radio buttons vs. checkboxes for single and multiple choice
- Grouping controls with `GroupBox` and reading them with LINQ (`OfType<T>()`)
- A shared event handler for several controls
- Input validation before processing
- Building output with `StringBuilder`

## Building and running

Requires Windows and the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```
git clone https://github.com/ShyOwls/StudentLunchMenu.git
cd StudentLunchMenu
dotnet run --project StudentLunchMenu
```

Or open `StudentLunchMenu.sln` in Visual Studio 2022 and press F5.

## Project layout

```
StudentLunchMenu.sln
StudentLunchMenu/
  Program.cs              entry point
  frmMain.cs              form logic (validation, submit, clear)
  frmMain.Designer.cs     generated layout
  StudentLunchMenu.csproj
```
