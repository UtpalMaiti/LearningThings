
using System;
using System.Threading;

namespace DeadLockDemo
{
    
    public class AccountManager
    {
        private Account FromAccount;
        private Account ToAccount;
        private readonly double TransferAmount;
        private static readonly Mutex mutex = new Mutex();

        public AccountManager(Account AccountFrom, Account AccountTo, double AmountTransfer)
        {
            this.FromAccount = AccountFrom;
            this.ToAccount = AccountTo;
            this.TransferAmount = AmountTransfer;
        }

        public void FundTransfer()
        {
            object _lock1, _lock2;

            if (FromAccount.ID < ToAccount.ID)
            {
                _lock1 = FromAccount;
                _lock2 = ToAccount;
            }
            else
            {
                _lock1 = ToAccount;
                _lock2 = FromAccount;
            }

            Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {((Account)_lock1).ID}");

            lock (_lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {((Account)_lock1).ID}");
                Console.WriteLine($"{Thread.CurrentThread.Name} Doing Some work");
                Thread.Sleep(3000);
                Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {((Account)_lock2).ID}");
                lock (_lock2)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {((Account)_lock2).ID}");
                    FromAccount.WithdrawMoney(TransferAmount);
                    ToAccount.DepositMoney(TransferAmount);
                }
            }
        }
        public static void RunMain()
        {
            Console.WriteLine("Main Thread Started");
            Account Account1001 = new Account(1001, 5000);
            Account Account1002 = new Account(1002, 3000);
            AccountManager accountManager1 = new AccountManager(Account1001, Account1002, 5000);
            Thread thread1 = new Thread(accountManager1.FundTransfer)
            {
                Name = "Thread1"
            };
            AccountManager accountManager2 = new AccountManager(Account1002, Account1001, 6000);
            Thread thread2 = new Thread(accountManager2.FundTransfer)
            {
                Name = "Thread2"
            };
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("Main Thread Completed");
            Console.ReadKey();
        }
    }
}