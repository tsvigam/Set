using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Set.v1
{
    public partial class Game : Form
    {
        Int32 Count;
        public Calculator Calc;
        public Checker Check;
        public Recreator recreator;
        List <TemplateCard> embeddedForm = new List<TemplateCard>();

        public Game(Int32 Count)
        {
            InitializeComponent();
            this.Count = Count;
        }
        

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Close();
        }

        private void Game_Shown(object sender, EventArgs e)
        {
            InitializeComponent();
            Calc = new Calculator();
            Check = new Checker(this);
            recreator = new Recreator();
            Settings settings = new Settings();
            Int32 st = 0;
            Int32 x = 15, y = 25;
            for (int i = 0; i < Count; i++)
            {
                if ((i % 5 == 0) && (i != 0)) st = st + 1;
                embeddedForm.Add(new TemplateCard(Calc, Check, recreator));
                embeddedForm[i].TopLevel = false;
                if ((i % 5 == 0) && (i != 0)) { x = 15; y = y + 270; }
                else if ((i % 5 != 0) || (i != 0)) { x = x + 270; }
                embeddedForm[i].Location = new Point(x, y);
                Controls.Add(embeddedForm[i]);
                embeddedForm[i].Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(TemplateCard embf in embeddedForm)
            embf.Recreate();
            this.Invalidate();
            this.Refresh();
        }
    }
}
