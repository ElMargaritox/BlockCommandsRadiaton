using BlockRadiatonCommands.Utils;
using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockRadiatonCommands
{
    public class BlockRadiationPlugin : RocketPlugin<BlockRadiationConfig>
    {
        public static BlockRadiationPlugin Instance { get; private set; }
        protected override void Load()
        {
            Instance = this;
            R.Commands.OnExecuteCommand += Commands_OnExecuteCommand;
            Rocket.Core.Logging.Logger.Log("-= Block Commands In Radiation Zone =-");
            Rocket.Core.Logging.Logger.Log("Plugin By Margarita#8172");
        }


        private bool SearchCommands(string command)
        {
            return Configuration.Instance.CommandsAllowed.Any(x => x == command);
        }

        private void Commands_OnExecuteCommand(Rocket.API.IRocketPlayer caller, Rocket.API.IRocketCommand command, ref bool cancel)
        {

            if(caller is UnturnedPlayer)
            {
                UnturnedPlayer player = (UnturnedPlayer)caller;

                if (player != null)
                {
                    if (player.Player.movement.isRadiated)
                    {

                        if (SearchCommands(command.Name.ToLower()))
                        {
                            cancel = false;
                        }
                        else
                        {

                            if (!player.IsAdmin)
                            {
                                ChatManagerUtils.SendMessage(player, Translate("InRadiatonZone"));
                                cancel = true;
                            }

                        }


                        return;
                    }

                }
            }

      
        }

        public override TranslationList DefaultTranslations => new TranslationList(){

            { "InRadiatonZone", "Estas en la zona de radiacion, Para usar comandos tienes que salir de aca" },

        };

        protected override void Unload()
        {
            R.Commands.OnExecuteCommand -= Commands_OnExecuteCommand;
        }

    }
}
