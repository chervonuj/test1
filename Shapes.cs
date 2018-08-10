using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Shape : IComparable<Shape>
    {
        public int CompareTo(Shape other)
        {
            return this.getArea().CompareTo(other.getArea());
        }

        public override string ToString()
        {
            return this.GetType() + " " +this.getArea();
        }

        abstract public  double getArea();

    }

    class Square : Shape
    {
        double _side;
        public Square(double side)
        {
            _side = side;
        }
        public override double getArea()
        {
            return _side * _side;
        }
    }

    class Rectangle : Shape
    {
        double _width;
        double _height;
        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }
        public override double getArea()
        {
            return _width * _height;
        }
    }

    class Triangle : Shape
    {
        double _base;
        double _height;
        public Triangle(double width, double height)
        {
            _base = width;
            _height = height;
        }
        public override double getArea()
        {
            return _base * _height/2;
        }
    }

    class Circle : Shape
    {
        double _radius;
        public Circle(double rad)
        {
            _radius = rad;
        }
        public override double getArea()
        {
            return _radius * _radius* System.Math.PI;
        }

    }

    class CustomShape : Shape
    {
        double _area;
        public CustomShape (double area)
        {
            _area = area;
        }
        public override double getArea()
        {
            return _area;
        }

    }

    class Program2
    {
        static void Main2()
        {

            var side = 1.1234D;
            var radius = 1.1234D;
            var base1 = 5D;
            var height = 2D;

            var shapes = new List<Shape>{ new Square(side),
                            new Circle(radius),
                            new Triangle(base1, height) };
            shapes.Sort();
            foreach(Shape shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
            Console.WriteLine("Hello!");
            Console.ReadLine();
        }
    }


}
