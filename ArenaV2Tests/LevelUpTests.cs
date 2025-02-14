using ArenaV2;

namespace ArenaV2Tests
{
    public class LevelUpTests : IDisposable
    {
        private readonly StringWriter _writer;
        private StringReader _reader;

        private PlayerCharacter _character;
        private LevelUp _levelUp = new();
        public LevelUpTests()
        {
            _writer = new StringWriter();
            Console.SetOut(_writer);
            _character = new PlayerCharacter("Pepa", 1, 1, 1, 1, 1, 0, 0);
        }

        [Fact]
        public void LevelUp_IncreasesStrength()
        {
            //Arrange
            _reader = new StringReader("1");
            Console.SetIn(_reader);

            //Act
            _levelUp.PlayerSkillsUp(_character);

            //Assert
            Assert.Equal(2, _character.Strength);
            Assert.Equal(5, _character.Strength + _character.Agility + _character.Stamina + _character.Charisma);
        }

        [Fact]
        public void LevelUp_IncreasesAgility()
        {
            //Arrange
            _reader = new StringReader("2");
            Console.SetIn(_reader);

            //Act
            _levelUp.PlayerSkillsUp(_character);

            //Assert
            Assert.Equal(2, _character.Agility);
            Assert.Equal(5, _character.Strength + _character.Agility + _character.Stamina + _character.Charisma);
        }

        [Fact]
        public void LevelUp_IncreasesStamina()
        {
            //Arrange
            _reader = new StringReader("3");
            Console.SetIn(_reader);

            //Act
            _levelUp.PlayerSkillsUp(_character);

            //Assert
            Assert.Equal(2, _character.Stamina);
            Assert.Equal(5, _character.Strength + _character.Agility + _character.Stamina + _character.Charisma);
        }

        [Fact]
        public void LevelUp_IncreasesCharisma()
        {
            //Arrange
            _reader = new StringReader("4");
            Console.SetIn(_reader);

            //Act
            _levelUp.PlayerSkillsUp(_character);

            //Assert
            Assert.Equal(2, _character.Charisma);
            Assert.Equal(5, _character.Strength + _character.Agility + _character.Stamina + _character.Charisma);
        }

        public void Dispose()
        {
            _reader.Dispose();
            _writer.Dispose();
        }
    }
}
