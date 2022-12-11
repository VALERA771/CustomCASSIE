using Exiled.API.Interfaces;
using System.ComponentModel;

namespace CustomCASSIE
{
    public sealed class Config : IConfig
    {
        [Description("Is plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Text for cassie")]
        public string Message { get; set; } = "";

        [Description("Should cassie have subtitels?")]
        public bool IsSubtiteled { get; set; } = true;

        [Description("Time between LCZ decontamination start and anouchement")]
        public int WaitTime { get; set; } = 10;
    }
}
