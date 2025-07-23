# About

A mod for Owlcat's Pathfinder: Wrath of the Righteous.

Adjusts the formation templates and UI to allow for larger parties, intended for use in conjunction with ADDB's More Party Slots mod. Supports up to 24 party members, including pets (double the provision of vanilla).

# Install
1. Download and install [Unity Mod Manager](https://www.nexusmods.com/site/mods/21) and set it up for WOTR ("Pathfinder Second Adventure").
1. Download the latest version of the mod from [Github](/releases/latest) or [Nexus Mods](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/xxx). Alternatively, it is now also available via [ModFinder](https://github.com/Pathfinder-WOTR-Modding-Community/ModFinder/releases/latest).
1. Install the mod manually, via UMM, or via ModFinder.
1. Run your game.

# Notes
- The vanilla game has a hard limit of 20 units in the party, which this mod has expanded to 24. While More Party Slots might let you add more units beyond that, doing so will cause the game to crash when loading an area with all of them in the party.
- The UI has been adjusted to fit larger formations more comfortably and give you more room to customise. The various patches involved to do so though may
cause some unexpected wonkiness, so use the Restore to Default button if things get messed up.
- The Auto formation does not handle large parties very well. I have tried to adjust its behaviour, with limited success. 

# Thanks & Acknowledgements
- microsoftenator2022 - Helped out with creating the first transpiler (which I subsequently rewrote, so all terrible code is my fault) and corrected some of my terrible syntax goofs.
- ADDB - Provided the PostFix patch for scaling the usable area of the formation grid back up to the correct size after other UI scaling.
- Everyone in the `#mod-dev-technical` channel of the Owlcat Discord server for various modding-related discussions and suggestions, help troubleshooting issues, and answering general questions.
