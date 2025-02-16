using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArenaV2
{
    internal class Game
    {
        private readonly string characterFilePath = "Character.json";

        private PlayerCharacter playerCharacter;
        private Shop shop = new Shop();
        private Fight fight = new Fight();


        public void StartGame()
        {
            ShowIntro();
            ReadCharacter();
            ShowFight();
        }

        public void ShowIntro()
        {
            Intro.DisplayIntroText();
        }

        public void ReadCharacter()
        {
            bool existsSave = File.Exists(characterFilePath);
            if (existsSave) 
            {
                Console.WriteLine("Do you want to load previous save? Y/N");
                var load = Console.ReadLine();
                if (load.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    var characterString = File.ReadAllText(characterFilePath);
                    playerCharacter = JsonSerializer.Deserialize<PlayerCharacter>(characterString);
                    return;
                }
            }

            var cpp = new CreatePlayerCharacter();
            playerCharacter = cpp.ReadInputLine();
        }

        public void ShowFight()
        {
            while (playerCharacter.MaxHealth > 0)
            {
                Console.Clear();
                playerCharacter.CurrentHealth = playerCharacter.MaxHealth;
                playerCharacter.CurrentEnergy = playerCharacter.MaxEnergy;

                CreateNPCCharacter cnc = new CreateNPCCharacter();
                var npcCharacter = cnc.NPCCharacterGenerator(playerCharacter);

                //Thread.Sleep(1000);
                fight.FightCalculator(playerCharacter, npcCharacter);
                LevelUp levelUp = new LevelUp();
                levelUp.LvlUpCheck(playerCharacter);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ROUND OVER");
                Console.ForegroundColor = ConsoleColor.Gray;

                ShowAfterFight();
                playerCharacter.Armor.ArmorValue = playerCharacter.Armor.ArmorMaxValue;
            }
        }

        public void ShowAfterFight()
        {
            Console.WriteLine("\nDo you want to go to the weapon shop? Y/N");
            string goToShop = Console.ReadLine();
            if (goToShop.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                shop.Trade(playerCharacter);
                Thread.Sleep(2000);
            }
            SaveCharacter();
        }

        public void SaveCharacter()
        {
            string jsonString = JsonSerializer.Serialize(playerCharacter);
            File.WriteAllText(characterFilePath, jsonString);
        }
    }
}
