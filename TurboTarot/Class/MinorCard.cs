using System;
using System.Collections.Generic;
using System.Text;

namespace TurboTarot.Class
{
    public class MinorCard : Card
    {
        public string Suit { get; set; }
        public MinorCard(int value, string suit) : base(value)
        {
            Suit = suit;
            Name = $"{valueToMinor[value]} of {suit}";
        }
        public static List<string> suitNames = new List<string>() { "Wands", "Pentacles", "Cups", "Swords" };
        public static Dictionary<int, string> valueToMinor = new Dictionary<int, string>()
        {
            { 1, "Ace" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" }, { 6, "Six" },
            { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }, { 10, "Ten" }, { 11, "Page"}, {12, "Knight"},
            { 13, "King" }, {14, "Queen"}
        };
    }
}
