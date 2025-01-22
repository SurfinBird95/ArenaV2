using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class CreatePlayerCharacter
    {
        public static string IntroText = "Please choose your character's stats";
       
        public void PrintCharacter(PlayerCharacter character)
        {
            Console.WriteLine(character.Name);
        }

        public PlayerCharacter ReadInputLine()
        {
            Console.WriteLine("Choose your Name");
            string name = Console.ReadLine();
            int strength = 0;
            int agility = 0;
            int stamina = 0;
            int charisma = 0;
            int totalStats = 20;

            while (strength + agility + stamina + charisma != totalStats)
            {
                Console.WriteLine($"\nChoose your Strength, Agility, Stamina and Charisma, so you have {totalStats} points total");
                strength = ReadInputStats("Strength");
                agility = ReadInputStats("Agility");
                stamina = ReadInputStats("Stamina");
                charisma = ReadInputStats("Charisma");

                if (strength + agility + stamina + charisma != totalStats)
                {
                    Console.WriteLine($"Your stats are not {totalStats} points total, they are {strength + agility + stamina + charisma} total");
                }
            }

            PlayerCharacter character = new PlayerCharacter(name, 1, strength, agility, stamina, charisma, 0, 0);
            character.PrintPlayerCharacter();
            return character;
        }

        private int ReadInputStats(string property)
        {
            bool wasParsed = false;
            int propertyVal = 0;
            while (!wasParsed)
            {
                Console.WriteLine(property);
                string propertyStr = Console.ReadLine();
                wasParsed = int.TryParse(propertyStr, out propertyVal);
                if (wasParsed)
                {
                    wasParsed = propertyVal >= 0;
                }
            }

            return propertyVal;
            
        }
    }
}
