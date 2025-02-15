using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class CharacterProperties
    {
        private int _strength;
        private int _maxHealth;

        private int _stamina;
        private int _maxEnergy;

        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
        public int CurrentHealth { get; set; }
        public int MaxEnergy { get { return _maxEnergy; } set { _maxEnergy = value; } }
        public int CurrentEnergy { get; set; }
        public int Strength { get { return _strength; } set { _strength = value; _maxHealth = 20 * value; } }
        public int Agility { get; set; }
        public int Stamina { get { return _stamina; } set { _stamina = value; _maxEnergy = 20 * value; } }
        public int Charisma { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }
        public ConsoleColor NameColor { get; set; }

        public WeaponProperties Weapon = Shop.Weapons[0];
        public ArmorProperties Armor = Shop.Armors[0];

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

        public virtual void PrintCharacter()
        {
            Console.WriteLine(" character has: \n" + this.CurrentHealth + "/" + this.MaxHealth + " health\n" + this.Agility + " agility\n" + this.Strength + " strength\n" + this.Stamina + " stamina\n" + this.CurrentEnergy + "/" + this.MaxEnergy + " energy\n" + this.Charisma + " charisma\n" + "Weapon: " + this.Weapon.Name);

        }
    }
}
