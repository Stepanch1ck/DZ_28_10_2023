using System;

namespace TumakovLab9
{
    internal class BankTransaction
    {
        public readonly DateTime Date;
        public readonly decimal Amount;

        public BankTransaction(decimal amount)
        {
            Date = DateTime.Now;
            Amount = amount;
        }
        public override string ToString()
        {
            return $"Дата: {Date}, сумма: {Amount}";
        }

    }
}
