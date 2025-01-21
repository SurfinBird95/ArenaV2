using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class CharacterProperties
    {
        private int _strength;
        private int _health;

        private int _stamina;
        private int _energy;

        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get { return _health; } set { _health = value; } }
        public int Energy { get { return _energy; } set { _energy = value; } }
        public int Strength { get { return _strength; } set { _strength = value; _health = 20 * value; } }
        public int Agility { get; set; }
        public int Stamina { get { return _stamina; } set { _stamina = value; _energy = 20 * value; } }
        public int Charisma { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }

        public CharacterProperties(string name, int level, int strength, int agility, int stamina, int charisma, int gold, int experience)
        {
            Name = name;
            Level = level;
            Strength = strength;
            Agility = agility;
            Stamina = stamina;
            Charisma = charisma;
            Gold = gold;
            Experience = experience;
        }
    }
}
