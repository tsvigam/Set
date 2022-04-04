using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Set.v1
{
    public partial class TemplateCard : Form
    {

        Card Currentcard;
        private Checker check;
        Calculator calc;
        Recreator recreator;

        public TemplateCard(Calculator Calc, Checker Check, Recreator rec)
        {
            calc = Calc;
            Currentcard = calc.GetCard();
            check = Check;
            recreator = rec;
            //Debug.WriteLine($"Count - {Currentcard.Count}, Figure - {Currentcard.Figure}, Colour - {Currentcard.Color}, Font - {Currentcard.Font}");
            InitializeComponent();
        }

        public void Recreate()
        {
            Currentcard = calc.GetCard();
        }

        private void TemplateCard_Paint(object sender, PaintEventArgs e)
        {
            int i;
            for (i = 0; i < Currentcard.Count; i++)
                Drawfigure(i * 60, e);
        }
        private void Drawfigure(int offset, PaintEventArgs e)
        {
            System.Drawing.Pen myPen;
            Brush brush;
            switch (Currentcard.Color)
            {
                case Colors.Red:
                    myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
                    break;
                case Colors.Green:
                    myPen = new System.Drawing.Pen(System.Drawing.Color.Green);
                    break;
                case Colors.Blue:
                    myPen = new System.Drawing.Pen(System.Drawing.Color.Blue);
                    break;
                default:
                    myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
                    break;
            }

            switch (Currentcard.Font)
            {
                case Fonts.Solid:
                    brush = new SolidBrush(myPen.Color);
                    break;
                case Fonts.Hatch:
                    brush = new HatchBrush(HatchStyle.LightDownwardDiagonal, myPen.Color, Color.FromArgb(0, 0, 0, 255));
                    break;
                default:
                    brush = new SolidBrush(myPen.Color);
                    break;
            }
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            switch (Currentcard.Figure)
            {
                case FigureTypes.Ellipse:
                    {
                        if (Currentcard.Font == Fonts.Empty)
                            formGraphics.DrawEllipse(myPen, new Rectangle(40, 40 + offset, 150, 50));
                        else 
                            formGraphics.FillEllipse(brush, new Rectangle(40, 40 + offset, 150, 50));
                        break;

                    }
                case FigureTypes.Rectangle:
                    {
                        if (Currentcard.Font == Fonts.Empty)
                            formGraphics.DrawRectangle(myPen, new Rectangle(40, 40 + offset, 150, 50));
                        else
                            formGraphics.FillRectangle(brush, new Rectangle(40, 40 + offset, 150, 50));
                        break;
                    }
                case FigureTypes.Spline:
                    {
                        Point[] points = {
                            new Point(40, 40+offset),
                            new Point(130, 60+offset),
                            new Point(180, 40+offset),
                            new Point(150, 100+offset),
                            new Point(100, 80+offset),
                            new Point(60, 100+offset)};
                        if (Currentcard.Font == Fonts.Empty)
                            e.Graphics.DrawClosedCurve(myPen, points);
                        else
                            e.Graphics.FillClosedCurve(brush, points);
                        break;
                    }
                default:
                    {
                        formGraphics.DrawRectangle(myPen, new Rectangle(0, 0, 150, 50));
                        break;
                    }
            }
            myPen.Dispose();
            formGraphics.Dispose();
        }
        private void TemplateCard_MouseClick(object sender, MouseEventArgs e)
        {
            recreator.Forms.Add(this);

            if (check.PutInfoAboutCards(Currentcard))//, string NameForm))
            {
                recreator.Recreate();
            }
            if (recreator.Forms.Count == 3)
                recreator.Forms.Clear();
        }
    }
}
