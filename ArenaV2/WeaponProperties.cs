using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class WeaponProperties : Item
    {

        public int DamageLowerBound { get; set; }
        public int DamageUpperBound { get; set; }

        public WeaponProperties(string name, int price, int weight, int damageLowerBound, int damageUpperBound)
            : base(name, price, weight)

        {
            DamageLowerBound = damageLowerBound;
            DamageUpperBound = damageUpperBound;
        }

        public void PrintWeaponProperties()
        {
            Console.WriteLine("Weapon name: " + Name + "\nWeapon price: " + Price + "\nDamage: " + DamageLowerBound + " - " + DamageUpperBound);
        }
    }
}