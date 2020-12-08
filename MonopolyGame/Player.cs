using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Player
    {
        private const int DefaultPoints = 6000;
        public string Name { get; }
        public int Points { get; set; }
        public Player(string name)
        {
            Name = name;
            Points = DefaultPoints;
        }

        public override bool Equals(Object obj)
        {
            return (obj is Player player) && player.Name == Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
