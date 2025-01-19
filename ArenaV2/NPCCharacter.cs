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
        public NPCCharacter(string name, int level, int health, int energy, int strength, int agility, int stamina, int charisma, int gold, int experience) :
            base(name, level, health, energy, strength, agility, stamina, charisma, gold, experience)
        // base volá konstruktor rodiče
        { 
        }
    }
}
