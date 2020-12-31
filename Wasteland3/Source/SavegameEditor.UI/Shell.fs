namespace Wasteland3.SavegameEditor.UI

module Shell =
    open Elmish
    open Avalonia.Controls
    open Avalonia.FuncUI
    open Avalonia.FuncUI.Builder
    open Avalonia.FuncUI.Components.Hosts
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Elmish
    open Wasteland3.SavegameEditor.UI.Pages

    type State =
        { aboutState: About.State }

    type Msg =
        | AboutMsg of About.Msg

    let init =
        let aboutState, bpCmd = About.init
        { aboutState = aboutState },
        Cmd.batch [ bpCmd ]

    let update (msg: Msg) (state: State): State * Cmd<_> =
        match msg with
        | AboutMsg bpmsg ->
            let aboutState, cmd =
                About.update bpmsg state.aboutState
            { state with aboutState = aboutState },
            Cmd.map AboutMsg cmd

    let view (state: State) (dispatch) =
        DockPanel.create
            [ DockPanel.children
                [ TabControl.create
                    [ TabControl.tabStripPlacement Dock.Top
                      TabControl.viewItems
                        [ TabItem.create
                            [ TabItem.header "TreeView Page"
                              TabItem.content (ViewBuilder.Create<TreeViewPage.Host>([])) ]
                          TabItem.create
                            [ TabItem.header "User Profiles Page"
                              TabItem.content (ViewBuilder.Create<UserProfiles.Host>([])) ]
                          TabItem.create
                            [ TabItem.header "About"
                              TabItem.content (About.view state.aboutState (AboutMsg >> dispatch)) ]
                          TabItem.create
                            [ TabItem.header "General"
                              TabItem.content (ViewBuilder.Create<General.Host>([])) ]
                          TabItem.create
                            [ TabItem.header "Items"
                              TabItem.content (ViewBuilder.Create<Items.Host>([])) ]
                          TabItem.create
                            [ TabItem.header "Globals"
                              TabItem.content (ViewBuilder.Create<Globals.Host>([])) ] ] ] ] ]

    type MainWindow() as this =
        inherit HostWindow()
        do
            base.Title <- "Wasteland 3 Savegame Editor"
            base.Width <- 1024.0
            base.Height <- 768.0
            base.MinWidth <- 1024.0
            base.MinHeight <- 768.0

            //this.VisualRoot.VisualRoot.Renderer.DrawFps <- true
            //this.VisualRoot.VisualRoot.Renderer.DrawDirtyRects <- true

            Elmish.Program.mkProgram (fun () -> init) update view
            |> Program.withHost this
            |> Program.run
