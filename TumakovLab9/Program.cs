using System;



namespace TumakovLab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 9 упражнения 1-3");
            AccountType accountType = AccountType.Current;
            BankAccount account1 = new BankAccount(1000, accountType);
            BankAccount account2 = new BankAccount(500);
            BankAccount account3 = new BankAccount(accountType);

            account1.PrintAccount();
            account2.PrintAccount();
            account3.PrintAccount();

            account1.Transfer(account2, 250);
            account1.Deposit(1000);
            account1.Withdraw(100);

            Console.WriteLine("Баланс счёта 1: {0}", account1.Balance);
            Console.WriteLine("Баланс счёта 2: {0}", account2.Balance);
            foreach (BankTransaction transaction in account1._transactions)
            {
                Console.WriteLine(transaction);
            }
            account1.Dispose();
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();
            Console.WriteLine("Лабораторная работа 9 домашняя работа ");
            Song[] songs = new Song[]
            {
            new Song("Gambare Gambare Senpai", "Bemax"),
            new Song("Mastermind《时光代理人第二季》动画插曲", "Kat"),
            new Song("Nyanpasu", "Renge Miyauchi"),
            new Song("Whiskey Cola", "Picu")
            };
            Console.WriteLine("Список песен:");
            foreach (Song s in songs)
            {
                Console.WriteLine(s.Title());
            }
            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine("Певрая и вторая песня равны");
            }
            else
            {
                Console.WriteLine("Певрая и вторая песня Не равны");
            }
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();
        }
    }
}
