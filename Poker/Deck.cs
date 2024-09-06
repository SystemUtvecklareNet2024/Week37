using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum CardValue { Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14 }
    public enum CardSuit { Hearts, Spades, Clubs, Diamonds }

    internal class Deck
    {
        private List<Card> cardDeck;
        private List<Card> thrownCards;

        public Deck()
        {
            cardDeck = new List<Card>();
            thrownCards = new List<Card>();
            CreateDeck();
        }

        private void CreateDeck()
        {
            CardValue value;
            CardSuit suit;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    Card newCard = new Card(value = (CardValue)j, suit = (CardSuit)i);
                    cardDeck.Add(newCard);
                }
            }
        }

        public void Shuffle()
        {
            // LINQ to shuffle the list with OrderBy and Random.next.
            cardDeck = cardDeck.OrderBy(x=> Random.Shared.Next()).ToList();
        }

        public void ResetDeck()
        {
            cardDeck.Clear();
            thrownCards.Clear();
            CreateDeck();
        }

        public void ShowAllCards()
        {
            foreach (Card card in cardDeck)
            {
                Console.WriteLine(card.Value + " of " + card.Suit);
            }
        }

        public Card ShowTopCard()
        {
            Card temp = cardDeck.Last();
            thrownCards.Add(temp);
            cardDeck.Remove(temp);
            Console.WriteLine($"{temp.Value} of {temp.Suit}");

            return temp;
        }

        public Card DealPlayerCard()
        {
            Card temp = cardDeck.Last();
            cardDeck.Remove(temp);

            Console.WriteLine($"{temp.Value} of {temp.Suit}");

            return temp;
        }

        public Card ShowTopThrownCard()
        {
            return thrownCards.Last();
        }

    }
}
