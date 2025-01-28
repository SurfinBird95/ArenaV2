using ArenaV2;

Intro.DisplayIntroText();
CreatePlayerCharacter cpp = new CreatePlayerCharacter();
var playerCharacter = cpp.ReadInputLine();






Fight fight = new Fight();

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
    Thread.Sleep(2000);
}

Console.WriteLine();