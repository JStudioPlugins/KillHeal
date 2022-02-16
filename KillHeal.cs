using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillHeal
{
    public class KillHeal : RocketPlugin<KillHealConfiguration>
    {
        protected override void Load()
        {
            Logger.Log("KillHeal has loaded. Heal when you kill someone!");
            UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;
        }

        private void UnturnedPlayerEvents_OnPlayerDeath(Rocket.Unturned.Player.UnturnedPlayer player, SDG.Unturned.EDeathCause cause, SDG.Unturned.ELimb limb, Steamworks.CSteamID murderer)
        {
            if (PlayerTool.getPlayer(murderer) != null)
            {
                UnturnedPlayer mplayer = UnturnedPlayer.FromCSteamID(murderer);
                mplayer.Heal(Configuration.Instance.amount);
            }
        }

        protected override void Unload()
        {
            Logger.Log("KillHeal has unloaded. Heal when you kill someone!");
            UnturnedPlayerEvents.OnPlayerDeath -= UnturnedPlayerEvents_OnPlayerDeath;
        }
    }
}
