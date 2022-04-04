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
    public partial class Settings : Form
    {
        public Int32 Count;
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Game = new Game(Convert.ToInt32(this.CountCards.Text));
            Game.Show();
            this.Hide();
          
        }
    }
}
