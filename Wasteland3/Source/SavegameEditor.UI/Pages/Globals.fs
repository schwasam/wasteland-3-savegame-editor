namespace Wasteland3.SavegameEditor.UI.Pages

module Globals =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Components
    open Avalonia.FuncUI.Elmish
    open Elmish
    open Wasteland3.SavegameEditor.Core.Models.GameState

    type State = { globals: Global array }

    let init = { globals = Array.empty }

    type Msg = Show

    let update (msg: Msg) (state: State): State =
        match msg with
        | Show -> { state with globals = Array.empty }

    // TODO: how to create a DataGrid with FuncUI?
    (*<DataGrid
        Name="dataGrid1"
        Items="{Binding GameState.GlobalData}">
      <DataGrid.Columns>
        <DataGridTextColumn Header="Key" Binding="{Binding Key}" Width="2*" />
        <DataGridTextColumn Header="Value" Binding="{Binding Value}" Width="2*" />
      </DataGrid.Columns>
    </DataGrid>*)

    // TODO: logic for adding a new global
    let view (state: State) (dispatch) =
        StackPanel.create
            [ StackPanel.children
                [ Button.create
                    [ Button.content "Add New Global" ] ] ]

    type Host() as this =
        inherit Hosts.HostControl()

        do
            let startFn () = init

            Elmish.Program.mkSimple startFn update view
            |> Program.withHost this
            |> Program.run
