using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Rectangle : Shape
    {
        double width;
        double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double CalculateArea()
        {
            return width * height;
        }
    }
}
