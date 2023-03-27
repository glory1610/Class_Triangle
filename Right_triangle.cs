using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_class
{
    class RightTriangle : Triangle, IFormattable
    {
        private double side;
        public RightTriangle(double side)
            : base(side, side, side)
        {
            this.side = side;
        }
        public double Side { get { return side; } }
        public double RadiusOfInscribedCircle()
        {
            return Math.Round(side * Math.Sqrt(3) / 3.0);
        }
        public double RadiusOfCircumscribedCircle()
        {
            return Math.Round(side * Math.Sqrt(3) / 6.0);
        }
        public override string ToString()
        {
            return base.ToString() + $"\nR = {RadiusOfInscribedCircle()}, r = {RadiusOfCircumscribedCircle()}";
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return base.ToString();

            string formatString = format.ToUpper();
            switch (formatString)
            {
                case "R":
                    return $"R = {RadiusOfInscribedCircle()} cm";
                case "r":
                    return $"r = {RadiusOfCircumscribedCircle()} cm";
                case "N":
                    return base.ToString("N", formatProvider) + $"\nR = {RadiusOfInscribedCircle()} cm, r = {RadiusOfCircumscribedCircle()} cm";
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }
    }
}
