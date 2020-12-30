namespace Views

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type ItemsPage() as self =
    inherit UserControl()

    do AvaloniaXamlLoader.Load self
