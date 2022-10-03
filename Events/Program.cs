
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

        private static void AfterComplete(object sender, TransectionEventArgs eventArgs)
        {
            Console.WriteLine($"Sender: {sender}, Completed with message: {eventArgs.Message} Status: {eventArgs.Ok}");
        }
    }


    public class Transaction
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
            var eventArgs = new TransectionEventArgs
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
