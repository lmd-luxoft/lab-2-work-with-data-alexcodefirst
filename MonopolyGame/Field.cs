using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Field
    {
        public string Name { get; }
        public Player Owner { get; set; }
        public IMonopolyType MonopolyType { get; }
        public Field(string name, IMonopolyType monopolyType)
        {
            Name = name;
            MonopolyType = monopolyType;
        }
    }
}
