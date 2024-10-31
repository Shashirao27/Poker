using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Deck
    {
        private List<Card> CardDeck { get; set; }
        public Deck() { CardDeck = new List<Card>(); }

        public List<Card> DealDeck()
        {
            foreach (var rank in Enum.GetValues(typeof(Rank)).Cast<Rank>())
            {
                foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
                {
                    var card = new Card(suit, rank);
                    CardDeck.Add(card);
                }
            }
            ShuffleDeck();
            return CardDeck;
        }

        private void ShuffleDeck()
        {
            Random rnd = new Random();
            rnd.Next(0, 51);
            for (int i = 0; i < 100; i++)
            {
                var random1 = rnd.Next(0, 51);
                var random2 = rnd.Next(0, 51);
                (CardDeck[random2], CardDeck[random1]) = (CardDeck[random1], CardDeck[random2]);
            }

        }

    }
}
