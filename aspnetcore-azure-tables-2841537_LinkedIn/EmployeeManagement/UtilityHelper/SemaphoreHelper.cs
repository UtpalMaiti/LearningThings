using System;
using System.Threading;

namespace EmployeeManagement
{
    internal static class SemaphoreHelper
    {
        public static Semaphore semaphore = null;


        static void Run(string semaphoreKeyName)
        {
            try
            {
                //Try to Open the Semaphore if Exists, if not throw an exception
                semaphore = Semaphore.OpenExisting("SemaphoreDemo");
            }
            catch (Exception Ex)
            {
                //If Semaphore not Exists, create a semaphore instance
                //Here Maximum 2 external threads can access the code at the same time
                semaphore = new Semaphore(2, 2, "SemaphoreDemo");
            }

            Console.WriteLine("External Thread Trying to Acquiring");
            semaphore.WaitOne();
            //This section can be access by maximum three external threads: Start
            Console.WriteLine("External Thread Acquired");
            Console.ReadKey();
            //This section can be access by maximum three external threads: End
            semaphore.Release();
        }
    }
}
