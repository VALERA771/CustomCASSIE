using Exiled.API.Features;
using System;

namespace CustomCASSIE
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Custom CASSIE";
        public override string Prefix => "CustomCASSIE";
        public override string Author => "VALERA771#1471";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(5, 3, 0);

        private MapH map;

        public override void OnEnabled()
        {
            map = new MapH();
            Exiled.Events.Handlers.Map.Decontaminating += map.OnDecont;
            Plugin.singleton = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            map = null;
            Exiled.Events.Handlers.Map.Decontaminating -= map.OnDecont;

            Plugin.singleton = null;
            base.OnDisabled();
        }


        public static Plugin Instance => singleton;
        private static Plugin singleton;
    }
}
