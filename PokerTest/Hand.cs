using System.Linq;

namespace PokerTest
{
    public class Hand
    {
        public Hand(Card[] cards)
        {
            Cards = cards;
        }

        public Card[] Cards { get; private set; }


        public bool IsFlush()
        {
            if (Cards.Length != 5)
                return false;
            return Cards.Where(z => z.Suits == Cards[0].Suits).Count() == Cards.Length;
        }

        public bool IsStraight()
        {
            var sortedCards = Cards.OrderBy(x => x.Rank).ToArray();
            if (sortedCards[4].Rank == CardRank.Ace)
            {
                return (
                    (sortedCards[0].Rank == CardRank.Two &&
                    sortedCards[1].Rank == CardRank.Three &&
                    sortedCards[2].Rank == CardRank.Four &&
                    sortedCards[3].Rank == CardRank.Five) ||

                    (sortedCards[0].Rank == CardRank.Ten &&
                    sortedCards[1].Rank == CardRank.Jack &&
                    sortedCards[2].Rank == CardRank.Queen &&
                    sortedCards[3].Rank == CardRank.King
                    ));
            }
            else
            {
                var rank = sortedCards[0].Rank + 1;
                for (int i = 1; i < 5; i++)
                {
                    if (sortedCards[i].Rank != rank)
                        return false;
                    rank++;
                }
                return true;
            }
        }

        public override string ToString()
        {
            return string.Join(" ", Cards.Select(s => $"{s.Rank}{s.Suits}"));
        }

    }

}
