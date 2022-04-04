using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace Set.v1
{
    public class Checker
    {
        List<Card> choosenCard;
        Game game;

        public Checker(Game sender)
        {
            game = sender;
            choosenCard = new List<Card>();
        }

        public bool PutInfoAboutCards(Card card)
        {
            choosenCard.Add(card);
            if (choosenCard.Count == 3)
            {
                if (IsSet())
                { 
                    Debug.WriteLine("Yes, it is SET!");
                    choosenCard.Clear();
                    return true;
                }
                else 
                    Debug.WriteLine("No, think better!");
            choosenCard.Clear();    
            }
            return false;
        }

        private bool IsSet()
        {
            if (CheckParam(choosenCard[0].Color, choosenCard[1].Color, choosenCard[2].Color)
                &&
                CheckParam(choosenCard[0].Font, choosenCard[1].Font, choosenCard[2].Font)
                &&
                CheckParam(choosenCard[0].Figure, choosenCard[1].Figure, choosenCard[2].Figure)
                &&
                CheckParam(choosenCard[0].Count, choosenCard[1].Count, choosenCard[2].Count))
                return true;
            else 
                return false;
        }
        bool CheckParam<T>(T c1, T c2, T c3)
        {
            if ((c1.Equals(c2)) && (c2.Equals(c3)) ||
                ((!c1.Equals(c2)) && (!c2.Equals(c3)) && (!c1.Equals(c3))))
                return true;
            return false;
        }
    }
}
