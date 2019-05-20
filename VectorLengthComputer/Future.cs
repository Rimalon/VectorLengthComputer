using System;
using System.Threading.Tasks;

namespace VectorLengthComputer
{
    class Future<TResult>
    {
        private Task<TResult> task;

        public TResult Result
        {
            get
            {
                task.Wait();
                return task.Result;
            }
        }

        public Future(Func<TResult> func)
        {
            task = new Task<TResult>(func);
            task.Start();
        }
    }
}
