using System;
using System.Collections.Generic;
using System.Text;

namespace TurboTarot.Class
{
    public class MajorCard : Card
    {
        public string Summary { get; private set; }
        public MajorCard(int value) : base(value)
        {
            Name = valueToMajor[value];
            Summary = valueToSummary[value];
            IsMajorArcana = true;
        }
        public static Dictionary<int, string> valueToMajor = new Dictionary<int, string>()
        {
            { 22, "XXII. The Fool" }, { 1, "I. The Magician" }, { 2, "II. The High Priestess" }, { 3, "III. The Empress" },
            { 4, "IV. The Emperor" }, { 5, "V. The Hierophant" }, { 6, "VI. The Lovers" }, { 7, "VII. The Chariot" },
            { 8, "VIII. Strength" }, { 9, "IX. The Hermit" }, { 10, "X. Wheel of Fortune" }, { 11, "XI. Justice" },
            { 12, "XII. The Hanged Man" }, { 13, "XIII. Death" }, { 14, "XIV. Temperance" }, { 15, "XV. The Devil" },
            { 16, "XVI. The Tower" }, { 17, "XVII. The Star" }, { 18, "XVIII. The Moon" }, { 19, "XIX. The Sun" },
            { 20, "XX. Judgement" }, { 21, "XXI. The World" }
        };
        public static Dictionary<int, string> valueToSummary = new Dictionary<int, string>()
        {
            { 22, "The beginning and the end." }, { 1, "I. The Magician" }, { 2, "II. The High Priestess" }, { 3, "III. The Empress" },
            { 4, "IV. The Emperor" }, { 5, "V. The Hierophant" }, { 6, "VI. The Lovers" }, { 7, "VII. The Chariot" },
            { 8, "VIII. Strength" }, { 9, "IX. The Hermit" }, { 10, "X. Wheel of Fortune" }, { 11, "XI. Justice" },
            { 12, "XII. The Hanged Man" }, { 13, "XIII. Death" }, { 14, "XIV. Temperance" }, { 15, "XV. The Devil" },
            { 16, "XVI. The Tower" }, { 17, "XVII. The Star" }, { 18, "XVIII. The Moon" }, { 19, "XIX. The Sun" },
            { 20, "XX. Judgement" }, { 21, "XXI. The World" }
        };

    }
}
