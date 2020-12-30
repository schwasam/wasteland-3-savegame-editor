namespace Models

open System

// TODO: store original xml fragment, so we do not have to model all elements
// TODO: when saving the file, update the xml fragment with the new values

type General = { Money: uint32 } // range 0..?

type Stats =
    { AttributePoints: uint32 // range 0..?
      SkillPoints: uint32 // range 0..?
      PerkPoints: uint32 } // range 0..?

type Ability = { Name: String }

type Skill =
    { Id: uint16 // range 1..a few hundred, but greater than 255
      Name: String
      Level: uint8 } // range 1..10, at 0 the skill should be removed

type Character =
    { Name: String
      CompanionId: int32 // ID is -1 when it is NOT a companion
      Stats: Stats
      Abilities: List<Ability>
      Skills: List<Skill> }

type Item = { Name: String; Quantity: uint32 } // range 1..? at 0 the item should be removed

type Global = { Key: String; Value: int32 } // usually a positive value, but can also be negative

type GameState =
    { GeneralData: General
      CharacterData: List<Character>
      ItemData: List<Item>
      GlobalData: List<Global> }
