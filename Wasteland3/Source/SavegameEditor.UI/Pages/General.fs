namespace Wasteland3.SavegameEditor.UI.Pages

module General =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Components
    open Avalonia.FuncUI.Elmish
    open Elmish
    open Wasteland3.SavegameEditor.Core.Models.GameState

    type State = { general: General }

    let init = { general = { Money = 0u } }

    type Msg = Show

    let update (msg: Msg) (state: State): State =
        match msg with
        | Show -> { state with general = { Money = 0u } }

    let view (state: State) (dispatch) =
        StackPanel.create [
            StackPanel.children [
                NumericUpDown.create [
                    NumericUpDown.value (state.general.Money |> double)
                    NumericUpDown.formatString "N0"
                    NumericUpDown.minimum 0.0
                    NumericUpDown.maximum 1_000_000.0
                    NumericUpDown.increment 1_000.0
                    NumericUpDown.clipValueToMinMax true
                ]
            ]
        ]

    type Host() as this =
        inherit Hosts.HostControl()

        do
            let startFn () = init

            Elmish.Program.mkSimple startFn update view
            |> Program.withHost this
            |> Program.run
