using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class CreateNPCCharacter
    {
        public void NPCCharacterGenerator(PlayerCharacter PlayerStats)
        {
            double NPCDifficulty = 0.7;
            int PlayerCharPoints = PlayerStats.Agility + PlayerStats.Strength + PlayerStats.Stamina + PlayerStats.Charisma;
            int NPCStatsAmmount = (int)Math.Ceiling(PlayerCharPoints * NPCDifficulty);

            for (int i = 0; i < NPCStatsAmmount; i++)
            { 
                
            }
        }
    }
}
