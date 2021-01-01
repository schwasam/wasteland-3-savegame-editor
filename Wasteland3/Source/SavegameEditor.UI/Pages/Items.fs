namespace Wasteland3.SavegameEditor.UI.Pages

module Items =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Components
    open Avalonia.FuncUI.Elmish
    open Elmish
    open Wasteland3.SavegameEditor.Core.Models.GameState

    type State = { items: Item array }

    let init = { items = Array.empty }

    type Msg = Show

    let update (msg: Msg) (state: State): State =
        match msg with
        | Show -> { state with items = Array.empty }

    let view (state: State) (dispatch) =
        let dg = DataGrid()
        dg.Items <- [ { Name = "Item1"; Quantity = 1u } ]
        dg.AutoGenerateColumns <- true

        // TODO: how to create a DataGrid with FuncUI?
        (*<DataGrid
            Name="dataGrid1"
            Items="{Binding GameState.ItemsData}">
          <DataGrid.Columns>
            <DataGridTextColumn Header="Name" Binding="{Binding Name}" Width="2*" />
            <DataGridTextColumn Header="Quantity" Binding="{Binding Quantity}" Width="2*" />
          </DataGrid.Columns>
        </DataGrid>*)

        // TODO: logic for adding a new item
        StackPanel.create
            [ StackPanel.children
                [ Button.create
                    [ Button.content "Add New Item" ] ] ]

    type Host() as this =
        inherit Hosts.HostControl()

        do
            let startFn () = init

            Elmish.Program.mkSimple startFn update view
            |> Program.withHost this
            |> Program.run
