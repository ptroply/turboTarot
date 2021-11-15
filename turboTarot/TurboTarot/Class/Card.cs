using System;
using System.Collections.Generic;
using System.Text;

namespace TurboTarot.Class
{
    public abstract class Card
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public bool IsFaceUp { get; private set; }
        public bool IsMajorArcana { get; set; }
        public bool IsReversed { get; set; }
        public Card(int value)
        {
            Value = value;
        }
        public void Reverse()
        {
            IsReversed = true;
            Name = $"Reversed {Name}";
        }
        public bool Flip()
        {
            if(IsFaceUp)
            {
                IsFaceUp = false;
            }
            else
            {
                IsFaceUp = true;
            }
            return IsFaceUp;
        }
    }
}
