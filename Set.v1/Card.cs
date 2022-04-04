using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set.v1
{
    public enum FigureTypes
    {
        Ellipse = 1,
        Rectangle,
        Spline
    }
    public enum Colors
    {
        Red = 1,
        Green,
        Blue
    }
    public enum Fonts
    {
        Solid = 1,
        Empty,
        Hatch
    }
    public class Card
    {
        public Colors Color { get; set; }
        public FigureTypes Figure { get; set; }
        public Fonts Font { get; set; }
        public int Count { get; set; }
    }
}
