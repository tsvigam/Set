using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set.v1
{

    public class Recreator
    {
        public List<TemplateCard> Forms;

        public Recreator()
        {
            Forms = new List<TemplateCard>();
        }

        public void AddCard(TemplateCard card)
        {
            if (Forms.Count < 3)
                Forms.Add(card);
        }

        public void Recreate()
        {
                Forms[0].Recreate();
                Forms[0].Invalidate();
                Forms[0].Refresh();

                Forms[1].Recreate();
                Forms[1].Invalidate();
                Forms[1].Refresh();

                Forms[2].Recreate();
                Forms[2].Invalidate();
                Forms[2].Refresh();
        }
    }
}
