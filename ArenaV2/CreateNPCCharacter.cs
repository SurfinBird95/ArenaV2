using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArenaV2
{
    public class CreateNPCCharacter
    {
        public NPCCharacter NPCCharacterGenerator(PlayerCharacter PlayerStats)
        {
            double NPCDifficulty = 0.7;
            int PlayerCharPoints = PlayerStats.Agility + PlayerStats.Strength + PlayerStats.Stamina + PlayerStats.Charisma;
            int NPCStatsAmmount = (int)Math.Ceiling(PlayerCharPoints * NPCDifficulty);
            NPCCharacter NPCStats = new NPCCharacter("Vojta", PlayerStats.Level, 1, 1, 1, 1, 0, 0);
            int numberOfStartingStats = (NPCStats.Strength + NPCStats.Agility + NPCStats.Stamina + NPCStats.Charisma);

            for (int i = 0; i < NPCStatsAmmount - numberOfStartingStats; i++)
            {
                int statNumber = CharRandomNumberGenerator();

                switch (statNumber)
                {
                    case 0:
                        NPCStats.Agility += 1;
                        break;

                    case 1:
                        NPCStats.Strength += 1;
                        break;

                    case 2:
                        NPCStats.Stamina += 1;
                        break;

                    case 3:
                        NPCStats.Charisma += 1;
                        break;
                }
            }

            NPCStats.CurrentHealth = NPCStats.MaxHealth;
            NPCStats.CurrentEnergy = NPCStats.MaxEnergy;
            NPCStats.NameColor = ConsoleColor.Red;

            NPCStats.PrintCharacter();
            return NPCStats;
        }

        private int CharRandomNumberGenerator()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 4);
            //Console.WriteLine("Random number is:" + randomNumber);
            return randomNumber;
        }
    }
}
