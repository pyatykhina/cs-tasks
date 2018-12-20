using System;

namespace ConsoleApplication
{
    abstract class Integer
    {
        public double a { get; set; }
        public double b { get; set; }

        public virtual void Display() { }
        public virtual void Read() { }

        // public virtual void NumberToArray(double number) { }

        public virtual double Sum(double a, double b) { return a + b; }  // сумма 
        public virtual double Dif(double a, double b) { return a - b; }  // разность 
        public virtual double Mul(double a, double b) { return a * b; }  // умножение 
        public virtual double Div(double a, double b) { return a / b; }  // деление 
    }

    class Decimal : Integer
    {
        /* public override void NumberToArray(double number)
        {
            int[] array = new int[10];
            while (number > 0)
            {
                for (int i = 0; i < array.Length; i++) 
                {
                    array[i] = number % 10;
                    number /= 10;
                }
            }
        }*/

        public override double Sum(double a, double b) { return a + b; }
        public override double Dif(double a, double b) { return a - b; }
        public override double Mul(double a, double b) { return a * b; }
        public override double Div(double a, double b) { return a / b; }

        public override void Read()
        {
            Console.WriteLine("Введите первое число: ");
            a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число: ");
            b = double.Parse(Console.ReadLine());
        }

        public override void Display()
        {
            Console.WriteLine("Первое число в десятичной СЧ: " + a);
            Console.WriteLine("Второе число в десятичной СЧ: " + b);
            Console.WriteLine("Сумма двух чисел в десятичной СЧ: " + Sum(a, b));
            Console.WriteLine("Разность двух чисел в десятичной СЧ: " + Dif(a, b));
            Console.WriteLine("Произведение двух чисел в десятичной СЧ: " + Mul(a, b));
            Console.WriteLine("Кратное двух чисел в десятичной СЧ: " + Div(a, b));
            Console.WriteLine();
        }
    }

    class Binary : Integer
    {
        public override double Sum(double a, double b) { return a + b; }
        public override double Dif(double a, double b) { return a - b; }
        public override double Mul(double a, double b) { return a * b; }
        public override double Div(double a, double b) { return a / b; }

        public override void Read ()
        {
            Console.WriteLine("Введите первое число: ");
            a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число: ");
            b = double.Parse(Console.ReadLine());
        }

        private double ToBinary(double number) 
        {
            return(double.Parse(Convert.ToString(Convert.ToInt64(number), 2)));  // округляет до целого
        }

        public override void Display()
        {
            Console.WriteLine("Первое число в двоичной СЧ: " + ToBinary(a));
            Console.WriteLine("Второе число в двоичной СЧ: " + ToBinary(b));
            Console.WriteLine("Сумма двух чисел в двоичной СЧ: " + ToBinary(Sum(a, b)));
            Console.WriteLine("Разность двух чисел в двоичной СЧ: " + ToBinary(Dif(a, b)));
            Console.WriteLine("Произведение двух чисел в двоичной СЧ: " + ToBinary(Mul(a, b)));
            Console.WriteLine("Кратное двух чисел в двоичной СЧ: " + ToBinary(Div(a, b)));
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Decimal dec = new Decimal();
            Binary bin = new Binary();

            while (true)
            {
                Console.WriteLine("Введите 10 для выбора десятичной системы счисления или 2 для двоичной: ");
                int OperationType = int.Parse(Console.ReadLine());

                if (OperationType == 10)
                {
                    dec.Read();
                    dec.Display();
                }
                else if (OperationType == 2)
                {
                    bin.Read();
                    bin.Display();
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте еще раз. ");
                    Console.WriteLine();
                }
            }
        }
    }
}