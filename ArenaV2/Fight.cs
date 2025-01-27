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
                    PrintCharacterName(deffender);
                    Console.WriteLine($" hit, his health dropped to {deffender.CurrentHealth}");
                }
                else
                {
                    PrintCharacterName(attacker);
                    Console.WriteLine($" missed the enemy");
                }
                Console.WriteLine("Attackers energy is " + attacker.CurrentEnergy);
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


        //private int Round(string attackerName, int attackerStrength, int attackerAgility, int attackerStamina, int attackerEnergy, string deffenderName, int deffenderAgility, int deffenderHealth)
        //{
        //    double chanceToHit = CalculateChanceToHit(attackerAgility, deffenderAgility);
        //    Random random = new Random();
        //    double chanceToBeat = random.NextDouble();
        //    //Console.WriteLine($"This is chance: {chanceToBeat}");
        //    if (attackerEnergy >= 10)
        //    {
        //        if (chanceToBeat < chanceToHit)
        //        {
        //            deffenderHealth = deffenderHealth - attackerStrength;
        //            Console.WriteLine($"{deffenderName} hit, his health dropped to {deffenderHealth}");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"{attackerName} missed the enemy");
        //        }
        //        Console.WriteLine("Attackers energy is " + attackerEnergy);
        //        attackerEnergy = attackerEnergy - 10;
        //        return deffenderHealth;
        //    }
        //    else
        //    {
        //        Console.WriteLine($"{attackerName} is too exhausted to attack");
        //    }
        //    int staminaWeight = 1;
        //    attackerEnergy = attackerEnergy + attackerStamina * staminaWeight;
        //    return deffenderHealth;
        //}

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
                    
                //string attackerName;
                //int attackerStrength;
                //int attackerAgility;
                //int attackerStamina;
                //int attackerEnergy;
                //string deffenderName;
                //int deffenderAgility;
                //int deffenderHealth;
                //if (WhoseTurn % 2 == 0)
                //{
                //    attackerName = playerCharacter.Name;
                //    attackerStrength = playerCharacter.Strength;
                //    attackerAgility = playerCharacter.Agility;
                //    attackerStamina = playerCharacter.Stamina;
                //    attackerEnergy = playerCharacter.MaxEnergy;
                //    deffenderName = npcCharacter.Name;
                //    deffenderAgility = npcCharacter.Agility;
                //    deffenderHealth = npcHealth;
                //}

                //else
                //{
                //    attackerName = npcCharacter.Name;
                //    attackerStrength = npcCharacter.Strength;
                //    attackerAgility = npcCharacter.Agility;
                //    attackerStamina = npcCharacter.Stamina;
                //    attackerEnergy = npcCharacter.MaxEnergy;
                //    deffenderName = playerCharacter.Name;
                //    deffenderAgility = playerCharacter.Agility;
                //    deffenderHealth = playerHealth;
                //}
                //var newDeffenderHealth = Round(attackerName, attackerStrength, attackerAgility, attackerStamina, attackerEnergy, deffenderName, deffenderAgility, deffenderHealth);

                //if (WhoseTurn % 2 == 0)
                //{
                //    npcHealth = newDeffenderHealth;
                    
                //}
                //else
                //{
                //    playerHealth = newDeffenderHealth;
                //}

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
