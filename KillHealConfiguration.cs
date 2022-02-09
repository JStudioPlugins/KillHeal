using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillHeal
{
    public class KillHealConfiguration : IRocketPluginConfiguration
    {
        public byte amount { get; set; }
        public void LoadDefaults()
        {
            amount = 10;
        }
    }
}
