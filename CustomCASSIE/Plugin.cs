using Exiled.API.Features;
using System;

namespace CustomCASSIE
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Custom CASSIE";
        public override string Prefix => "CustomCASSIE";
        public override string Author => "VALERA771#1471";
        public override Version Version => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(5, 3, 0);

        private Handlers han;

        public override void OnEnabled()
        {
            han = new Handlers();
            Exiled.Events.Handlers.Map.Decontaminating += han.OnDecont;
            Exiled.Events.Handlers.Server.RoundStarted += han.OnRnStart;
            Plugin.singleton = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            han = null;
            Exiled.Events.Handlers.Map.Decontaminating -= han.OnDecont;
            Exiled.Events.Handlers.Server.RoundStarted -= han.OnRnStart;

            Plugin.singleton = null;
            base.OnDisabled();
        }


        public static Plugin Instance => singleton;
        private static Plugin singleton;
    }
}
