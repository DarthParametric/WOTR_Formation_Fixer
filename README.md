# About

A mod for Owlcat's Pathfinder: Wrath of the Righteous.

Adjusts the formation templates and UI to allow for larger parties, intended for use in conjunction with ADDB's [More Party Slots](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/694) mod. Supports up to 24 party members, including pets (double the provision of vanilla).

By default, the game only handles up to 12 entities in a party formation. Anything beyond that and characters are forced into the same position on top of one another. This mod edits all the custom formations to allow for more characters, adding an additional 12 positions to bring the total to 24. It also adjusts the scaling of the character portraits in the formation manager UI to allow for more space to fit larger parties. Additionally, the settings of the Auto formation have been tweaked to try and better accommodate large parties, and maximise the use of the UI space for it in the formation manager.

# Install
1. Download and install [Unity Mod Manager](https://www.nexusmods.com/site/mods/21) and set it up for WOTR ("Pathfinder Second Adventure").
1. Download the latest version of the mod from [Github](/releases/latest), [Nexus Mods](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/836), or via [ModFinder](https://github.com/Pathfinder-WOTR-Modding-Community/ModFinder/releases/latest).
1. Install the mod manually, via UMM, or via ModFinder.
1. Run your game.

# Notes
- More Party Slots is not strictly required, but there's little point in using this mod unless you have a party beyond the vanilla 6. Although it may prove useful for vanilla 6 + 6 pets.
- If you _are_ using More Party Slots, the use of [More Party View Slots](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/692) is also recommended.
- The vanilla game has a hard limit of 20 units in the party, which this mod has expanded to 24. While More Party Slots might let you add more units beyond that, doing so will cause the game to crash when loading an area with all of them in the party. While the cap itself is easy to raise, each new party member would require a new set of formation positions.
- The formation manager UI scaling has been adjusted to fit larger formations more comfortably and give you more room to customise their positions. The various patches involved to do so though may cause some unexpected wonkiness, so use the Restore to Default button if things get messed up.
- The Auto formation does not handle large parties very well. I have tried to adjust its behaviour, with limited success. However, the formation manager UI tab for it does now dynamically adjust the formation position to try and maximise the available space.

# Thanks & Acknowledgements
- microsoftenator2022 - Helped out with creating the first transpiler (which I subsequently rewrote, so all terrible code and bugs are my fault) and corrected some of my syntax goofs. He also pointed out where the game was capping the max formation array size, leading to crashes.
- ADDB - Provided the postfix patch for scaling the usable area of the formation grid back up to the correct size after other UI scaling.
- Everyone in the `#mod-dev-technical` channel of the Owlcat Discord server for various modding-related discussions and suggestions, help troubleshooting issues, and answering general questions.
