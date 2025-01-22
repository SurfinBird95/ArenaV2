using ArenaV2;

Intro.DisplayIntroText();
CreatePlayerCharacter cpp = new CreatePlayerCharacter();
var playerCharacter = cpp.ReadInputLine();


CreateNPCCharacter cnc = new CreateNPCCharacter();
cnc.NPCCharacterGenerator(playerCharacter);


//Fight.FightCalculator(playerCharacter, cnc);
Console.WriteLine();