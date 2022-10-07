using System.Reflection;
using HarmonyLib;
using UnityEngine;

public class RemoveLightning : IModApi
{
    public void InitMod(Mod mod)
    {
        Debug.Log("Loading Remove Lightning Patch: " + GetType().ToString());
        var harmony = new Harmony(GetType().ToString());
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    [HarmonyPatch(typeof(WeatherManager))]
    [HarmonyPatch("FrameUpdate")]
    class ByeThunder
    {
        static void Prefix()
        {

            FieldInfo FieldIsThunderLastTime = AccessTools.Field(typeof(WeatherManager), "thunderLastTime");
            FieldIsThunderLastTime.SetValue(WeatherManager.Instance, 100000000000000f);

        }
    }
}
