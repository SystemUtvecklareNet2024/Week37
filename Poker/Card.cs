using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Card
    {
        public Enum Value { get; set; }
        public Enum Suit { get; set; }

        public Card(Enum value, Enum suit)
        {
            this.Value = value;
            this.Suit = suit;
        }
    }
}
