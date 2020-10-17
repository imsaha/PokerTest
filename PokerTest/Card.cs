using System;

namespace PokerTest
{
    public class Card
    {
        public Card(string cardText)
        {
            if (cardText.Length != 2)
                throw new ArgumentOutOfRangeException("Invalid value passed in the parameter.");

            this.Rank = getRank(cardText[0]);
            this.Suits = getSuits(cardText[1]);
        }


        private CardRank getRank(char rank)
        {
            return (rank) switch
            {
                '2' => CardRank.Two,
                '3' => CardRank.Three,
                '4' => CardRank.Four,
                '5' => CardRank.Five,
                '6' => CardRank.Six,
                '7' => CardRank.Seven,
                '8' => CardRank.Eight,
                '9' => CardRank.Nine,
                'T' => CardRank.Ten,
                'J' => CardRank.Jack,
                'Q' => CardRank.Queen,
                'K' => CardRank.King,
                'A' => CardRank.Ace,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private CardSuits getSuits(char suit)
        {
            return (suit) switch
            {
                'C' => CardSuits.Clubs,
                'D' => CardSuits.Diamonds,
                'H' => CardSuits.Hearts,
                'S' => CardSuits.Spades,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }


        public CardRank Rank { get; private set; }
        public CardSuits Suits { get; private set; }
    }

}
