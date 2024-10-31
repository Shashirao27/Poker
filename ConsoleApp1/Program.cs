// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using ConsoleApp1.Dealer;
using ConsoleApp1.Models;

Console.WriteLine("Hello, World!");
// Initialize the deck
Deck deck = new Deck();
// Initialize Hand dealing service
HandDealingService dealer = new HandDealingService(deck);

var Hand1 = dealer.DealHand("Person1");
Console.WriteLine("----Hand 1 -----");
foreach (var card in Hand1.Cards)
{
    Console.Write($" {card.Rank} - {card.Suit} ||");
}
Console.WriteLine();
Console.WriteLine("----Hand 2 ----");
var Hand2  = dealer.DealHand("Person2");
foreach (var card in Hand2.Cards)
{
    Console.Write($" {card.Rank} - {card.Suit} || ");
}

var resultService = new ResultService(Hand1,Hand2);
var result = resultService.Evaluate();
if (result != null)
{
    Console.WriteLine("Winner is :" + result.Name);
}
else
{
    Console.WriteLine("It's a Tie");
}
