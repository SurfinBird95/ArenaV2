using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class CharacterProperties
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Stamina { get; set; }
        public int Charisma { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }

        public CharacterProperties(string name, int level, int health, int energy, int strength, int agility, int stamina, int charisma, int gold, int experience)
        {
            Name = name;
            Level = level;
            Health = health;
            Energy = energy;
            Strength = strength;
            Agility = agility;
            Stamina = stamina;
            Charisma = charisma;
            Gold = gold;
            Experience = experience;
        }
    }
}
