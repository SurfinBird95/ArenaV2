using ArenaV2;

Intro.DisplayIntroText();
CreatePlayerCharacter cpp = new CreatePlayerCharacter();
var playerCharacter = cpp.ReadInputLine();






Fight fight = new Fight();

while (playerCharacter.Health > 0)
{
    CreateNPCCharacter cnc = new CreateNPCCharacter();
    cnc.NPCCharacterGenerator(playerCharacter);
    var npcCharacter = cnc.NPCCharacterGenerator(playerCharacter);

    //Thread.Sleep(1000);
    fight.FightCalculator(playerCharacter, npcCharacter);
    LevelUp levelUp = new LevelUp();
    levelUp.LvlUpCheck(playerCharacter);
}

Console.WriteLine();