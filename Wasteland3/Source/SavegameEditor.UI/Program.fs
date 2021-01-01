namespace Wasteland3.SavegameEditor.UI

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.FuncUI

type App() =
    inherit Application()

    override this.Initialize() =
        // TODO: choose a theme, one of these or e.g. material theme? 
        //this.Styles.Load "avares://Avalonia.Themes.Default/DefaultTheme.xaml"
        //this.Styles.Load "avares://Avalonia.Themes.Default/Accents/BaseLight.xaml"
        //this.Styles.Load "avares://Avalonia.Themes.Default/Accents/BaseDark.xaml"

        //this.Styles.Load "avares://Citrus.Avalonia/Citrus.xaml"
        this.Styles.Load "avares://Citrus.Avalonia/Sea.xaml"
        //this.Styles.Load "avares://Citrus.Avalonia/Rust.xaml"
        //this.Styles.Load "avares://Citrus.Avalonia/Candy.xaml"
        //this.Styles.Load "avares://Citrus.Avalonia/Magma.xaml"

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- Shell.MainWindow()
        | _ -> ()

module Program =

    [<EntryPoint>]
    let main (args: string []) =
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .StartWithClassicDesktopLifetime(args)
