using NUnit.Framework;
using Moq;
using PlayersManagerLib;

namespace PlayersManagerLib.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> mockMapper;
        private string _testName;

        [OneTimeSetUp]
        public void Init()
        {
            mockMapper = new Mock<IPlayerMapper>();
            _testName = "Rohit";
        }

        [Test]
        public void RegisterNewPlayer_WithValidName_ReturnsPlayer()
        {
            mockMapper.Setup(m => m.IsPlayerNameExistsInDb(_testName)).Returns(false);

            Player player = Player.RegisterNewPlayer(_testName, mockMapper.Object);

            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo(_testName));
            Assert.That(player.Country, Is.EqualTo("India"));
        }

        [Test]
        public void RegisterNewPlayer_WithDuplicateName_ThrowsException()
        {
            mockMapper.Setup(m => m.IsPlayerNameExistsInDb(_testName)).Returns(true);

            Assert.Throws<System.ArgumentException>(() =>
            {
                Player.RegisterNewPlayer(_testName, mockMapper.Object);
            });
        }
    }
}
