using Exiled.API.Interfaces;
using System.ComponentModel;

namespace CustomCASSIE
{
    public sealed class Config : IConfig
    {
        [Description("Is plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Text for cassie after LCZ Decontamination")]
        public string MessageLCZ { get; set; } = "";

        [Description("Should cassie after LCZ Decontamination have subtitels?")]
        public bool IsSubtiteledLCZ { get; set; } = true;

        [Description("Time between LCZ decontamination start and anouchement")]
        public int WaitTimeLCZ { get; set; } = 10;

        [Description("Text for cassie after round start")]
        public string MessageRound { get; set; } = "";

        [Description("Should cassie after round start have subtitels?")]
        public bool IsSubtiteledRound { get; set; } = true;

        [Description("Time between round start and cassie")]
        public int WaitTimeRn { get; set; } = 0;
    }
}
