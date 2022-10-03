
using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            transaction.TransactionComplete += AfterComplete;
            transaction.StartTransaction();
        }

        private static void AfterComplete()
        {
            Console.WriteLine("Completed");
        }
    }

    public delegate void Notify();

    public class Transaction
    {
        public Notify TransactionComplete { get; set; }

        public void StartTransaction()
        {
            //Do something;
            OnTransactionComplete();

        }

        protected virtual void OnTransactionComplete()
        {
            TransactionComplete?.Invoke();
        }
    }
}
