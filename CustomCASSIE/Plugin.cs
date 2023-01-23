using Exiled.API.Features;
using Exiled.Loader;
using System;
using System.Linq;

namespace CustomCASSIE
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Custom CASSIE";
        public override string Prefix => "CustomCASSIE";
        public override string Author => "VALERA771#1471";
        public override Version Version => new Version(2, 0, 1);
        public override Version RequiredExiledVersion => new Version(6, 0, 0);

        private Handlers han;
        public static int ActGen;
        public static bool MerInstalled = false;

        public override void OnEnabled()
        {
            han = new Handlers();
            Exiled.Events.Handlers.Map.Decontaminating += han.OnDecont;
            Exiled.Events.Handlers.Map.GeneratorActivated += han.OnGenAct;
            Exiled.Events.Handlers.Server.RoundStarted += han.OnRnStart;
            Plugin.singleton = this;
            base.OnEnabled();

            if (Instance.Config.CheckMerInstalled)
                if (Loader.Plugins.Any(p => p.Name == "MapEditorReborn"))
                    MerInstalled = true;
                else
                {
                    MerInstalled = false;
                    Log.Warn("MER is not installed, but check is enabled!");
                }

        }

        public override void OnDisabled()
        {
            han = null;
            Exiled.Events.Handlers.Map.Decontaminating -= han.OnDecont;
            Exiled.Events.Handlers.Map.GeneratorActivated -= han.OnGenAct;
            Exiled.Events.Handlers.Server.RoundStarted -= han.OnRnStart;

            Plugin.singleton = null;
            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            base.OnReloaded();
        }


        public static Plugin Instance => singleton;
        private static Plugin singleton;
    }
}
