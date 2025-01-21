using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class NPCCharacter : CharacterProperties
    {
        // Constructor
        public NPCCharacter(string name, int level, int strength, int agility, int stamina, int charisma, int gold, int experience) :
            base(name, level, strength, agility, stamina, charisma, gold, experience)
        // base volá konstruktor rodiče
        { 
        }

        public void PrintNPCCharacter()
        {
            Console.WriteLine("Enemy has: \n" + this.Health + " max health\n" + this.Agility + " agility\n" + this.Strength + " strength\n" + this.Stamina + " stamina\n" + this.Energy + " max energy\n" + this.Charisma + " charisma");
        }
    }
}
