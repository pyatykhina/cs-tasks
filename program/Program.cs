// Способ 3

using System;

namespace ConsoleApplication
{
    public class Money
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

        public string ConvertToString() 
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
        private Money countOfMoney;
        private int Id;
        private int min = 50;
        private int max = 1000;

        public Money CountOfMoney 
        {
            set { countOfMoney = value; }
            get { return countOfMoney; }
        }
        public int ID 
        { 
            get { return Id; }
        }
        public int Min 
        {  
            get { return min; } 
        }
        public int Max
        {   
            get { return max; }
        }

        public ATM(int Id, int CountOfMoney)  // инициализация
        {
            this.Id = Id;  // идентификационный номер банкомата 
            countOfMoney = new Money(CountOfMoney);
        }

        public override string ToString() // преобразование в строку
        {
            return int.Parse(countOfMoney.ConvertToString()).ToString("C");  // стандартный числовой формат (валюта)
        }

        public int Read()
        {
            int a = int.Parse(Console.ReadLine());
            return a;
        }

        public void Display(string output)
        {
            Console.WriteLine(output);
        }
    }

    class ATMoperations
    {
        ATM atm = new ATM(0, 1000);
        public void Atm()
        {
            atm.Display("На вашем счете: " + atm);

            while (true)
            {
                atm.Display("Нажмите 0, чтобы внести деньги или 1, чтобы снять");
                int operationType = atm.Read();

                if (operationType == 0)
                {
                    atm.Display("Внесите деньги: ");
                    int sumIn = atm.Read();
                    LoadMoney(sumIn);
                    atm.Display("На вашем счете: " + atm.CountOfMoney.ConvertToString());
                }
                else if (operationType == 1)
                {
                    atm.Display("Введите снимаемую сумму: ");
                    int sumOut = atm.Read();
                    UnloadMoney(sumOut);
                    atm.Display("На вашем счете: " + atm.CountOfMoney.ConvertToString());
                }
                else
                {
                    atm.Display("Неизвестная операция, попробуйте заново.");
                }
            }
        }

        public void LoadMoney(int Money)  // внесение денег
        {
            if (Money % 10 != 0)
                atm.Display("Вносимая сумма должна быть кратна 10.");

            else atm.CountOfMoney += Money;
        }

        public void UnloadMoney(int Money)  // снятие денег
        {
            if (Money % 10 != 0)
                atm.Display("Снимаемая сумма должна быть кратна 10.");

            else if (atm.CountOfMoney.CheckUp(new Money(Money)) == -1)
                atm.Display("Недостаточно средств.");

            else if (Money < atm.Min)
                atm.Display("Вы не можете снять меньше " + atm.Min + " рублей.");

            else if (Money > atm.Max)
                atm.Display("Вы не можете снять больше " + atm.Max + " рублей.");

            else atm.CountOfMoney -= Money;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ATMoperations atmOperations = new ATMoperations();
            atmOperations.Atm();
        }
    }
}