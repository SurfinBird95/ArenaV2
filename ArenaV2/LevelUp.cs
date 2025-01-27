using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class LevelUp
    {
        public List<int> CreateExpNeeded(PlayerCharacter playerCharacter)
        {
            List<int> expToLvlUp = new List<int>();

            for (int i = 1; i < 51; i++)
            {
                expToLvlUp.Add(i*100);
                //Console.WriteLine(expToLvlUp.Count);
            }


            return (expToLvlUp);
        }

        public void PlayerSkillsUp(PlayerCharacter playerCharacter)
        {
            int strength = playerCharacter.Strength;
            int agility = playerCharacter.Agility;
            int stamina = playerCharacter.Stamina;
            int charisma = playerCharacter.Charisma;
            int totalStats = strength + agility + stamina + charisma;

            while (strength + agility + stamina + charisma != totalStats+1)
            {
                Console.WriteLine($"\nChoose ability to lvl up:\nFor strength type 1\nFor agility type 2\nFor stamina type 3\nFor charisma type 4");
                string whichStat= Console.ReadLine();

                switch (whichStat)
                {
                    case "1":
                        strength = strength + 1;
                        playerCharacter.Strength = strength;
                        break;

                    case "2":
                        agility = agility + 1;
                        playerCharacter.Agility = agility;
                        break;

                    case "3":
                        stamina = stamina + 1;
                        playerCharacter.Stamina = stamina;
                        break;

                    case "4":
                        charisma = charisma + 1;
                        playerCharacter.Charisma = charisma;
                        break;
                }
                


                if (strength + agility + stamina + charisma != totalStats+1)
                {
                    Console.WriteLine($"You have not typed a number to lvl up one of your abilities");
                }
            }
        }

        public void LvlUpCheck(PlayerCharacter playerCharacter)
        {
            List<int> expToLvlUp = CreateExpNeeded(playerCharacter);
            int playerLvl = playerCharacter.Level;
            int playerExp = playerCharacter.Experience;


            if (playerExp >= expToLvlUp[playerLvl-1])
            {
                playerLvl = playerLvl + 1;
                playerCharacter.Level = playerLvl;

                PlayerSkillsUp(playerCharacter);
            }
        }
    }
}
