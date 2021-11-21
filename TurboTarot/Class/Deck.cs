using System;
using System.Collections.Generic;
using System.Text;

namespace TurboTarot.Class
{
    public class Deck
    {
        public int NumberOfCardsInDeck { get; set; }
        public bool IsShuffled { get; set; }
        public List<Card> AllCards { get; set; } = new List<Card>();
        public Deck()
        {
            foreach (string suit in MinorCard.suitNames)
            {
                for (int i = 1; i <= 14; i++)
                {
                    Card tempMinor = new MinorCard(i, suit);
                    AllCards.Add(tempMinor);
                    NumberOfCardsInDeck++;
                }
            }
            for (int i = 1; i <= 22; i++)
            {
                Card tempMajor = new MajorCard(i);
                AllCards.Add(tempMajor);
                NumberOfCardsInDeck++;
            }
        }
    }
}
