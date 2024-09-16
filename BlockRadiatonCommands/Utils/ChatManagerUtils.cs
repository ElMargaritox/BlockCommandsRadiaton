using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockRadiatonCommands.Utils
{
    public static class ChatManagerUtils
    {
        public static void SendMessage(UnturnedPlayer target, string message)       
        {

            ChatManager.serverSendMessage(message.Replace('(', '<').Replace(')', '>'), UnityEngine.Color.white, null, target.SteamPlayer(), EChatMode.GLOBAL, BlockRadiationPlugin.Instance.Configuration.Instance.Image, true);
        }
    }
}
