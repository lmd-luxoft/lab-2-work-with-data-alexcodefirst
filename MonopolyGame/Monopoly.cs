using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyGame
{
    public class Monopoly
    {
        private List<Player> _players;

        private readonly List<Field> _fields = new List<Field>
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

        public Monopoly(IEnumerable<string> playerNames)
        {
            InitPlayers(playerNames);
        }

        private void InitPlayers(IEnumerable<string> playerNames)
        {
            _players = new List<Player>();

            foreach (string playerName in playerNames)
            {
                _players.Add(new Player(playerName));
            }
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _players;
        }

        public Player GetPlayerByName(string name)
        {
            return _players.FirstOrDefault(player => player.Name == name);
        }

        public IEnumerable<Field> GetFields()
        {
            return _fields;
        }

        public Field GetFieldByName(string name)
        {
            return _fields.FirstOrDefault(field => field.Name == name);
        }

        public void Buy(Player player, Field field)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (field == null)
                throw new ArgumentNullException(nameof(field));

            player.Points -= field.MonopolyType.BuyPoints;

            field.Owner = player;
        }

        public void Rent(Player player, Field field)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (field == null)
                throw new ArgumentNullException(nameof(field));

            var owner = field.Owner;

            if (owner != null)
            {
                owner.Points += field.MonopolyType.RentPoints;

                player.Points -= field.MonopolyType.RentPoints;
            }
        }
    }

}
