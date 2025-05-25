# Template WPF Project

## This project is

- Based on the Visual Studio WPF template
- Structured around a project using a MVVM design pattern
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
- `NSubstitute.Analyzers.CSharp`

### Solution folders

- Added `View`, `ViewModel`, `Model`, `Resource` and `Service` solution folders to reflect the way I usually structure WPF projects.

### Project configuration

- Disabled implicit global `using`
- Enforce code style on build
- Generate XML doc file to enforce `CS1591` via `.editorconfig`
- `NeutralLanguage` of app project set to `en-GB`

### What to go and change after using this template

- Solution name
- Project names
- Project assembly names
- Project license & repo links etc...

### Code changes

- Enabled Fluent theme following the system. *This may be replaced with [ThemeMode](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/whats-new/net90#set-in-code) API if it is currently stable*

```xml
<Window x:Class="Template.App.MainWindow"
        ...
        ThemeMode="System">
```

- Added `ServiceProvider.cs` for DI/IoC
- Added `Logging.cs` to set up `serilog` log configs for `DEBUG` and `RELEASE` environments. Debug logger logs to Debug console within Visual Studio, Release logger logs to a file.
- Added `NavigationViewModel.cs` to provide basic application view navigation logic. See this being used from `MainViewModel.cs` - the corresponding view for this VM uses a `ContentControl` to display what view is mounted into the main window. More specific instances of this same service could be used to navigate within other parts of the application if this is required. It is written such that direct access to the instance is required to navigate, though some logic could be added with an `IMessenger` to make decoupled navigation possible too.


`MainWindowViewModel.cs`
```csharp
public MainWindowViewModel(NavigationViewModel navigationViewModel)
{
    this.NavigationViewModel = navigationViewModel;

    // Some logic could go here to change what page is initially navigated to...
    this.NavigationViewModel.Navigate<ExamplePageViewModel>();
}
```

`NavDataTemplates.xaml`
```xml
<DataTemplate DataType="{x:Type pageViewModels:ExamplePageViewModel}">
    <pageViews:ExamplePageView />
</DataTemplate>
```

`MainWindowView.xaml`
```xml
<Grid Width="Auto">
    <ContentControl Content="{Binding NavigationViewModel.CurrentViewModel}" />
</Grid>
```

- Added `ExamplePageViewModel.cs` and `ExamplePageView.xaml/.cs` to demonstrate the navigation working. This ViewModel contains a basing string property bound to the view - that is what is displayed when the application first opens.

### Extra `.editorconfig` rules

```ini
# Require XML documentation comments for publicly visible types or members
dotnet_diagnostic.CS1591.severity = warning
```
