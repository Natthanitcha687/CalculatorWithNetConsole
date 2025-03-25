using System;

namespace AdvancedCalculatorApp
{
    public enum CalculatorOperation
    {
        Add = 1,
        Subtract,
        Divide,
        Multiply,
        Power,
        Exit
    }

    public enum ShapeType
    {
        Triangle = 1,
        Rectangle,
        Circle,
        Back
    }

    public interface IShape
    {
        double Area { get; }
    }

    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double b, double h)
        {
            Base = b;
            Height = h;
        }

        public double Area => 0.5 * Base * Height;

        public double GetPerimeter()
        {
            // Assuming it's not an equilateral triangle, we'd need more side information
            Console.WriteLine("Cannot calculate triangle perimeter without all side lengths.");
            return -1; // Indicate failure
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public double Area => Width * Height;

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double r)
        {
            Radius = r;
        }

        public double Area => Math.PI * Radius * Radius;

        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }
    }

    public class ArithmeticClass
    {
        private double a;
        private double b;

        public double A
        {
            get { return a; }
            set { a = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double GetSum()
        {
            return A + B;
        }

        public double GetSubtract()
        {
            return A - B;
        }

        public double GetDivide()
        {
            if (B == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return A / B;
        }

        public double GetMultiply()
        {
            return A * B;
        }

        public double GetPower()
        {
            return Math.Pow(A, B);
        }
    }

    public class AdvancedCalculator : ArithmeticClass
    {
        // No longer contains SquareRoot and AbsoluteValue
    }

    public class ShapeCalculator
    {
        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nShape Calculator Menu:");
                Console.WriteLine("1: Triangle");
                Console.WriteLine("2: Rectangle");
                Console.WriteLine("3: Circle");
                Console.WriteLine("4: Back to Main Menu");
                Console.Write("Choose a shape: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch ((ShapeType)choice)
                    {
                        case ShapeType.Triangle:
                            CalculateTriangle();
                            break;
                        case ShapeType.Rectangle:
                            CalculateRectangle();
                            break;
                        case ShapeType.Circle:
                            CalculateCircle();
                            break;
                        case ShapeType.Back:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                if (running)
                {
                    Console.WriteLine("Press Enter to continue with shape calculations...");
                    Console.ReadLine();
                }
            }
        }

        private void CalculateTriangle()
        {
            Console.Write("Enter the base of the triangle: ");
            if (!double.TryParse(Console.ReadLine(), out double baseValue))
            {
                Console.WriteLine("Invalid input for base.");
                return;
            }

            Console.Write("Enter the height of the triangle: ");
            if (!double.TryParse(Console.ReadLine(), out double heightValue))
            {
                Console.WriteLine("Invalid input for height.");
                return;
            }

            Triangle triangle = new Triangle(baseValue, heightValue);
            Console.WriteLine($"Triangle Area: {triangle.Area}");
            triangle.GetPerimeter(); // Note: Perimeter calculation is limited
        }

        private void CalculateRectangle()
        {
            Console.Write("Enter the width of the rectangle: ");
            if (!double.TryParse(Console.ReadLine(), out double widthValue))
            {
                Console.WriteLine("Invalid input for width.");
                return;
            }

            Console.Write("Enter the height of the rectangle: ");
            if (!double.TryParse(Console.ReadLine(), out double heightValue))
            {
                Console.WriteLine("Invalid input for height.");
                return;
            }

            Rectangle rectangle = new Rectangle(widthValue, heightValue);
            Console.WriteLine($"Rectangle Area: {rectangle.Area}");
            Console.WriteLine($"Rectangle Perimeter: {rectangle.GetPerimeter()}");
        }

        private void CalculateCircle()
        {
            Console.Write("Enter the radius of the circle: ");
            if (!double.TryParse(Console.ReadLine(), out double radiusValue))
            {
                Console.WriteLine("Invalid input for radius.");
                return;
            }

            Circle circle = new Circle(radiusValue);
            Console.WriteLine($"Circle Area: {circle.Area}");
            Console.WriteLine($"Circle Circumference: {circle.GetCircumference()}");
        }
    }

    public class UserInterface
    {
        public AdvancedCalculator Calculator { get; set; }
        public ShapeCalculator ShapeCalculator { get; set; }

        public UserInterface()
        {
            Calculator = new AdvancedCalculator();
            ShapeCalculator = new ShapeCalculator();
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1: Calculator");
                Console.WriteLine("2: Shape Calculator");
                Console.WriteLine("3: Exit");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int mainMenuChoice))
                {
                    switch (mainMenuChoice)
                    {
                        case 1:
                            RunCalculator();
                            break;
                        case 2:
                            ShapeCalculator.Run();
                            break;
                        case 3:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Exiting application.");
        }

        private void RunCalculator()
        {
            bool running = true;
            while (running)
            {
                try
                {
                    GetCalculatorInput();
                    CalculatorOperation operation = GetCalculatorOperation();
                    PerformCalculatorOperation(operation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Press Enter to continue with calculator...");
                Console.ReadLine();
            }
        }

        private void GetCalculatorInput()
        {
            Console.Write("Please Provide 1st Number: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.WriteLine("Invalid input for the first number.");
                throw new FormatException();
            }
            Calculator.A = num1;

            Console.Write("Please Provide 2nd Number: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
            {
                Console.WriteLine("Invalid input for the second number.");
                throw new FormatException();
            }
            Calculator.B = num2;
        }

        private CalculatorOperation GetCalculatorOperation()
        {
            Console.WriteLine("\nCalculator Operations:");
            Console.WriteLine($"{(int)CalculatorOperation.Add}: Add");
            Console.WriteLine($"{(int)CalculatorOperation.Subtract}: Subtract");
            Console.WriteLine($"{(int)CalculatorOperation.Divide}: Divide");
            Console.WriteLine($"{(int)CalculatorOperation.Multiply}: Multiply");
            Console.WriteLine($"{(int)CalculatorOperation.Power}: Power");
            Console.WriteLine($"{(int)CalculatorOperation.Exit}: Exit Calculator");
            Console.Write("Please Provide Option to proceed: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (Enum.IsDefined(typeof(CalculatorOperation), choice))
                {
                    return (CalculatorOperation)choice;
                }
            }
            Console.WriteLine("Invalid option.");
            return CalculatorOperation.Exit; // Default to exit on invalid input
        }

        private void PerformCalculatorOperation(CalculatorOperation operation)
        {
            switch (operation)
            {
                case CalculatorOperation.Add:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetSum());
                    break;
                case CalculatorOperation.Subtract:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetSubtract());
                    break;
                case CalculatorOperation.Divide:
                    try
                    {
                        Console.WriteLine("Your Ans Is: " + Calculator.GetDivide());
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case CalculatorOperation.Multiply:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetMultiply());
                    break;
                case CalculatorOperation.Power:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetPower());
                    break;
                case CalculatorOperation.Exit:
                    Console.WriteLine("Returning to Main Menu.");
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            ui.Run();
        }
    }
}