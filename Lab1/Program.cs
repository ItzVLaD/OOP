using System;

namespace Lab5
{
    class TCircle
    {
        protected double radius;

        public TCircle() 
        {
            this.radius = 1;
        }
        public TCircle(double radius)
        {
            if (radius < 0)
            {
                this.radius = -radius;
            }
            else
            {
                this.radius = radius == 0 ? 1 : radius;
            }           
        }
        public TCircle(in TCircle obj)
        {
            this.radius = obj.radius;
        }

        public void SetRadius(double radius)
        {            
            if (radius < 0)
            {
                this.radius = -radius;
            }
            else
            {
                this.radius = radius == 0 ? 1 : radius;
            }
        }
        public double GetRadius() => this.radius;

        public virtual double GetArea() => Math.PI * Math.Pow(this.radius, 2);

        public double GetSegment(double angle) => GetArea() / 360 * angle;

        public double GetLenht() => 2 * Math.PI * this.radius;

        public bool IsBigger(TCircle obj) => this.radius > obj.radius;

        public static TCircle operator +(TCircle circle1, TCircle circle2) => new(circle1.radius + circle2.radius);
        public static TCircle operator -(TCircle circle1, TCircle circle2) => new(circle1.radius - circle2.radius);
        public static TCircle operator *(TCircle circle1, double x) => new(circle1.radius * x);
    }

    class TSphere : TCircle
    {
        public TSphere() : base() { }
        public TSphere(double radius) : base(radius) { }
        public TSphere(in TSphere obj)
        {
            this.radius = obj.radius;
        }

        public override double GetArea() => 4 * Math.PI * Math.Pow(this.radius, 2);
    }

    class Program
    {
        static void Main(string[] args)
        {
            TSphere sphere = new TSphere();// = new List<TMatrix>();
            int choice;
            string commands = "0: Close the program\n" +
            "1: Enter the radius\n" +
            "2: Print the radius\n" +
            "3: Print the area of the figure";
            Console.WriteLine(commands);
        menu: Console.Write("\nCommand: ");         
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                default:
                    Console.WriteLine("Enter a correct value!");
                    goto menu;
                case 0:
                    break;
                case 1:
                    double radius;
                    do
                    {
                        Console.Write("Radius: ");
                        radius = double.Parse(Console.ReadLine());
                    } while (radius == 0);
                    sphere.SetRadius(radius);
                    goto menu;
                case 2:
                    Console.WriteLine("Radius is {0:F2}", sphere.GetRadius());
                    goto menu;
                case 3:
                    Console.WriteLine("Area of sphere is {0:F4}", sphere.GetArea());
                    goto menu;                 
                }                        
        }
    }
}