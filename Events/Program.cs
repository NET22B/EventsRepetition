
using System;
#nullable disable

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            transaction.TransactionComplete += AfterComplete;
            transaction.StartTransaction(false);
        }

        private static void AfterComplete(object sender, string message)
        {
            Console.WriteLine($"Sender: {sender}, Completed with message: {message}");
        }
    }


    public class Transaction
    {
        public event EventHandler<string> TransactionComplete;

        public void StartTransaction(bool ok)
        {
            //Do something;
            if(ok)
            {
                 OnTransactionComplete("All ok");
            }
            else
            {
                 OnTransactionComplete("Failed");
            }

        }

        protected virtual void OnTransactionComplete(string message)
        {
            TransactionComplete?.Invoke(this, message);
        }
    }
}
