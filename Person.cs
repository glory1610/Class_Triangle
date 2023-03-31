using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_class
{
    class Person
    {
        public string Name { get; }

        public Person(string name)
        {
            Name = name;
        }

        public void AskForArea(Triangle triangle)
        {
            Console.WriteLine($"Person {Name} wants to know the area of triangle with sides {triangle.A} cm, {triangle.B} cm, {triangle.C} cm.");
            triangle.AreaRequested += OnAreaRequested;
        }

        private void OnAreaRequested(object sender, EventArgs e)
        {
            Triangle triangle = sender as Triangle;
            Console.WriteLine($" --- The area of triangle with sides {triangle.A} cm, {triangle.B} cm, {triangle.C} cm is S = {triangle.Area()} cm^2");
            triangle.AreaRequested -= OnAreaRequested;
        }
    }
}
