// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MonopolyGame
{
    [TestFixture]
    public class MonopolyTest
    {
        [Test]
        public void Should_ReturnCorrectPlayers_When_InitGame()
        {
            IEnumerable<string> playerNames = new string[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(playerNames);

            IEnumerable<Player> actualPlayers = monopoly.GetPlayers();

            Assert.AreEqual(playerNames.Count(), actualPlayers.Count());
            //
            foreach (var playerName in playerNames)
            {
                Assert.IsTrue(actualPlayers.Any(x => x.Name == playerName));
            }

        }
        [Test]
        public void Should_ReturnCorrectFields_When_InitGame()
        {
            IEnumerable<string> playerNames = new string[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(playerNames);

            var expectedFields = new List<Field>
            {
                new Field("Ford", new AutoType()),
                new Field("MCDonald", new FoodType()),
                new Field("Lamoda", new ClothesType()),
                new Field("Air Baltic", new TravelType()),
                new Field("Nordavia", new TravelType()),
                new Field("Prison", new PrisonType()),
                new Field("MCDonald", new FoodType()),
                new Field("TESLA", new AutoType())
            };

            IEnumerable<Field> actualFields = monopoly.GetFields();

            Assert.AreEqual(expectedFields.Count(), actualFields.Count());

            foreach (var actualField in actualFields)
            {
                Assert.IsTrue(expectedFields.Any(x => x.Name == actualField.Name));
            }
        }

        [Test]
        public void Should_BeOwner_When_BuyField()
        {
            IEnumerable<string> playerNames = new string[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(playerNames);

            Field ford = monopoly.GetFieldByName("Ford");
            Player peter = monopoly.GetPlayerByName("Peter");
            monopoly.Buy(peter, ford);

            int actualPeterPoints = peter.Points;
            int expectedPeterPoints = 5500;

            Assert.AreEqual(actualPeterPoints, expectedPeterPoints);

            string actualOwnerName = ford.Owner.Name;
            string expectedOwnerName = peter.Name;

            Assert.AreEqual(actualOwnerName, expectedOwnerName);
        }

        [Test]
        public void Should_BeCorrectTransferMoney_When_Rent()
        {
            IEnumerable<string> playerNames = new string[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(playerNames);

            Field ford = monopoly.GetFieldByName("Ford");
            Player peter = monopoly.GetPlayerByName("Peter");
            monopoly.Buy(peter, ford);
            Player ekaterina = monopoly.GetPlayerByName("Ekaterina");
            monopoly.Rent(ekaterina, ford);

            int actualPeterPoints = peter.Points;
            int expectedPeterPoints = 5750;

            Assert.AreEqual(actualPeterPoints, expectedPeterPoints);

            int actualEkaterinaPoints = ekaterina.Points;
            int expectedEkaterinaPoints = 5750;

            Assert.AreEqual(actualEkaterinaPoints, expectedEkaterinaPoints);
        }
    }
}
