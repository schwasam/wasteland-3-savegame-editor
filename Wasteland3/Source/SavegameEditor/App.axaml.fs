namespace SavegameEditor

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Markup.Xaml
open ViewModels
open Views

type App() as self =
    inherit Application()

    // HACK: https://github.com/AvaloniaUI/Avalonia/issues/2426
    let dataGridType = typedefof<DataGrid>

    do AvaloniaXamlLoader.Load self

    override x.OnFrameworkInitializationCompleted() =
        match x.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktop ->
            desktop.MainWindow <- MainWindow(DataContext = MainWindowViewModel())
        | _ -> ()

        base.OnFrameworkInitializationCompleted()
