using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDOTNET2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //string[] num = input.Split(' ');
            //double[] array = new double[num.Length];
            //for (int i = 0; i < num.Length; i++)
            //{
            //    array[i] = double.Parse(num[i]);
            //}
            //Triangle s1 = new Triangle(array[0], array[1], array[2]);
            //Rectangle s1 = new Rectangle(array[0], array[1]);
            //Square s1 = new Square(array[0]);
            //s1.computeSize();
            //Console.WriteLine("The shape is legal: "+s1.isLegal());
            //Console.WriteLine(s1.getSize());
            Random randArr = new Random();
            Random randShape = new Random();
            for (int i = 0; i < 10; i++)
            {
                double[] arr = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    arr[j] = randArr.NextDouble() * 10;
                }
                int r = randShape.Next() % 3;
                switch (r)
                {
                    case 0: Console.WriteLine("This is  a triangle."); Factory f1 = new Factory("Triangle", arr); break;
                    case 1: Console.WriteLine("This is  a square."); Factory f2 = new Factory("Square", arr); break;
                    case 2: Console.WriteLine("This is  a rectangle."); Factory f3 = new Factory("Rectangle", arr); break;
                }
                Console.WriteLine();
            }
            string stop = Console.ReadLine();
        }

    }
    abstract class Shape
    {
        abstract public bool isLegal();//If is legal, the output is true.
        abstract public double getSize();
        abstract public void computeSize();//If size = -1, it means the shape is illegal.
    }
    
    class Triangle: Shape
    {
        private double a, b, c, size = 0;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            Console.WriteLine("a: " + a + " b: " + b + " c: " + c);
        }

        public override bool isLegal()
        {
            if (a > 0 && b > 0 && c > 0)
            {
                if (a + b > c && Math.Abs(a - b) < c)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public override double getSize()
        {
            return size;
        }

        public override void computeSize()
        {
            if (isLegal())
            {
                double p = (a + b + c) / 2;
                size = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            else size = -1;
        }
    }
    class Square: Shape
    {
        private double a, size = 0;

        public Square(double a)
        {
            this.a = a;
            Console.WriteLine("a: " + a);
        }

        public override bool isLegal()
        {
            if (a > 0) return true;
            else return false;
        }

        public override double getSize()
        {
            return size;
        }

        public override void computeSize()
        {
            if (isLegal())
                size = a * a;
            else size = -1;
        }
    }

    class Rectangle : Shape
    {
        private double a, b, size = 0;

        public Rectangle(double a, double b)
        {
            this.a = a;
            this.b = b;
            Console.WriteLine("a: " + a + " b: " + b);
        }

        public override void computeSize()
        {
            if (isLegal()) size = a * b;
            else size = -1;
        }

        public override double getSize()
        {
            return size;
        }

        public override bool isLegal()
        {
            if (a > 0 && b > 0) return true;
            else return false;
        }
    }

    class Factory
    {
        private string type;
        private double[] array = new double [3];
        private Shape s;
        public Factory(string type, double[] array)
        {
            this.type = type;
            this.array = array;
            switch (type)
            {
                case "Triangle": this.s = new Triangle(array[0], array[1], array[2]);break;
                case "Rectangle": this.s = new Rectangle(array[0], array[1]); break;
                case "Square": this.s = new Square(array[0]);break;
            }
            s.computeSize();
            displayShape();
        }
        private void displayShape()
        {
            Console.WriteLine("The shape is legal: "+s.isLegal());
            Console.WriteLine("Size: "+s.getSize());
        }
    }
}
