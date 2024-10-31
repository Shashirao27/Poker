
namespace ConsoleApp1.Models
{
    public class Hand
    {
        public string Name { get; set; }
        public List<Card> Cards = new List<Card>();
        public Hand(List<Card> cards, string name)
        {
            Cards = cards.OrderBy(c => c.Rank).ToList();
            Name = name;
        }
    }
}
