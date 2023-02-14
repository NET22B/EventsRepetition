
using System;
#nullable disable

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            var sub = new SubScriber(transaction);
            var sub2 = new SubScriber2(transaction);
            transaction.StartTransaction(false);
        }

    }

    public class SubScriber
    {
        public SubScriber(Transaction transaction)
        {
            transaction.TransactionComplete += AfterComplete;
        }

        private static void AfterComplete(object sender, TransectionEventArgs eventArgs)
        {
            Console.WriteLine($"Sender: {sender}, Completed with message: {eventArgs.Message} Status: {eventArgs.Ok}");
        }
    } 
    
    public class SubScriber2
    {
        public SubScriber2(Transaction transaction)
        {
            transaction.TransactionComplete += AfterComplete;

        }
        private static void AfterComplete(object sender, TransectionEventArgs eventArgs)
        {
            Console.WriteLine($"Here we do something else");
        }
    }


    public class Transaction //Publisher
    {
        public event EventHandler<TransectionEventArgs> TransactionComplete;

        public void StartTransaction(bool ok)
        {
            //Do something;
            if(ok)
            {
                 OnTransactionComplete("All ok", true);
            }
            else
            {
                 OnTransactionComplete("Failed", false);
            }

        }

        protected virtual void OnTransactionComplete(string message, bool ok)
        {
            var eventArgs = new TransectionEventArgs //Eventuellt flytta upp i Transaction
            {
                Message = message,
                Ok = ok
            };

            TransactionComplete?.Invoke(this, eventArgs);
        }
    }

    public class TransectionEventArgs : EventArgs
    {
        public string Message { get; set; }

        public bool Ok { get; set; }
    }
}
