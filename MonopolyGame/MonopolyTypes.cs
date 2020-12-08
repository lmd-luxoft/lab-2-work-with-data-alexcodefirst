using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public interface IMonopolyType
    {
        int BuyPoints { get; }
        int RentPoints { get; }
    }

    public class AutoType : IMonopolyType
    {
        public int BuyPoints { get; } = 500;

        public int RentPoints { get; } = 250;
    }

    public class FoodType : IMonopolyType
    {
        public int BuyPoints { get; } = 250;

        public int RentPoints { get; } = 250;
    }

    public class ClothesType : IMonopolyType
    {
        public int BuyPoints { get; } = 100;

        public int RentPoints { get; } = 100;
    }

    public class TravelType : IMonopolyType
    {
        public int BuyPoints { get; } = 700;

        public int RentPoints { get; } = 300;
    }

    public class PrisonType : IMonopolyType
    {
        public int BuyPoints { get; }

        public int RentPoints { get; } = 1000;
    }

    public class BankType : IMonopolyType
    {
        public int BuyPoints { get; }

        public int RentPoints { get; } = 700;
    }
}
