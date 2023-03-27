using System;
using System.Collections.Generic;

namespace Triangle_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //п’ять  різних  трикутників,  у  тому  числі  правильні
            List<Triangle> triangles = new List<Triangle>();
            triangles.Add(new Triangle(2.0, 3.9, 5.0));
            triangles.Add(new Triangle(5.6, 12.1, 13.5));
            triangles.Add(new RightTriangle(6.4));
            triangles.Add(new RightTriangle(10.3));
            triangles.Add(new Triangle(8.0, 12.0, 17.4));

            //можливість вводити в режимі діалогу інформацію проновий трикутник і долучати його до колекції інших
            while (true)
            {
                Console.WriteLine("Enter triangle sides (separated by spaces) or 'exit' to quit:");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                try
                {
                    string[] sides = input.Split();
                    double a = double.Parse(sides[0]);
                    double b = double.Parse(sides[1]);
                    double c = double.Parse(sides[2]);
                    Triangle t;
                    if (a == b && b == c)
                    {
                        t = new RightTriangle(a);
                        Console.WriteLine($"New right triangle added: {t}");
                    }
                    else
                    {
                        t = new Triangle(a, b, c);
                        Console.WriteLine($"New triangle added: {t}");
                    }
                    triangles.Add(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("All triangles:");
            Console.WriteLine("---------------------------");
            foreach (Triangle t in triangles)
            {
                Console.WriteLine("{0:N}", t);
                Console.WriteLine("---------------------------");
            }

            //об’єкт з найбільшою площею
            Triangle maxAreaTriangle = triangles[0];
            foreach (Triangle t in triangles)
            {
                if (t.Area() > maxAreaTriangle.Area())
                {
                    maxAreaTriangle = t;
                }
            }
            Console.WriteLine("\nTriangle with the largest area:\n\n{0:N}\n", maxAreaTriangle);
            if (maxAreaTriangle is RightTriangle)
            {
                Console.WriteLine("This triangle is a right triangle.");
            }
            else
            {
                Console.WriteLine("This triangle is not a right triangle.");
            }

            //колекція трикутників, масштабована на певний множник
            List<Triangle> scaledTriangles = new List<Triangle>();
            double scaleFactor = 2.5;
            foreach (Triangle t in triangles)
            {
                if (t is RightTriangle rt)
                {
                    scaledTriangles.Add(new RightTriangle(rt.Side * scaleFactor));
                }
                else
                {
                    scaledTriangles.Add(new Triangle(t.A * scaleFactor, t.B * scaleFactor, t.C * scaleFactor));
                }
            }

            Console.WriteLine("\nScaled Triangles:");
            Console.WriteLine("---------------------------");
            foreach (Triangle t in scaledTriangles)
            {
                Console.WriteLine("{0:N}", t);
                Console.WriteLine("---------------------------");
            }

            //колекція, що містить радіуси описаних кіл правильних трикутників
            List<double> circumscribedRadius = new List<double>();
            foreach (Triangle t in scaledTriangles)
            {
                if (t is RightTriangle rt)
                {
                    circumscribedRadius.Add(rt.RadiusOfCircumscribedCircle());
                }
            }
            Console.WriteLine("\nCircumscribed Radius of Right Triangles:");
            foreach (double radius in circumscribedRadius)
            {
                Console.WriteLine("r = {0} cm", radius);
            }
        }
    }
}
