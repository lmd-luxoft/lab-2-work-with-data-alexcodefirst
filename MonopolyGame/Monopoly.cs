using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyGame
{
    public class Monopoly
    {
        private const int DefaultPlayerPoints = 6000;

        private Dictionary<string, int> _players;

        private readonly Dictionary<Field, string> _fields = new Dictionary<Field, string>
        {
            { new Field("Ford", new AutoType()), null },
            { new Field("MCDonald", new FoodType()), null },
            { new Field("Lamoda", new ClothesType()), null },
            { new Field("Air Baltic", new TravelType()), null },
            { new Field("Nordavia", new TravelType()), null },
            { new Field("Prison", new PrisonType()), null },
            { new Field("TESLA", new AutoType()), null }
        };

        public Monopoly(IEnumerable<string> playerNames)
        {
            InitPlayers(playerNames);
        }

        private void InitPlayers(IEnumerable<string> playerNames)
        {
            _players = new Dictionary<string, int>();

            foreach (string playerName in playerNames)
            {
                _players.Add(playerName, DefaultPlayerPoints);
            }
        }

        public IEnumerable<string> GetPlayers()
        {
            return _players.Keys;
        }

        public int GetPlayerPointsByName(string playerName)
        {
            return _players[playerName];
        }

        public IEnumerable<Field> GetFields()
        {
            return _fields.Keys;
        }

        public string GetFieldOwnerByName(string fieldName)
        {
            return _fields[GetFieldByName(fieldName)];
        }

        public Field GetFieldByName(string fieldName)
        {
            var field = _fields.Keys.FirstOrDefault(x => x.Name == fieldName);

            if (field == null)
                throw new ArgumentNullException(nameof(field));

            return field;
        }

        public void Buy(string playerName, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
                throw new ArgumentNullException(nameof(playerName));

            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentNullException(nameof(fieldName));

            Field field = GetFieldByName(fieldName);

            int playerPoints = GetPlayerPointsByName(playerName);

            _players[playerName] = playerPoints - field.MonopolyType.BuyPoints;

            _fields[field] = playerName;
        }

        public void Rent(string playerName, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
                throw new ArgumentNullException(nameof(playerName));

            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentNullException(nameof(fieldName));

            Field field = GetFieldByName(fieldName);

            var owner = _fields[field];

            if (owner != null)
            {
                _players[owner] += field.MonopolyType.RentPoints;

                _players[playerName] -= field.MonopolyType.RentPoints;
            }
        }
    }

}
