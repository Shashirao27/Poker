using ConsoleApp1;
using ConsoleApp1.Models;
using ConsoleApp1.Enums;

namespace PokerTest
{
    public class ResultServiceShould
    {
        [Fact]
        public void StraightHandWithHighValueShouldWin()
        {
            var sut = new ResultService(GetStraightHandRegular(), GetStraightHandHigh());

            var result = sut.Evaluate();

            Assert.NotNull(result);
            Assert.Equal("HighStraightHand", result.Name);

        }

        [Fact]
        public void FlushShouldWinOverStraight()
        {
            var sut = new ResultService(GetStraightHandRegular(), GetFlushHandRegular());

            var result = sut.Evaluate();

            Assert.NotNull(result);
            Assert.Equal("FlushHandRegular", result.Name);

        }

        [Fact]
        public void TwoPairHighestShouldWin()
        {
            var sut = new ResultService(GetTwoPairHandHighest(), GetTwoPairHandLow());

            var result = sut.Evaluate();

            Assert.NotNull(result);
            Assert.Equal("TwoPairHandHighest", result.Name);

        }
        [Fact]
        public void TwoPairHighTieBreaker()
        {
            var sut = new ResultService(GetTwoPairHandHighest(), GetTwoPairHandHigh());

            var result = sut.Evaluate();

            Assert.NotNull(result);
            Assert.Equal("TwoPairHandHighest", result.Name);

        }

        [Fact]
        public void FlushShouldWinOverTwoPair()
        {
            var sut = new ResultService(GetTwoPairHandHighest(), GetFlushHandRegular());

            var result = sut.Evaluate();

            Assert.NotNull(result);
            Assert.Equal("FlushHandRegular", result.Name);

        }

        private Hand GetStraightHandRegular()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Suit.HEART, Rank.TWO));
            cards.Add(new Card(Suit.SPADE, Rank.THREE));
            cards.Add(new Card(Suit.DIAMOND, Rank.FOUR));
            cards.Add(new Card(Suit.HEART, Rank.FIVE));
            cards.Add(new Card(Suit.HEART, Rank.SIX));
            return new Hand(cards, "RegularStraightHand");
        }
        private Hand GetStraightHandHigh()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Suit.HEART, Rank.TEN));
            cards.Add(new Card(Suit.SPADE, Rank.JACK));
            cards.Add(new Card(Suit.DIAMOND, Rank.QUEEN));
            cards.Add(new Card(Suit.HEART, Rank.KING));
            cards.Add(new Card(Suit.HEART, Rank.ACE));
            return new Hand(cards, "HighStraightHand");
        }
        private Hand GetFlushHandRegular()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Suit.DIAMOND, Rank.NINE));
            cards.Add(new Card(Suit.DIAMOND, Rank.SEVEN));
            cards.Add(new Card(Suit.DIAMOND, Rank.THREE));
            cards.Add(new Card(Suit.DIAMOND, Rank.KING));
            cards.Add(new Card(Suit.DIAMOND, Rank.TEN));
            return new Hand(cards, "FlushHandRegular");
        }
        private Hand GetFlushHandHigh()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Suit.HEART, Rank.TEN));
            cards.Add(new Card(Suit.HEART, Rank.JACK));
            cards.Add(new Card(Suit.HEART, Rank.QUEEN));
            cards.Add(new Card(Suit.HEART, Rank.NINE));
            cards.Add(new Card(Suit.HEART, Rank.ACE));
            return new Hand(cards, "FlushHandHigh");
        }

        private Hand GetTwoPairHandHighest()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Suit.HEART, Rank.TEN));
            cards.Add(new Card(Suit.SPADE, Rank.TEN));
            cards.Add(new Card(Suit.CLUB, Rank.ACE));
            cards.Add(new Card(Suit.HEART, Rank.KING));
            cards.Add(new Card(Suit.HEART, Rank.ACE));
            return new Hand(cards, "TwoPairHandHighest");
        }

        private Hand GetTwoPairHandLow()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Suit.HEART, Rank.THREE));
            cards.Add(new Card(Suit.SPADE, Rank.THREE));
            cards.Add(new Card(Suit.CLUB, Rank.ACE));
            cards.Add(new Card(Suit.HEART, Rank.TWO));
            cards.Add(new Card(Suit.HEART, Rank.ACE));
            return new Hand(cards, "TwoPairHandlow");
        }

        private Hand GetTwoPairHandHigh()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Suit.HEART, Rank.TEN));
            cards.Add(new Card(Suit.SPADE, Rank.TEN));
            cards.Add(new Card(Suit.CLUB, Rank.ACE));
            cards.Add(new Card(Suit.HEART, Rank.TWO));
            cards.Add(new Card(Suit.HEART, Rank.ACE));
            return new Hand(cards, "TwoPairHandHigh");
        }
    }
}