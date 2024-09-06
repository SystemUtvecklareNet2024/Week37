using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public int Score { get; set; }

        public Player()
        {
            Score = 0;
            Name = "";
            Hand = new List<Card>();
        }
    }
}
