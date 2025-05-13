using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

[assembly: AssemblyVersion(DecayIRFNREFix.Plugin.VERSION_STRING)]
[assembly: AssemblyFileVersion(DecayIRFNREFix.Plugin.VERSION_STRING)]
[assembly: AssemblyInformationalVersion(DecayIRFNREFix.Plugin.VERSION_STRING)]

namespace DecayIRFNREFix;

[BepInPlugin(GUID, MOD_NAME, VERSION_STRING)]
public class Plugin : BasePlugin
{
    public const string GUID = $"dev.aurirex.gtfo.{MOD_NAME}";
    public const string MOD_NAME = nameof(DecayIRFNREFix);
    public const string VERSION_STRING = "1.0.0";
    
    private static Harmony _harmony;
    internal static ManualLogSource L;
    
    public override void Load()
    {
        L = Log;
        
        _harmony = new Harmony(GUID);
        
        _harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}