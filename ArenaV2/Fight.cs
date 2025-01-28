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

        private void Round(CharacterProperties attacker, CharacterProperties deffender)
        {
            double chanceToHit = CalculateChanceToHit(attacker.Agility, deffender.Agility);
            Random random = new Random();
            double chanceToBeat = random.NextDouble();
            if (attacker.CurrentEnergy >= 10)
            {
                if (chanceToBeat < chanceToHit)
                {
                    deffender.CurrentHealth = deffender.CurrentHealth - attacker.Strength;
                    PrintCharacterName(attacker);
                    Console.Write(" hit ");
                    PrintCharacterName(deffender);
                    Console.WriteLine($", his health dropped to {deffender.CurrentHealth}");
                }
                else
                {
                    PrintCharacterName(attacker);
                    Console.WriteLine($" missed the enemy");
                }
                PrintCharacterName(attacker);
                Console.WriteLine("'s energy is " + attacker.CurrentEnergy);
                attacker.CurrentEnergy = attacker.CurrentEnergy - 10;
                return;
            }
            else
            {
                PrintCharacterName(attacker);
                Console.WriteLine($" is too exhausted to attack");
            }
            int staminaWeight = 1;
            attacker.CurrentEnergy = attacker.CurrentEnergy + attacker.Stamina * staminaWeight;
            return;
        }

        private void PrintCharacterName(CharacterProperties character)
        {
            Console.ForegroundColor = character.NameColor;
            Console.Write(character.Name);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void FightCalculator(PlayerCharacter playerCharacter, NPCCharacter npcCharacter)
        {
            bool playerTurn = false;
            int WhoseTurn = FightOrderRNG();
            //int playerHealth = playerCharacter.MaxHealth;
            //int npcHealth = npcCharacter.MaxHealth;


            while (playerCharacter.CurrentHealth > 0 && npcCharacter.CurrentHealth > 0)
            {
                Thread.Sleep(200);
                if (WhoseTurn % 2 == 0)
                {
                    Round(npcCharacter, playerCharacter);
                }
                else
                {
                    Round(playerCharacter, npcCharacter);
                }
                    
                WhoseTurn++;
            }

            if (npcCharacter.CurrentHealth <= 0)
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
