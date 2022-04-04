using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Set.v1
{
    public class Calculator
    {
        List<Card> cardschoosen = new List<Card>();
        public List<Card> cardsMix = new List<Card>();
        public int index = 0;

        public Calculator()
        {
            List<Card> cards = new List<Card>();
            Random r = new Random();
            foreach (FigureTypes f in (FigureTypes[])Enum.GetValues(typeof(FigureTypes)))
            {
                foreach (Colors c in (Colors[])Enum.GetValues(typeof(Colors)))
                {
                    foreach (Fonts fnt in (Fonts[])Enum.GetValues(typeof(Fonts)))
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            cards.Add(new Card() { Figure = f, Color = c, Font = fnt, Count = i });
                        }
                    }
                }
            }
            cardsMix = cards.OrderBy(a => r.Next()).ToList();
        }
        public Card GetCard()
        {
            int currentIndex = index;
            index++;
            if (currentIndex < cardsMix.Count)
                return cardsMix[currentIndex];
            throw new IndexOutOfRangeException("out of massiv");
        }

    }
}
