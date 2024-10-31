using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Dealer
{
    public class HandDealingService : IDealingService
    {
        private List<Card> CardDeck { get; set; }

        public HandDealingService(Deck deck)
        {
            CardDeck = deck.DealDeck();
        }

        public Hand DealHand(string name)
        {
            Random rnd = new Random();
            List<Card> cards = new List<Card>();
            HashSet<int> indexes = new HashSet<int>();
            for (int i = 0; i < 5; i++)
            {
                //var index = rnd.Next(0, CardDeck.Count - 1);
                //while (indexes.Contains(index)) { index = rnd.Next(0, 51); }
                //indexes.Add(index);
                //cards.Add(new Card(CardDeck[index].Suit, CardDeck[index].Rank));
                //CardDeck.RemoveAt(index);
                var index = rnd.Next(0, CardDeck.Count - 1);
                cards.Add(new Card(CardDeck[index].Suit, CardDeck[index].Rank));
                CardDeck.RemoveAt(index);
            }
            return new Hand(cards, name);
        }
    }
}
