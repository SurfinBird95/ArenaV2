using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class WeaponProperties
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int DamageLowerBound { get; set; }
        public int DamageUpperBound { get; set; }

        public WeaponProperties(string name, int price, int damageLowerBound, int damageUpperBound)
        {
            Name = name;
            Price = price;
            DamageLowerBound = damageLowerBound;
            DamageUpperBound = damageUpperBound;
        }

        public void PrintWeaponProperties()
        {
            Console.WriteLine("\nWeapon name: " + Name + "\nWeapon price: " + Price + "\n Damage: " + DamageLowerBound + " - " + DamageUpperBound);
        }
    }
}
