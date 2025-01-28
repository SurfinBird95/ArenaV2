using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    internal class ArmorProperties
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ArmorValue { get; set; }
        public int ArmorResistance { get; set; }
        public int ArmorWeight { get; set; }
    

    public ArmorProperties(string name, int price, int armorValue, int armorResistance, int armorWeight)
        {
            Name = name;
            Price = price;
            ArmorValue = armorValue;
            ArmorResistance = armorResistance;
            ArmorWeight = armorWeight;
        }

        public void PrintArmorProperties()
        {
            Console.WriteLine("\nArmor name: " + Name + "\nArmor price: " + Price + "\n Armor value: " + ArmorValue + "\nWeight: " + ArmorWeight + " kg");
        }
    }
}
