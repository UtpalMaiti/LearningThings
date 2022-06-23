using EmployeeManagement.Data.Common;
using EmployeeManagement.Data.Operations;

using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.CreateTableAsync("Employee").GetAwaiter().GetResult();

            Operations dataOperations = new Operations();
            dataOperations.TriggerOperations().Wait();
            dataOperations.TriggerOperations().GetAwaiter().GetResult();
            dataOperations.TriggerOperations().RunSynchronously();
            dataOperations.TriggerOperations().ConfigureAwait(false);
            //dataOperations.TriggerOperations().
            //(dataOperations.TriggerOperations()).WaitAndUnwrapException();
            //Task.Wait or Task.Result
            //AsyncContext.RunTask(MyAsyncMethod).Result

            //Task.Run(async () => await MyAsyncMethod());
            //AsyncContext.Run(MyAsyncMethod);
            Console.ReadKey();
        }
    }
}
