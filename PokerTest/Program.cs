using System;
using System.IO;
using System.Linq;

namespace PokerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var lines = File.ReadAllLines("hands.txt");

            var p1Hands = lines
                .Select(s => s.Trim())
                .Select(x => x.Split(' ')[..5].Select(s => new Card(s)).ToArray())
                .Select(s => new Hand(s));

            var p2Hands = lines
                .Select(s => s.Trim())
                .Select(x => x.Split(' ')[5..].Select(s => new Card(s)).ToArray())
                .Select(s => new Hand(s));


            var p1StraightHands = p1Hands.Where(x => x.IsStraight()).ToList();
            Console.WriteLine($"Player 1 has {p1StraightHands.Count} straight hands.");

            var p2StraightHands = p2Hands.Where(x => x.IsStraight()).ToList();
            Console.WriteLine($"Player 2 has {p2StraightHands.Count} straight hands.");

            var p1StraightFlushHands = p1Hands.Where(x => x.IsStraight() && x.IsFlush()).ToList();
            Console.WriteLine($"Player 1 has {p1StraightFlushHands.Count} straight flush hands.");

            var p2StraightFlushHands = p2Hands.Where(x => x.IsStraight() && x.IsFlush()).ToList();
            Console.WriteLine($"Player 2 has {p2StraightFlushHands.Count} straight flush hands.");
        }
    }
}
