﻿namespace Views

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type GeneralPage () as self = 
    inherit UserControl ()

    do AvaloniaXamlLoader.Load self
