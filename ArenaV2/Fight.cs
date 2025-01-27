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

        private double CalculateChanceToHit(double attackerAgility, double deffenderAgility)
        {
            //double hitChance = 0.5;
            double hitChance = attackerAgility / (attackerAgility + deffenderAgility);
            //Console.WriteLine("Chance to hit is " + hitChance);
            return hitChance;
        }

        private int Round(string attackerName, int attackerStrength, int attackerAgility, int attackerStamina, int attackerEnergy, string deffenderName, int deffenderAgility, int deffenderHealth)
        {
            double chanceToHit = CalculateChanceToHit(attackerAgility, deffenderAgility);
            Random random = new Random();
            double chanceToBeat = random.NextDouble();
            //Console.WriteLine($"This is chance: {chanceToBeat}");
            if (attackerEnergy >= 10)
            {
                if (chanceToBeat < chanceToHit)
                {
                    deffenderHealth = deffenderHealth - attackerStrength;
                    Console.WriteLine($"{deffenderName} hit, his health dropped to {deffenderHealth}");
                }
                else
                {
                    Console.WriteLine($"{attackerName} missed the enemy");
                }
                Console.WriteLine("Attackers energy is " + attackerEnergy);
                attackerEnergy = attackerEnergy - 10;
                return deffenderHealth;
            }
            else 
            {
                Console.WriteLine($"{attackerName} is too exhausted to attack");
            }
            int staminaWeight = 1;
            attackerEnergy = attackerEnergy + attackerStamina * staminaWeight;
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
                int attackerAgility;
                int attackerStamina;
                int attackerEnergy;
                string deffenderName;
                int deffenderAgility;
                int deffenderHealth;
                if (WhoseTurn % 2 == 0)
                {
                    attackerName = playerCharacter.Name;
                    attackerStrength = playerCharacter.Strength;
                    attackerAgility = playerCharacter.Agility;
                    attackerStamina = playerCharacter.Stamina;
                    attackerEnergy = playerCharacter.Energy;
                    deffenderName = npcCharacter.Name;
                    deffenderAgility = npcCharacter.Agility;
                    deffenderHealth = npcHealth;
                }

                else
                {
                    attackerName = npcCharacter.Name;
                    attackerStrength = npcCharacter.Strength;
                    attackerAgility = npcCharacter.Agility;
                    attackerStamina = npcCharacter.Stamina;
                    attackerEnergy = npcCharacter.Energy;
                    deffenderName = playerCharacter.Name;
                    deffenderAgility = playerCharacter.Agility;
                    deffenderHealth = playerHealth;
                }
                var newDeffenderHealth = Round(attackerName, attackerStrength, attackerAgility, attackerStamina, attackerEnergy, deffenderName, deffenderAgility, deffenderHealth);

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
