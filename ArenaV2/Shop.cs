using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    internal class Shop
    {
        public static List<WeaponProperties> Weapons = new List<WeaponProperties>() 
        {
            new WeaponProperties("Fist", 0, 1, 1, 1),
            new WeaponProperties("Dagger", 100, 2, 2, 4),
            new WeaponProperties("Shortsword", 200, 4, 4, 6),
            new WeaponProperties("Spear", 300, 8, 6, 7),
            new WeaponProperties("Gladius", 500, 4, 10, 12)
        };

        public void DisplayWeapons()
        {

            Console.WriteLine("Weapon List:\n");
            int index = 1;
            foreach (var weapon in Weapons)
            {
                Console.Write($"[{index}] ");
                weapon.PrintWeaponProperties();
                index++;
            }
        }

        public void Trade(PlayerCharacter playerCharacter)
        {
            DisplayWeapons();
            Console.WriteLine($"You have {playerCharacter.Gold} gold");

            //Console.WriteLine("Do you want to buy any weapon? Choose 1-5 by weapons position.\nIf you want to quit, type 0");

            //string chosenWeaponPosition = Console.ReadLine();

            bool wasParsed = false;
            int propertyVal = 0;
            while (!wasParsed)
            {
                Console.WriteLine("Choose 1-5 by weapons position.\\nIf you want to quit, type 0");
                string chosenWeaponPosition = Console.ReadLine();
                if (chosenWeaponPosition.Equals("0")) return;

                wasParsed = int.TryParse(chosenWeaponPosition, out propertyVal);
                if (wasParsed)
                {
                    if (propertyVal >= 1 && propertyVal <= Weapons.Count)
                    {
                        if (playerCharacter.Gold >= Weapons[propertyVal-1].Price)
                        {
                            playerCharacter.Weapon = Weapons[propertyVal-1];
                            playerCharacter.Gold = playerCharacter.Gold - playerCharacter.Weapon.Price;
                            return;
                        }
                        Console.WriteLine("You don't have enought gold");
                        
                    }
                    else
                    {
                        Console.WriteLine("You have typed wrong number");
                    }
                }
            }
        }
    }
}
