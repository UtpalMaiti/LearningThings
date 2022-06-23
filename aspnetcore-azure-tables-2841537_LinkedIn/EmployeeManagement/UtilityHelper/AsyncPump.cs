using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    /// <summary>Provides a pump that supports running asynchronous methods on the current thread.</summary>
    public static partial class AsyncPump
    {
        /// <summary>Runs the specified asynchronous method.</summary>
        /// <param name="asyncMethod">The asynchronous method to execute.</param>
        public static void Run(Action asyncMethod)
        {
            if (asyncMethod == null) throw new ArgumentNullException("asyncMethod");

            var prevCtx = SynchronizationContext.Current;
            try
            {
                // Establish the new context
                var syncCtx = new SingleThreadSynchronizationContext(true);
                SynchronizationContext.SetSynchronizationContext(syncCtx);

                // Invoke the function
                syncCtx.OperationStarted();
                asyncMethod();
                syncCtx.OperationCompleted();

                // Pump continuations and propagate any exceptions
                syncCtx.RunOnCurrentThread();
            }
            finally { SynchronizationContext.SetSynchronizationContext(prevCtx); }
        }

        /// <summary>Runs the specified asynchronous method.</summary>
        /// <param name="asyncMethod">The asynchronous method to execute.</param>
        public static void Run(Func<Task> asyncMethod)
        {
            if (asyncMethod == null) throw new ArgumentNullException("asyncMethod");

            var prevCtx = SynchronizationContext.Current;
            try
            {
                // Establish the new context
                var syncCtx = new SingleThreadSynchronizationContext(false);
                SynchronizationContext.SetSynchronizationContext(syncCtx);

                // Invoke the function and alert the context to when it completes
                var t = asyncMethod();
                if (t == null) throw new InvalidOperationException("No task provided.");
                t.ContinueWith(delegate { syncCtx.Complete(); }, TaskScheduler.Default);

                // Pump continuations and propagate any exceptions
                syncCtx.RunOnCurrentThread();
                t.GetAwaiter().GetResult();
            }
            finally { SynchronizationContext.SetSynchronizationContext(prevCtx); }
        }

        /// <summary>Runs the specified asynchronous method.</summary>
        /// <param name="asyncMethod">The asynchronous method to execute.</param>
        public static T Run<T>(Func<Task<T>> asyncMethod)
        {
            if (asyncMethod == null) throw new ArgumentNullException("asyncMethod");

            var prevCtx = SynchronizationContext.Current;
            try
            {
                // Establish the new context
                var syncCtx = new SingleThreadSynchronizationContext(false);
                SynchronizationContext.SetSynchronizationContext(syncCtx);

                // Invoke the function and alert the context to when it completes
                var t = asyncMethod();
                if (t == null) throw new InvalidOperationException("No task provided.");
                t.ContinueWith(delegate { syncCtx.Complete(); }, TaskScheduler.Default);

                // Pump continuations and propagate any exceptions
                syncCtx.RunOnCurrentThread();
                return t.GetAwaiter().GetResult();
            }
            finally { SynchronizationContext.SetSynchronizationContext(prevCtx); }
        }
    }
}
