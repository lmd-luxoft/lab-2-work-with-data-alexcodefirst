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
            IEnumerable<string> expectedPlayers = new string[] { "Peter", "Ekaterina", "Alexander" };

            var monopoly = new Monopoly(expectedPlayers);

            IEnumerable<string> actualPlayers = monopoly.GetPlayers();

            Assert.IsFalse(actualPlayers.Except(expectedPlayers).Any());

        }

        [Test]
        public void Should_ReturnCorrectFields_When_InitGame()
        {
            IEnumerable<string> players = new string[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(players);

            var expectedFields = new List<Field>
            {
                new Field("Ford", new AutoType()),
                new Field("MCDonald", new FoodType()),
                new Field("Lamoda", new ClothesType()),
                new Field("Air Baltic", new TravelType()),
                new Field("Nordavia", new TravelType()),
                new Field("Prison", new PrisonType()),
                new Field("TESLA", new AutoType())
            };

            IEnumerable<Field> actualFields = monopoly.GetFields();

            Assert.IsFalse(actualFields.Except(expectedFields).Any());
        }

        [Test]
        public void Should_BeOwner_When_BuyField()
        {
            IEnumerable<string> players = new string[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(players);

            string peter = "Peter";
            string ford = "Ford";

            monopoly.Buy(peter, ford);

            int actualPeterPoints = monopoly.GetPlayerPointsByName(peter);
            int expectedPeterPoints = 5500;

            Assert.AreEqual(actualPeterPoints, expectedPeterPoints);

            string actualOwnerName = monopoly.GetFieldOwnerByName(ford);
            string expectedOwnerName = peter;

            Assert.AreEqual(actualOwnerName, expectedOwnerName);
        }

        [Test]
        public void Should_BeCorrectTransferMoney_When_Rent()
        {
            IEnumerable<string> playerNames = new string[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(playerNames);

            string peter = "Peter";
            string ford = "Ford";

            monopoly.Buy(peter, ford);

            string ekaterina = "Ekaterina";

            monopoly.Rent(ekaterina, ford);

            int actualPeterPoints = monopoly.GetPlayerPointsByName(peter);
            int expectedPeterPoints = 5750;

            Assert.AreEqual(actualPeterPoints, expectedPeterPoints);

            int actualEkaterinaPoints = monopoly.GetPlayerPointsByName(ekaterina);
            int expectedEkaterinaPoints = 5750;

            Assert.AreEqual(actualEkaterinaPoints, expectedEkaterinaPoints);
        }
    }
}
