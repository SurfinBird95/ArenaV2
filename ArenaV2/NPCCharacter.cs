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

        public override void PrintCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enemy");
            Console.ForegroundColor = ConsoleColor.Gray;
            base.PrintCharacter();
        }
    }
}
