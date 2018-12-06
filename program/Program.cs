using System;

namespace ConsoleApplication
{
    class Point
    {
        public int X;
        public int Y;

        public static int count = 0;

        protected string Read()
        {
            Console.WriteLine("Введите х: ");
            string x = Console.ReadLine();

            Console.WriteLine("Введите y: ");
            string y = Console.ReadLine();

            return x + " " + y;
        }

        protected void Init()
        {
            string text = Read();
            string[] coordinates = text.Split(' '); // создает массив подстрок, разбивая входную строку по одному или нескольким разделителям
            string x = coordinates[0];
            string y = coordinates[1];

            X = int.Parse(x);

            Y = int.Parse(y);
        }

        protected string toString()
        {
            return X.ToString() + " " + Y.ToString();
        }
    }

    class PointOperation : Point
    {
        public static void MoveToX(Point dot)
        {
            Console.WriteLine("Введите смещение по оси ОХ:");
            int space = int.Parse(Console.ReadLine());
            dot.X += space;
        }

        public static void MoveToY(Point dot)
        {
            Console.WriteLine("Введите смещение по оси ОY:");
            int space = int.Parse(Console.ReadLine());
            dot.Y += space;
        }

        public static void DistanceToO(Point dot)
        {
            double distance = Convert.ToDouble(Math.Sqrt(dot.X * dot.X + dot.Y * dot.Y));
            Console.WriteLine("Расстояние до начала координат: " + distance.ToString());
        }

        public static void DistanceBetweenTwoDots(Point frstDot, Point scndDot)
        {
            double distance = Convert.ToDouble(Math.Sqrt((frstDot.X - scndDot.X) * (frstDot.X - scndDot.X) + (frstDot.Y - scndDot.Y) * (frstDot.Y - scndDot.Y)));
            Console.WriteLine("Расстояние между точками: " + distance.ToString());
        }

        public static bool IsExist(Point frstDot, Point scndDot)
        {
            bool isExist = false;
            if (frstDot.X == scndDot.X && frstDot.Y == scndDot.Y)
            {
                Console.WriteLine("Точки совпадают");
                isExist = true;
            }
            else Console.WriteLine("Точки не совпадают");
            return isExist;
        }

        public static void ConvertToPolarCoordinates(Point dot)
        {
            double r = Math.Sqrt(dot.X * dot.X + dot.Y * dot.Y);
            double fi = Math.Atan(dot.Y / dot.X) * 180 / Math.PI; // Возвращает угол, тангенс которого равен указанному числу
            Console.WriteLine("Полярный радиус: " + r.ToString() + "\nПолярный угол: " + fi.ToString() + "°");
        }

        public void InitOperation()
        {
            Init();
            count++;
            Console.WriteLine("Создано объектов: " + count);
        }

        public string toStringOperation()
        {
            return toString();
        }
    }

    class Program
    {
        public static PointOperation DotOperation()
        {
            PointOperation dot = new PointOperation();
            dot.InitOperation();

            PointOperation.MoveToX(dot);
            PointOperation.MoveToY(dot);
            PointOperation.DistanceToO(dot);
            PointOperation.ConvertToPolarCoordinates(dot);
            Console.WriteLine("Координаты точки: " + dot.toStringOperation());

            return dot;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Введите первую точку");
            Point frstDot = DotOperation();

            Console.WriteLine("Введите вторую точку");
            Point scndDot = DotOperation();

            PointOperation.DistanceBetweenTwoDots(frstDot, scndDot);
            PointOperation.IsExist(frstDot, scndDot);
        }
    }
}