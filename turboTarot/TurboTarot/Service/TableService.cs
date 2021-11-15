using System;
using System.Collections.Generic;
using TurboTarot.Class;
using System.Text;

namespace TurboTarot.Service
{
    public class TableService
    {
        private readonly Deck PlayDeck = new Deck();
        private bool IsDailyDrawn { get; set; }
        private Card DailyCard { get; set; }
        private Spread[] Spreads
        {
            get
            {
                List<Spread> allSpreads = new List<Spread>();

                Spread threeCard = new Spread("Three Card", 3);
                threeCard.Description = "Present, Past, and Future.";
                allSpreads.Add(threeCard);

                Spread fiveCard = new Spread("Five Card", 5);
                fiveCard.Description = "Situation, Solution, and the Path Forward.";
                allSpreads.Add(fiveCard);

                Spread crossSpread = new Spread("Celtic Cross", 10);
                crossSpread.Description = "The oldest and most classic Tarot spread.";
                allSpreads.Add(crossSpread);

                return allSpreads.ToArray();
            }
        }
        public TableService()
        {
            if (!PlayDeck.IsShuffled)
            {
                Shuffle(999);
            }
        }
        public Card[] GetBirthCards(string birthdate)
        {
            Card[] cardArray = new Card[3];
            // todo move bday parser to custom getter?
            if (birthdate.Length > 0)
            {
                List<int> nums = new List<int>();
                foreach (char digit in birthdate)
                {
                    if (int.TryParse(digit.ToString(), out int num))
                    {
                        nums.Add(num);
                    }
                }
                int result = 0;
                while (result == 0 || result > 22)
                {
                    result = 0;
                    for (int i = 0; i < nums.Count; i++)
                    {
                        result += nums[i];
                    }
                    nums.RemoveRange(0, nums.Count);
                    foreach (char digit in result.ToString())
                    {
                        nums.Add(int.Parse(digit.ToString()));
                    }
                }
                int result2 = 0;
                while (result2 == 0)
                {
                    if (result > 9)
                    {
                        foreach (int digit in nums)
                        {
                            result2 += digit;
                        }
                    }
                    else
                    {
                        for (int i = 10; i <= 21; i++)
                        {
                            string numStr = i.ToString();
                            if (int.Parse(numStr[0].ToString()) + int.Parse(numStr[1].ToString()) == result)
                            {
                                result2 = int.Parse(numStr);
                            }
                        }
                    }
                }
                cardArray[0] = new MajorCard(result);
                cardArray[1] = new MajorCard(result2);
                if (result == 19)
                {
                    cardArray[2] = new MajorCard(1);
                }
            }
            return cardArray;
        }
        public Card DrawDailyCard()
        {
            if (!IsDailyDrawn)
            {
                DailyCard = DrawOne();
            }
            IsDailyDrawn = true;
            return DailyCard;
        }
        public Card DrawOne()
        {
            Card cardDrawn = PlayDeck.AllCards[0];
            PlayDeck.AllCards.RemoveAt(0);
            return cardDrawn;
        }
        public Card[] DrawHand(int num)
        {
            Card[] cardArray = new Card[num];
            for (int i = 0; i < cardArray.Length; i++)
            {
                cardArray[i] = DrawOne();
            }
            return cardArray;
        }
        public string[] getSpreads()
        {
            string[] spreadsArray = new string[Spreads.Length];
            for(int i = 0; i < Spreads.Length; i++)
            {
                spreadsArray[i] = Spreads[i].Name;
            }
            return spreadsArray;
        }
        public Spread selectSpread(int selection)
        {
            if (isOutOfCards(Spreads[selection].NumberOfCards, PlayDeck.NumberOfCardsInDeck))
            {
                throw new ArgumentException();
            }
            return Spreads[selection];
        }
        public void Shuffle(int num)
        {
            Random r = new Random();
            for (int i = 0; i < num; i++)
            {
                int randomCard1 = r.Next(PlayDeck.AllCards.Count);
                int randomCard2 = r.Next(PlayDeck.AllCards.Count);
                Card tempCard = PlayDeck.AllCards[randomCard2];
                PlayDeck.AllCards[randomCard2] = PlayDeck.AllCards[randomCard1];
                PlayDeck.AllCards[randomCard1] = tempCard;
            }
            foreach (Card card in PlayDeck.AllCards)
            {
                int reverseSwitch = r.Next(2);
                if (reverseSwitch == 1)
                {
                    card.Reverse();
                }
            }
            PlayDeck.IsShuffled = true;
        }
        public bool isOutOfCards(int need, int have)
        {
            if(need > have)
            {
                return true;
            }
            return false;
        }
    }
}
