using System;
using System.Threading;

namespace Beanify.Utils.Parallels
{
    public class ParallelTask
    {
        public void ExecuteParallelLoop(CancellationToken cancellation, string input, Action<string> setOutput)
        {
            while (true)
            {
                if (cancellation.IsCancellationRequested)
                {
                    cancellation.ThrowIfCancellationRequested();
                }
                setOutput(input);
                Thread.Sleep(150);
            }
        }
    }
}
