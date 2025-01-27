using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class Fight
    {
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

        private int Round(string attackerName, int attackerStrength, string deffenderName, int deffenderHealth)
        {
            double chanceToHit = CalculateChanceToHit();
            Random random = new Random();
            double chanceToBeat = random.NextDouble();
            //Console.WriteLine($"This is chance: {chanceToBeat}");
            if (chanceToBeat < chanceToHit)
            {
                deffenderHealth = deffenderHealth - attackerStrength;
                Console.WriteLine($"{deffenderName} hit, his health dropped to {deffenderHealth}");
            }
            else
            {
                Console.WriteLine($"{attackerName} missed the enemy");
            }
            return deffenderHealth;
        }

        public void FightCalculator(PlayerCharacter playerCharacter, NPCCharacter npcCharacter)
        {
            bool playerTurn = false;
            int WhoseTurn = FightOrderRNG();
            int playerHealth = playerCharacter.Health;
            int npcHealth = npcCharacter.Health;


            while (playerHealth > 0 && npcHealth > 0)
            {
                string attackerName;
                int attackerStrength;
                string deffenderName;
                int deffenderHealth;
                if (WhoseTurn % 2 == 0)
                {
                    attackerName = playerCharacter.Name;
                    attackerStrength = playerCharacter.Strength;
                    deffenderName = npcCharacter.Name;
                    deffenderHealth = npcHealth;
                }

                else
                {
                    attackerName = npcCharacter.Name;
                    attackerStrength = npcCharacter.Strength;
                    deffenderName = playerCharacter.Name;
                    deffenderHealth = playerHealth;
                }
                var newDeffenderHealth = Round(attackerName, attackerStrength, deffenderName, deffenderHealth);

                if (WhoseTurn % 2 == 0)
                {
                    npcHealth = newDeffenderHealth;
                }
                else
                {
                    playerHealth = newDeffenderHealth;
                }

                WhoseTurn++;
            }

            if (npcHealth <= 0)
            {
                Console.WriteLine("You have defeated the Enemy");
                playerCharacter.Gold = playerCharacter.Gold + playerCharacter.Charisma * 10;
                playerCharacter.Experience = playerCharacter.Experience + npcCharacter.Level * 10;
            }
            else
            {
                Console.WriteLine("You have been defeated");
            }

        }
        
    }
}
