using System;
using System.Collections.Generic;
using System.Text;

namespace TurboTarot.Class
{
    public class Spread
    {
        public string Name { get; set; }
        public int NumberOfCards { get; set; }
        public string Description { get; set; } = "";
        public Spread(string name, int numberOfCards)
        {
            Name = name;
            NumberOfCards = numberOfCards;
        }
    }
}
