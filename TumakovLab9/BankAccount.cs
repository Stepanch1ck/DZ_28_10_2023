using System;
using System.Collections.Generic;
using System.IO;

namespace TumakovLab9
{
    public enum AccountType
    {
        Current,
        Saving
    }
    internal class BankAccount
    {
        public static int AccountID = 1;
        protected int _accountNumber;
        protected decimal _balance;
        protected AccountType _accountType;
        public Queue<BankTransaction> _transactions = new Queue<BankTransaction>();

        public BankAccount()
        {
            _accountNumber = AccountID;
            _transactions = new Queue<BankTransaction>();
        }

        public BankAccount(decimal balance)
        {
            _accountNumber = AccountID;
            _balance = balance;
            _transactions = new Queue<BankTransaction>();
        }

        public BankAccount(AccountType accountType)
        {
            _accountNumber = AccountID;
            _accountType = accountType;
            _transactions = new Queue<BankTransaction>();
        }

        public BankAccount(decimal balance, AccountType accountType)
        {
            _accountNumber = AccountID;
            _balance = balance;
            _accountType = accountType;
            _transactions = new Queue<BankTransaction>();
        }
        public void UniqueBankAccount()
        {

            AccountID++;
        }

        public int AccountNumber
        {
            get { return _accountNumber; }
        }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение баланса не может быть отрицательным");
                }

                _balance = value;
                _transactions.Enqueue(new BankTransaction(value));
            }
        }

        public AccountType AccountType
        {
            get { return _accountType; }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException("Сумма снятия превышает баланс");
            }

            _balance -= amount;
            _transactions.Enqueue(new BankTransaction(-amount));
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
            _transactions.Enqueue(new BankTransaction(amount));
        }

        public void Transfer(BankAccount otherAccount, decimal amount)
        {
            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException("Сумма перевода превышает баланс");
            }

            Withdraw(amount);
            otherAccount.Deposit(amount);
        }
        public override string ToString()
        {
            return $"Номер счета: {AccountNumber}, баланс: {Balance}, тип счета: {AccountType}";
        }

        public void PrintAccount()
        {
            Console.WriteLine(this.ToString());
        }
        public Queue<BankTransaction> Transactions
        {
            get { return _transactions; }
        }
        public void Dispose()
        {
            string filename = $"{AccountNumber}.txt";
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (BankTransaction transaction in _transactions)
                {
                    writer.WriteLine(transaction.ToString());
                }
            }
            GC.SuppressFinalize(this);
        }


    }

}
