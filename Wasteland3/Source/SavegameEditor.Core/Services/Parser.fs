namespace Wasteland3.SavegameEditor.Core.Services

open System
open System.Xml
open Wasteland3.SavegameEditor.Core.Models.GameState

module Parser =
    let parseSave (path: String) =
        let loadDocument () =
            // TODO: ignore first few lines that are not XML
            // TODO: decompress XML file first
            let doc = XmlDocument()
            doc.Load path
            doc

        let parseCharacter (node: XmlNode) =
            let toValue (node: XmlNode) =
                match node with
                | null -> null
                | obj -> obj.Value

            // displayName is missing when it is a companion
            let name =
                node.SelectSingleNode "displayName/text()"
                |> toValue

            // companionId is always there; when it is NOT a companion the ID is -1
            let companionId =
                node.SelectSingleNode "companionId/text()"
                |> toValue
                |> int32

            // TODO: stats/abilities/skills
            let character: Character =
                { Name = name
                  CompanionId = companionId
                  Stats =
                      { AttributePoints = 0u
                        SkillPoints = 0u
                        PerkPoints = 0u }
                  Abilities = List.empty<Ability>
                  Skills = List.empty<Skill> }

            character

        let parseItem (node: XmlNode) =
            let name =
                (node.SelectSingleNode "templateName/text()")
                    .Value

            let quantity =
                (node.SelectSingleNode "quantity/text()").Value
                |> uint32

            let item = { Name = name; Quantity = quantity }
            item

        let parseGlobal (node: XmlNode) =
            let key = (node.SelectSingleNode "k/text()").Value

            let value =
                (node.SelectSingleNode "v/text()").Value |> int32

            let global' = { Key = key; Value = value }
            global'

        let getGameState () =
            let doc = loadDocument ()

            let money =
                doc.SelectNodes "/save/money/text()"
                |> Seq.cast<XmlNode>
                |> Seq.map (fun node -> node.Value)
                |> Seq.head
                |> uint32

            let characters =
                doc.SelectNodes "/save/pcs/*"
                |> Seq.cast<XmlNode>
                |> Seq.map parseCharacter
                |> List.ofSeq

            let items =
                doc.SelectNodes "/save/hostInventory/*"
                |> Seq.cast<XmlNode>
                |> Seq.map parseItem
                |> List.ofSeq

            let globals =
                doc.SelectNodes "/save/globals/*"
                |> Seq.cast<XmlNode>
                |> Seq.map parseGlobal
                |> List.ofSeq

            let gameState =
                { GeneralData = { Money = money }
                  CharacterData = characters
                  ItemData = items
                  GlobalData = globals }

            gameState

        getGameState ()
