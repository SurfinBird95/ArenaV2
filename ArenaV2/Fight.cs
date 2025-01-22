using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class Fight
    {
        public int CreateArenaPlayerStats(PlayerCharacter playerCharacter)
        {
            int playerHealth = playerCharacter.Health;
            int playerStamina = playerCharacter.Stamina;
            return playerHealth;
        }

        public int CreateArenaNPCStats(NPCCharacter npcCharacter)
        {
            int npcHealth = npcCharacter.Health;
            int npcStamina = npcCharacter.Stamina;
            return npcHealth;
        }


        private int FightOrderRNG()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 3);
            return randomNumber;
        }

        private double CalculateChanceToHit()
        {
            double hitChance = 0.5;
            return hitChance;
        }

        public void FightCalculator(PlayerCharacter playerCharacter, NPCCharacter npcCharacter)
        {
            int WhoseTurn = FightOrderRNG();
            int playerHealth = CreateArenaPlayerStats((PlayerCharacter)playerCharacter);
            int npcHealth = CreateArenaNPCStats((NPCCharacter)npcCharacter);


            while (playerHealth > 0 && npcHealth > 0) ;
            {
                if (WhoseTurn % 2 == 0)
                {
                    double chanceToHit = CalculateChanceToHit();
                    Random random = new Random();
                    double chanceToBeat = random.Next(0, 1);
                    if (chanceToBeat < chanceToHit)
                    {
                        npcHealth = npcHealth - playerCharacter.Strength;
                        Console.WriteLine("Enemy hit, his health dropped to " + npcHealth);
                    }
                    else
                    {
                        Console.WriteLine("You've missed the enemy");
                    }
                }

                else if (WhoseTurn % 2 != 0) ;
                {
                    double chanceToHit = CalculateChanceToHit();
                    Random random = new Random();
                    double chanceToBeat = random.Next(0, 1);
                    if (chanceToBeat < chanceToHit)
                    {
                        playerHealth = playerHealth - npcCharacter.Strength;
                        Console.WriteLine("You are hit, your health dropped to " + playerHealth);
                    }
                    else
                    {
                        Console.WriteLine("The enemy missed you");
                    }
                }
            }
        }
        
    }
}
