using ArenaV2;

Intro.DisplayIntroText();
CreatePlayerCharacter cpp = new CreatePlayerCharacter();
var playerCharacter = cpp.ReadInputLine();





Shop shop = new Shop();
Fight fight = new Fight();

//shop.DisplayWeapons();

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

    Console.WriteLine("\nDo you want to go to the weapon shop? Y/N");
    string goToShop = Console.ReadLine();
    if (goToShop.Equals("y", StringComparison.InvariantCultureIgnoreCase))
    {
        shop.Trade(playerCharacter);
    }

    Thread.Sleep(2000);
}

Console.WriteLine();