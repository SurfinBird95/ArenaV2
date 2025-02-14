using ArenaV2;
[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace ArenaV2Tests
{
    public class ArmorTests : IDisposable
    {
        private readonly StringWriter _writer = new StringWriter();

        public ArmorTests()
        {
            Console.SetOut(_writer);
            _writer.Flush();
        }

        [Fact]
        public void ArmorProperties_PrintsAllStats()
        {
            //Arrange
            var name = "ArmorPiece";
            var price = 35;
            var armorValue = 10;
            var armorResistance = 1;
            var armorWeight = 5;
            var armor = new ArmorProperties(name, price, armorValue, armorResistance, armorWeight);

            //Act
            armor.PrintArmorProperties();

            //Assert
            Assert.Equal($"\nArmor name: {name}\nArmor price: {price}\nArmor value: {armorValue}\nWeight: {armorWeight} kg", _writer.ToString().TrimEnd());
        }

        public void Dispose()
        {
            _writer.Dispose();
        }
    }
}