
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchmarkDemo
{
    public class ThreadStartVsThreadPoolQueueVsTaskRunBenchmark
    {
        [Benchmark]
        public void ThreadStart()
        {
            bool b = false;

            var thread = new Thread(() => { b = true; });
            thread.Start();

            while (Volatile.Read(ref b) == false) ;
        }

        [Benchmark]
        public void ThreadPoolQueue()
        {
            bool b = false;

            ThreadPool.QueueUserWorkItem(o=> { b = true; });

            while (Volatile.Read(ref b) == false) ;
        }

        [Benchmark]
        public void TaskRun()
        {
            bool b = false;

            Task.Run(() => { b = true; });

            while (Volatile.Read(ref b) == false) ;
        }

    }
}