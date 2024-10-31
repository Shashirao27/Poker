using ConsoleApp1.Models;

namespace ConsoleApp1.Dealer
{
    public interface IDealingService
    {
        Hand DealHand(string name);
    }
}