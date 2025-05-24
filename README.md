# Template WPF Project

## This project is

- Based on the Visual Studio WPF template
- Using .NET 9
- Using a setup where projects are stored outside of the top-level `.sln` file

## This template has the following...

### NuGet Packages

> **NOTE: these should be updated before use of this template**

#### App project

- `CommunityToolkit.Mvvm`
- `Microsoft.Extensions.DependencyInjection`
- `Serilog`
- `Serilog.Sinks.File`
- `Serilog.Sinks.Debug`
- `System.IO.Abstractions`

#### Test project

- `NSubstitute`
- `Shouldly`
- `Serilog.Sinks.TestCorrelator`

### Solution folders

- Added `View`, `ViewModel`, `Model`, `Resource` and `Service` solution folders to reflect the way I usually structure WPF projects.


### Project configuration

- Disabled implicit global `using`
- Enforce code style on build

### What to go and change after using this template

- Project assembly name(s)
- Project license & repo links etc...

### Code changes

- Enabled Fluent theme following the system. *This may be replaced with [ThemeMode](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/whats-new/net90#set-in-code) API if it is currently stable*

```xml
<Window x:Class="Template.App.MainWindow"
        ...
        ThemeMode="System">
```

- Added `ServiceProvider.cs` for DI/IoC

