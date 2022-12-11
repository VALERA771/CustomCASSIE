using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace CustomCASSIE
{
    public class MapH
    {
        public void OnDecont(DecontaminatingEventArgs ev)
        {
            string temp = Plugin.Instance.Config.WaitTime.ToString();
            float time = float.Parse(temp);
            Timing.CallDelayed(time, () =>
            {
                Cassie.Message(message: Plugin.Instance.Config.Message, isSubtitles: Plugin.Instance.Config.IsSubtiteled);
            });
        }
    }
}
