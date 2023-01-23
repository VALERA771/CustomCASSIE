using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using MEC;
using System.Linq;

namespace CustomCASSIE
{
    public class Handlers
    {
        public void OnDecont(DecontaminatingEventArgs ev)
        {
            if (Plugin.MerInstalled)
            {
                string temp = Plugin.Instance.Config.WaitTimeLCZ.ToString();
                float time = float.Parse(temp);
                Timing.CallDelayed(time, () =>
                {
                    Cassie.Message(message: Plugin.Instance.Config.MessageLCZ, isSubtitles: Plugin.Instance.Config.IsSubtiteledLCZ);
                    Log.Debug("Sending DecontaminationStart CASSIE...");
                });
            }
        }

        public void OnRnStart()
        {
            if (Plugin.MerInstalled)
            {
                if (Plugin.Instance.Config.WaitTimeRn == 0)
                {
                    Timing.CallDelayed(1f, () =>
                    {
                        Cassie.Message(message: Plugin.Instance.Config.MessageRound, isSubtitles: Plugin.Instance.Config.IsSubtiteledRound);
                        Log.Debug("Sending RoundStart CASSIE...");
                    });
                }
                else
                {
                    string temp = Plugin.Instance.Config.WaitTimeRn.ToString();
                    float time = float.Parse(temp);

                    Timing.CallDelayed(time, () =>
                    {
                        Cassie.Message(message: Plugin.Instance.Config.MessageRound, isSubtitles: Plugin.Instance.Config.IsSubtiteledRound);
                        Log.Debug("Sending RoundStart CASSIE...");
                    });
                }
            }
        }

        public void OnGenAct(GeneratorActivatedEventArgs ev)
        {
            if (Plugin.MerInstalled)
            {
                int act = Generator.Get(GeneratorState.Engaged).Count();

                if (act == 2)
                {
                    string temp = Plugin.Instance.Config.WaitTimeGen.ToString();
                    float time = float.Parse(temp);
                    Timing.CallDelayed(time, () => Cassie.Message(Plugin.Instance.Config.MessageGen, isSubtitles: Plugin.Instance.Config.IsSubtiteledGen));
                    Log.Debug("Sending AllGeneratorsActivated CASSIE...");
                }
            }
        }
    }
}
