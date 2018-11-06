// Способ 1

using System;

namespace ConsoleApplication
{
    class Money
    {
        private int[] moneyDenomination = new int[3]; // поля-номиналы (10, 100, 1000)

        public Money(int CountMoney) // сумма -> поля-номиналы
        {
            for (int i = 0; i < 2; i++)
            {
                moneyDenomination[i] = CountMoney % 10;
                CountMoney /= 10;
            }

            moneyDenomination[2] = CountMoney;
        }

        public override string ToString() // override - новая реализация члена, унаследованного от базового класса
        {
            // преобразует значения объектов в строки на основе указанных форматов и вставляет их в другую строку
            // {0}{1}{2} - номера параметров
            return string.Format("{0}{1}{2}", moneyDenomination[2], moneyDenomination[1], moneyDenomination[0]);
        }

        public int CheckUp(object obj) // проверка, что остаток на счете >= 0
        {
            for (int i = 2; i >= 0; i--)
            {
                if (this.moneyDenomination[i] > (obj as Money).moneyDenomination[i])
                    return 1;
                else if (this.moneyDenomination[i] < (obj as Money).moneyDenomination[i])
                    return -1;
            }

            return 0;
        }

        public static Money operator +(Money arg1, Money arg2)
        {
            Money current = new Money(0);
            for (int i = 0; i < 3; i++)
                current.moneyDenomination[i] = arg1.moneyDenomination[i] + arg2.moneyDenomination[i];

            return current;
        }

        public static Money operator +(Money arg1, int arg2)
        {
            return arg1 + new Money(arg2);
        }

        public static Money operator -(Money arg1, Money arg2)
        {
            Money current = new Money(0);

            for (int i = 0; i < 3; i++)
                current.moneyDenomination[i] = arg1.moneyDenomination[i] - arg2.moneyDenomination[i];

            return current;
        }

        public static Money operator -(Money arg1, int arg2)
        {
            return arg1 - new Money(arg2);
        }
    }

    class ATM
    {
        public Money countOfMoney;
        public int ID;
        public int min = 50;
        public int max = 1000;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = Init(0, 1000);
            Display("На вашем счете: " + ToString(atm.countOfMoney));

            while (true)
            {
                Display("Нажмите 0, чтобы внести деньги или 1, чтобы снять");
                int operationType = Read();

                if (operationType == 0)
                {
                    Display("Внесите деньги: ");
                    int sumIn = Read();
                    atm.countOfMoney = LoadMoney(sumIn, atm.countOfMoney);
                    Display("На вашем счете: " + ToString(atm.countOfMoney));
                }
                else if (operationType == 1)
                {
                    Display("Введите снимаемую сумму: ");
                    int sumOut = Read();
                    atm.countOfMoney = GetMoney(sumOut, atm.countOfMoney, atm.min, atm.max);
                    Display("На вашем счете: " + ToString(atm.countOfMoney));
                }
                else
                {
                    Display("Неизвестная операция, попробуйте заново.");
                }
            }
        }

        public static ATM Init(int id, int CountOfMoney)  // инициализация
        {
            ATM atm = new ATM
            {
                countOfMoney = new Money(CountOfMoney),
                ID = id, // идентификационный номер банкомата 
                min = 50,
                max = 1000
            };

            return atm;
        }

        public static int Read()
        {

            int a = int.Parse(Console.ReadLine());
            return a;
        }

        public static void Display(string output)
        {
            Console.WriteLine(output);
        }

        public static string ToString(Money countOfMoney) // преобразование в строку
        {
            return int.Parse(countOfMoney.ToString()).ToString("C");  // стандартный числовой формат (валюта)
        }

        public static Money LoadMoney(int Money, Money countOfMoney)  // внесение денег
        {
            if (Money % 10 != 0)
                Display("Вносимая сумма должна быть кратна 10.");

            else countOfMoney += Money;

            return countOfMoney;
        }

        public static Money GetMoney(int Money, Money countOfMoney, int min, int max)  // снятие денег
        {
            if (Money % 10 != 0)
                Display("Снимаемая сумма должна быть кратна 10.");

            else if (countOfMoney.CheckUp(new Money(Money)) == -1)
                Display("Недостаточно средств.");

            else if (Money < min)
                Display("Вы не можете снять меньше " + min + " рублей.");

            else if (Money > max)
                Display("Вы не можете снять больше " + max + " рублей.");

            else countOfMoney -= Money;

            return countOfMoney;
        }
    }
}