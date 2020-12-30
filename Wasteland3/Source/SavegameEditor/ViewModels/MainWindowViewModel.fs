namespace ViewModels

open Models
open Services.Parser

type MainWindowViewModel() =
    inherit ViewModelBase()

    member __.Greeting = "Hello World!"

    member __.GameState =
        parseSave @"C:\Users\Firkraag\Downloads\WL3.SaveEditor\Narbensammler-Mine_editable.xml"

    member __.Money = 1000u

    // member __.Items = new Observable(__.GameState.ItemData)

    member __.AddNewItem() =
        __.GameState.ItemData = { Name = "NewItem"; Quantity = 1u }
                                :: __.GameState.ItemData
