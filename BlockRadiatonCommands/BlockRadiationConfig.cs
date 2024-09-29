using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockRadiatonCommands
{
    public class BlockRadiationConfig : IRocketPluginConfiguration
    {
        public string Image { get; set; }
        public List<string> CommandsAllowed { get; set; }
        public void LoadDefaults()
        {
            Image = "URL IMAGE HERE";
            CommandsAllowed = new List<string>()
            {
                "heal",
                "tell",
            };
        }
    }
}
