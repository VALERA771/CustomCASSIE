using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace CustomCASSIE
{
    public class Handlers
    {
        public void OnDecont(DecontaminatingEventArgs ev)
        {
            string temp = Plugin.Instance.Config.WaitTimeLCZ.ToString();
            float time = float.Parse(temp);
            Timing.CallDelayed(time, () =>
            {
                Cassie.Message(message: Plugin.Instance.Config.MessageLCZ, isSubtitles: Plugin.Instance.Config.IsSubtiteledLCZ);
            });
        }

        public void OnRnStart()
        {
            if (Plugin.Instance.Config.WaitTimeRn == 0)
            {
                Timing.CallDelayed(1f, () =>
                {
                    Cassie.Message(message: Plugin.Instance.Config.MessageRound, isSubtitles: Plugin.Instance.Config.IsSubtiteledRound);
                });
            }
            else
            {
                string temp = Plugin.Instance.Config.WaitTimeRn.ToString();
                float time = float.Parse(temp);

                Timing.CallDelayed(time, () =>
                {
                    Cassie.Message(message: Plugin.Instance.Config.MessageRound, isSubtitles: Plugin.Instance.Config.IsSubtiteledRound);
                });
            }
        }
    }
}
