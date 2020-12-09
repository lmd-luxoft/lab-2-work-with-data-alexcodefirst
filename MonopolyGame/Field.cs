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
        public IMonopolyType MonopolyType { get; }
        public Field(string name, IMonopolyType monopolyType)
        {
            Name = name;
            MonopolyType = monopolyType;
        }

        public override bool Equals(Object obj)
        {
            return (obj is Field field) && field.Name == Name;
        }

        // For lazyness reasons we (incorrectly) use the age as the hash code.
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
