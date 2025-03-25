using System;
namespace AdvancedCalculatorApp
{
    public enum Operation
    {
        Add = 1,
        Subtract,
        Divide,
        Multiply,
        Power,
        SquareRoot,
        AbsoluteValue,
        Exit
    }

    public class ArithmeticClass
    {
        private int a;
        private int b;

        public int A
        {
            get { return a; }
            set { a = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value; }
        }

        public int GetSum()
        {
            return A + B;
        }

        public int GetSubtract()
        {
            return A - B;
        }

        public double GetDivide()
        {
            if (B == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return (double)A / B;
        }

        public int GetMultiply()
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
        public double GetSquareRoot()
        {
            return Math.Sqrt(A);
        }

        public int GetAbsoluteValue()
        {
            return Math.Abs(A);
        }
    }

    public class UserInterface
    {
        public AdvancedCalculator Calculator { get; set; }

        public UserInterface(AdvancedCalculator calculator)
        {
            Calculator = calculator;
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                try
                {
                    GetInput();
                    Operation operation = GetOperation();
                    PerformOperation(operation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        private void GetInput()
        {
            Console.Write("Please Provide 1st Number: ");
            Calculator.A = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please Provide 2nd Number: ");
            Calculator.B = Convert.ToInt32(Console.ReadLine());
        }

        private Operation GetOperation()
        {
            Console.Write("1: Add\n2: Subtract\n3: Divide\n4: Multiply\n5: Power\n6: Square Root\n7: Absolute Value\n8: Exit\nPlease Provide Option to proceed: ");
            return (Operation)Convert.ToInt32(Console.ReadLine());
        }

        private void PerformOperation(Operation operation)
        {
            switch (operation)
            {
                case Operation.Add:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetSum());
                    break;
                case Operation.Subtract:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetSubtract());
                    break;
                case Operation.Divide:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetDivide());
                    break;
                case Operation.Multiply:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetMultiply());
                    break;
                case Operation.Power:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetPower());
                    break;
                case Operation.SquareRoot:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetSquareRoot());
                    break;
                case Operation.AbsoluteValue:
                    Console.WriteLine("Your Ans Is: " + Calculator.GetAbsoluteValue());
                    break;
                case Operation.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AdvancedCalculator calculator = new AdvancedCalculator();
            UserInterface ui = new UserInterface(calculator);
            ui.Run();
        }
    }
}