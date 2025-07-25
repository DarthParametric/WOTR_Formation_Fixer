using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints.Root;
using Kingmaker.Formations;
using Kingmaker.UI.Formation;
using Kingmaker.UI.MVVM._ConsoleView.Formation;
using Kingmaker.UI.MVVM._PCView.Formation;
using Kingmaker.UI.MVVM._VM.Formation;
using System.Reflection.Emit;
using UnityEngine;
using UnityModManagerNet;

namespace FormationFixer;

public static class Main
{
    internal static Harmony HarmonyInstance;
    internal static UnityModManager.ModEntry.ModLogger Log;

    public static bool Load(UnityModManager.ModEntry modEntry)
    {
        Log = modEntry.Logger;
        HarmonyInstance = new Harmony(modEntry.Info.Id);

        try
        {
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

            // Change the max size of formation arrays. Default is 20.
            PartyFormationHelper.UpdateArraySizesIfNeeded(24);
        }
        catch
        {
            HarmonyInstance.UnpatchAll(HarmonyInstance.Id);
            throw;
        }
        return true;
    }

    // Patch the formation blueprints to increase the size of their position arrays. They only hold 12 positions by default.
    public static void PatchFormationArrays()
    {
        var BPFormRoot = (FormationsRoot)ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(new Guid("d5fe855c2ee3dfe4fae440979505dd33")));             // Root\Formations\FormationsRoot
        var BPAuto = (BlueprintPartyFormation)ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(new Guid("1528ed7057903244f98c2d3c2851b3ec")));        // Root\Formations\Formation_Auto           PredefinedFormations Index 0
        var BPTriangle = (BlueprintPartyFormation)ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(new Guid("bb3d357f04e7e7b439ddd36c2b123877")));    // Root\Formations\Formation_Custom_01      PredefinedFormations Index 1
        var BPStar = (BlueprintPartyFormation)ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(new Guid("cdb4a0c6f7c2faf4f9bfb142ca4caee5")));        // Root\Formations\Formation_Custom_02      PredefinedFormations Index 2
        var BPWaves = (BlueprintPartyFormation)ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(new Guid("a38b14ca3fb0c05409c5c8e45fb5687c")));       // Root\Formations\Formation_Custom_03      PredefinedFormations Index 3
        var BPCircle = (BlueprintPartyFormation)ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(new Guid("71bb427a43932424a803f68253d57197")));      // Root\Formations\Formation_Custom_04      PredefinedFormations Index 4
        var BPHammer = (BlueprintPartyFormation)ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(new Guid("16bee6581f72d8f4b8028d5307f67d8d")));      // Root\Formations\Formation_Custom_05      PredefinedFormations Index 5

        LogDebug("Patching formation blueprints.");

        //BPFormRoot.FormationsScale = 0.9f;            // Default is 0.9 - Only scales the formation positions, not the icon size.
        //BPFormRoot.MinSpaceFactor = 0.66f;            // Default is 0.66
        //BPFormRoot.AutoFormation.SpaceX = 1.5f;       // Default is 1.5 - Kingmaker.Formations.PartyAutoFormationHelper uses these when assembling the auto formation.
        BPFormRoot.AutoFormation.SpaceY = 1.5f;         // Default is 2.5

        //                                #1                      #2                      #3                      #4                      #5                      #6                      #7                      #8                      #9                     #10                      #11                     #12                     #13                     #14                     #15                     #16                     #17                    #18                     #19                      #20                     #21                    #22                     #23                     #24
        BPAuto.Positions = [new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f), new(0.000f, 0.000f)];
        BPTriangle.Positions = [new(0.000f, 0.640f), new(-1.280f, -0.640f), new(1.280f, -0.640f), new(-2.560f, -1.920f), new(2.560f, -1.920f), new(0.000f, -1.920f), new(-3.840f, -3.200f), new(3.840f, -3.200f), new(-1.280f, -3.200f), new(1.280f, -3.200f), new(-5.120f, -4.480f), new(5.120f, -4.480f), new(-2.560f, -4.480f), new(2.560f, -4.480f), new(0.000f, -4.480f), new(-6.400f, -5.760f), new(6.400f, -5.760f), new(-3.840f, -5.760f), new(3.840f, -5.760f), new(-1.280f, -5.760f), new(1.280f, -5.760f), new(-5.120f, -7.040f), new(5.120f, -7.040f), new(0.000f, -7.040f)];
        BPStar.Positions = [new(0.000f, 0.880f), new(0.000f, -0.780f), new(0.000f, -2.440f), new(0.000f, -5.200f), new(0.000f, -6.860f), new(-2.620f, -3.840f), new(2.620f, -3.840f), new(-0.960f, -3.840f), new(0.960f, -3.840f), new(-1.720f, -2.320f), new(1.720f, -2.320f), new(-1.720f, -5.360f), new(1.720f, -5.360f), new(-2.600f, -0.900f), new(2.600f, -0.900f), new(-2.400f, -6.880f), new(2.400f, -6.880f), new(-3.400f, 0.600f), new(3.400f, 0.600f), new(-3.300f, -8.380f), new(3.300f, -8.380f), new(-4.320f, -3.840f), new(4.320f, -3.840f), new(0.000f, -8.560f)];
        BPWaves.Positions = [new(0.000f, 0.680f), new(-4.000f, -0.320f), new(4.000f, -0.320f), new(0.000f, -1.320f), new(-4.000f, -2.320f), new(4.000f, -2.320f), new(-2.000f, 0.280f), new(2.000f, 0.280f), new(-2.000f, -1.720f), new(2.000f, -1.720f), new(-4.000f, -4.320f), new(4.000f, -4.320f), new(0.000f, -3.320f), new(-2.000f, -3.720f), new(2.000f, -3.720f), new(-4.000f, -6.320f), new(4.000f, -6.320f), new(0.000f, -5.320f), new(-2.000f, -5.720f), new(2.000f, -5.720f), new(-4.000f, -8.320f), new(4.000f, -8.320f), new(-2.000f, -7.720f), new(2.000f, -7.720f)];
        BPCircle.Positions = [new(0.000f, 0.880f), new(-3.700f, -0.720f), new(3.700f, -0.720f), new(-3.700f, -6.820f), new(3.700f, -6.820f), new(0.000f, -8.520f), new(-2.000f, 0.480f), new(2.000f, 0.480f), new(-2.000f, -8.120f), new(2.000f, -8.120f), new(-4.700f, -2.720f), new(4.700f, -2.720f), new(-4.700f, -4.820f), new(4.700f, -4.820f), new(-2.000f, -1.720f), new(2.000f, -1.720f), new(-2.000f, -5.820f), new(2.000f, -5.820f), new(-3.000f, -3.720f), new(3.000f, -3.720f), new(0.000f, -1.120f), new(0.000f, -6.520f), new(-1.040f, -3.840f), new(1.040f, -3.840f)];
        BPHammer.Positions = [new(0.000f, 1.200f), new(-2.000f, 1.200f), new(2.000f, 1.200f), new(-4.000f, 1.200f), new(4.000f, 1.200f), new(-6.000f, 1.200f), new(6.000f, 1.200f), new(0.000f, -0.800f), new(0.000f, -2.800f), new(0.000f, -4.800f), new(0.000f, -6.800f), new(-6.000f, -0.800f), new(6.000f, -0.800f), new(-4.000f, -0.800f), new(4.000f, -0.800f), new(-2.000f, -0.800f), new(2.000f, -0.800f), new(-2.000f, -2.800f), new(2.000f, -2.800f), new(-2.000f, -4.800f), new(2.000f, -4.800f), new(-2.000f, -6.800f), new(2.000f, -6.800f), new(0.000f, -8.800f)];

        LogDebug($"Patched blueprint array counts: Auto - {BPAuto.Positions.Length}, Triangle - {BPTriangle.Positions.Length}, Star - {BPStar.Positions.Length}, Waves - {BPWaves.Positions.Length}, Circle - {BPCircle.Positions.Length}, Hammer - {BPHammer.Positions.Length}.");
    }

    public static void LogDebug(string message)
    {
#if DEBUG
        try
        {
            Log.Log($"DEBUG: {message}");
        }
        catch (Exception e)
        {
            Log.Log($"Caught exception in debug log:\n{e}");
        }
#endif
    }

    [HarmonyPatch(typeof(BlueprintsCache))]
    public static class BlueprintsCaches_Patch
    {
        private static bool Initialized = false;

        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        public static void Init_Postfix()
        {
            try
            {
                if (Initialized)
                {
                    LogDebug("Already initialised blueprints cache patch");
                    return;
                }

                Initialized = true;

                PatchFormationArrays();
            }
            catch (Exception e)
            {
                Log.Log($"Mod initialisation failed with exception \n{e}");
            }
        }
    }

    // Patch the Auto formation setup to make it use wider rows (default is 4 or 3 max).
    [HarmonyPatch(typeof(PartyAutoFormationHelper), nameof(PartyAutoFormationHelper.SetupLinePositions))]
    static class Auto_Formation_Condenser_Patch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            CodeMatcher matcher = new(instructions);

            /*
            Code for the allowed number of party members in each row:

                int num = ((line.Count > 5) ? Math.Min(4, line.Count) : Math.Min(3, line.Count))

                IL_0002: ldarg.2    // line
                IL_0003: callvirt   virtual System.Int32 System.Collections.Generic.List`1<Kingmaker.Formations.UnitFormationData>::get_Count()
                IL_0008: ldc.i4.5
                IL_0009: bgt =>     Label0
                IL_000E: ldc.i4.3
                IL_000F: ldarg.2
                IL_0010: callvirt   virtual System.Int32 System.Collections.Generic.List`1<Kingmaker.Formations.UnitFormationData>::get_Count()
                IL_0015: call       static System.Int32 System.Math::Min(System.Int32 val1, System.Int32 val2)
                IL_001A: br =>      Label1
                IL_001F: Label0
                IL_001F: ldc.i4.4
                IL_0020: ldarg.2    // line
                IL_0021: callvirt   virtual System.Int32 System.Collections.Generic.List`1<Kingmaker.Formations.UnitFormationData>::get_Count()
                IL_0026: call       static System.Int32 System.Math::Min(System.Int32 val1, System.Int32 val2)
                IL_002B: Label1
                IL_002B: stloc.1    // num2
                IL_002C: br =>      Label2
            
            Change to:

                int num = ((line.Count > 5) ? Math.Min(6, line.Count) : Math.Min(4, line.Count))
            
            Default formation maxes out at 4 wide. Increase cap to 6.
            */

            matcher.MatchEndForward(
                new CodeMatch(OpCodes.Ldarg_2),
                new CodeMatch(OpCodes.Callvirt, AccessTools.Method(typeof(List<PartyAutoFormationHelper.UnitFormationData>), "get_Count")),
                new CodeMatch(OpCodes.Ldc_I4_5)
            )
                .Advance(2)
                .RemoveInstruction()                                                        // Remove original int 3 (ldc.i4.3)
                .Insert(new CodeInstruction(OpCodes.Ldc_I4_4))                              // int 4
                .Advance(5);

            List<Label> jumphere = matcher.Labels.ToList();                                 // Copy the vanilla label so it can be reapplied to the replacement instruction.

            matcher.RemoveInstruction()                                                     // Remove original int 4 (ldc.i4.4)
                .Insert([new CodeInstruction(OpCodes.Ldc_I4_6) { labels = jumphere }]);     // int 6

            return matcher.InstructionEnumeration();
        }
    }

    // Patch that scales down the UI formation positions and character portraits by 70% to fit more on screen.
    // Also prevents the default auto-scaling from affecting any formation other than the Auto formation.
    // Only applies to the keyboard and mouse UI layout.
    [HarmonyPatch(typeof(FormationPCView), nameof(FormationPCView.OnFormationPresetChanged))]
    static class Formation_UI_Scale_Patch_PC
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator il)
        {
            CodeMatcher matcher = new(instructions, il);

            /*
            Code for whether to scale the UI condition check. Based on lowest Y position on UI of current party members:

	            if (num1 < -185.0)

                IL_0061: ldloc.0
                IL_0062: ldc.r4     -185
                IL_0067: bge.un =>  Label4

            Change it to:
            
	            if (num < -170f && formationPresetIndex == 0)

            Ensures it only applies to the Auto formation. Additionally, change the -185 with -170 to scale it sooner to try
            and prevent the formation going past the bottom edge of the grid.

            This needs to be subsequently edited again in order to redirect the jumps to a later addition.
            */

            matcher.MatchStartForward(
                new CodeMatch(OpCodes.Ldloc_0),
                new CodeMatch(OpCodes.Ldc_R4, -185f),
                new CodeMatch(OpCodes.Bge_Un_S)
            );

            matcher.Advance(1)
                .RemoveInstruction()
                .Insert(new CodeInstruction(OpCodes.Ldc_R4, -170f))     // Replace -185 with -170.
                .Advance(1);

            var jumptoend = matcher.Operand;    // Jumps to final this.m_CharacterContainer.localScale = Vector3.one, required in second edit.

            matcher.InsertAfter([
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Brtrue_S, jumptoend)    // Temporarily use this label, replace later after new code added.
            ]);

            matcher.Advance(3)
                .RemoveInstruction()
                .Insert(new CodeInstruction(OpCodes.Ldc_R4, -170f));     // Replace -185 with -170.

            /*
            Code for default UI scaling if previous check falls through:

                this.m_CharacterContainer.localScale = Vector3.one

                IL_009C: ldfld      UnityEngine.RectTransform Kingmaker.UI.MVVM._PCView.Formation.FormationPCView::m_CharacterContainer
                IL_00A1: call       static UnityEngine.Vector3 UnityEngine.Vector3::get_one()
                IL_00A6: callvirt   System.Void UnityEngine.Transform::set_localScale(UnityEngine.Vector3 value)

            Change this to:

	            if (formationPresetIndex != 0)
	            {
		            this.m_CharacterContainer.localScale = new Vector3(0.7f, 0.7f, 1f);
		            return;
	            }
	            this.m_CharacterContainer.localScale = Vector3.one;

            Scales down the UI for custom formations to a fixed 70% but ensures the Auto formation retains the vanilla behaviour.
            */

            matcher.MatchStartForward(CodeMatch.Calls(AccessTools.PropertyGetter(typeof(Vector3), nameof(Vector3.one))))
                .Advance(-3)
                .InsertAfterAndAdvance(new CodeInstruction(OpCodes.Ldarg_1));

            var secondblock = matcher.Pos;      // Create a jump offset reference for subsequent label application.

            matcher.InsertAfter([
                new CodeInstruction(OpCodes.Brfalse_S, jumptoend),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(FormationPCView), nameof(FormationPCView.m_CharacterContainer))),
                new CodeInstruction(OpCodes.Ldc_R4, 0.7f),
                new CodeInstruction(OpCodes.Ldc_R4, 0.7f),
                new CodeInstruction(OpCodes.Ldc_R4, 1.0f),
                new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(Vector3), [typeof(float), typeof(float), typeof(float)])),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertySetter(typeof(Transform), "localScale")),
                new CodeInstruction(OpCodes.Ret)
            ]);

            matcher.Start()     // Return to the first section to change the jump offsets so they can reach the above added code.
                .MatchEndForward(
                    new CodeMatch(OpCodes.Ldloc_0),
                    new CodeMatch(OpCodes.Ldc_R4, -170f),   // Need to use the new value we changed this to earlier (originally -185).
                    new CodeMatch(OpCodes.Bge_Un_S)
                )
                .SetJumpTo(OpCodes.Bge_Un_S, secondblock, out _)
                .Advance(2)
                .SetJumpTo(OpCodes.Brtrue_S, secondblock, out _);

            return matcher.InstructionEnumeration();
        }
    }

    // Equivalent patch to the above for the controller UI layout. The method is identical, it's just in a different castle.
    [HarmonyPatch(typeof(FormationConsoleView), nameof(FormationConsoleView.OnFormationPresetChanged))]
    static class Formation_UI_Scale_Patch_Console
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator il)
        {
            CodeMatcher matcher = new(instructions, il);

            matcher.MatchStartForward(
                new CodeMatch(OpCodes.Ldloc_0),
                new CodeMatch(OpCodes.Ldc_R4, -185f),
                new CodeMatch(OpCodes.Bge_Un_S)
            );

            matcher.Advance(1)
                .RemoveInstruction()
                .Insert(new CodeInstruction(OpCodes.Ldc_R4, -170f))     // Replace -185 with -170.
                .Advance(1);

            var jumptoend = matcher.Operand;    // Jumps to final this.m_CharacterContainer.localScale = Vector3.one, required in second edit.

            matcher.InsertAfter([
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Brtrue_S, jumptoend)    // Temporarily use this label, replace later after new code added.
            ]);

            matcher.Advance(3)
                .RemoveInstruction()
                .Insert(new CodeInstruction(OpCodes.Ldc_R4, -170f));     // Replace -185 with -170.

            matcher.MatchStartForward(CodeMatch.Calls(AccessTools.PropertyGetter(typeof(Vector3), nameof(Vector3.one))))
                .Advance(-3)
                .InsertAfterAndAdvance(new CodeInstruction(OpCodes.Ldarg_1));

            var secondblock = matcher.Pos;      // Create a jump offset reference for subsequent label application.

            matcher.InsertAfter([
                new CodeInstruction(OpCodes.Brfalse_S, jumptoend),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(FormationPCView), nameof(FormationPCView.m_CharacterContainer))),
                new CodeInstruction(OpCodes.Ldc_R4, 0.7f),
                new CodeInstruction(OpCodes.Ldc_R4, 0.7f),
                new CodeInstruction(OpCodes.Ldc_R4, 1.0f),
                new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(Vector3), [typeof(float), typeof(float), typeof(float)])),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertySetter(typeof(Transform), "localScale")),
                new CodeInstruction(OpCodes.Ret)
            ]);

            matcher.Start()     // Return to the first section to change the jump offsets so they can reach the above added code.
                .MatchEndForward(
                    new CodeMatch(OpCodes.Ldloc_0),
                    new CodeMatch(OpCodes.Ldc_R4, -170f),   // Need to use the new value we changed this to earlier (originally -185).
                    new CodeMatch(OpCodes.Bge_Un_S)
                )
                .SetJumpTo(OpCodes.Bge_Un_S, secondblock, out _)
                .Advance(2)
                .SetJumpTo(OpCodes.Brtrue_S, secondblock, out _);

            return matcher.InstructionEnumeration();
        }
    }

    // Patch that offsets the position of the character icons on the formation UI when the Auto formation tab is active to force them towards the top of the grid,
    // maximising the available space. Dynamically adjusts the offset based on the party size.
    [HarmonyPatch(typeof(FormationCharacterVM), nameof(FormationCharacterVM.GetLocalPosition))]
    class Formation_UI_Offset_Patch
    {
        static bool Prefix(ref Vector3 __result, FormationCharacterVM __instance)
        {
            int CurrInd = Game.Instance.Player.FormationManager.CurrentFormationIndex;
            int PtyCnt = Game.Instance.Player.Party.Count;
            Vector2 CurrPos = __instance.GetOffset();
            Vector2 AdjPos = CurrPos * 40f;
            Vector2 DefPos = AdjPos + new Vector2(0f, 138f);

            float offset;

            if (PtyCnt > 16)
            {
                offset = 210f;
            }
            else if (PtyCnt > 12)
            {
                offset = 160;
            }
            else if (PtyCnt > 6)
            {
                offset = 155;
            }
            else if (PtyCnt == 1)
            {
                offset = 0;
            }
            else
            {
                offset = 145;
            }

            LogDebug($"Party count = {PtyCnt}, offset = {offset}");

            if (CurrInd == 0)
            {
                Vector2 Auto = AdjPos + new Vector2(0f, offset);

                LogDebug($"Char index = {__instance.m_Index}, name = {__instance.Unit.CharacterName}, GetOffset() = {CurrPos}, AdjPos = {AdjPos}, DefPos = {DefPos}, final position = {Auto}");

                __result = Auto;
            }
            else
            {
                __result = DefPos;
            }
            
            return false;
        }
    }

    // Patch to expand the bounds of the usable formation area back out to the original extents of the grid texture after the Formation_UI_Scale_Patch_PC patch.
    // Allows for the center of character icons to be moved right to the edge of the grid before further movement is clamped.
    // The Auto formation bounds are scaled down slightly from the vanilla values to prevent it pushing outside the grid edges.
    [HarmonyPatch(typeof(FormationCharacterDragComponent), nameof(FormationCharacterDragComponent.Initialize))]

    public static class Formation_UI_Grid_Scale_Patch
    {
        [HarmonyPostfix]
        public static void Initialize(FormationCharacterDragComponent __instance)
        {
            int CurrInd = Game.Instance.Player.FormationManager.CurrentFormationIndex;

            if (CurrInd != 0)
            {
                __instance.m_MinPosition *= 1.6f;
                __instance.m_MaxPosition *= 1.6f;
            }
        }
    }
}
