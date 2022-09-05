using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Columns;

namespace BenchmarkDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<MemoryBenchmarkerDemo>();
            //BenchmarkRunner.Run<SleepVsDelayBenchmark>();
            BenchmarkRunner.Run<ThreadStartVsThreadPoolQueueVsTaskRunBenchmark>(
                DefaultConfig.Instance.AddColumn(StatisticColumn.P95)
            );
        }

    }

    // https://www.youtube.com/watch?v=4kH4IFuDJG8&t=1679s

    public class SleepVsDelayBenchmark
    {
        [Params(1, 5, 50)]
        public int Duration;

        [Benchmark]
        public void ThreadSleep() => Thread.Sleep(Duration);

        [Benchmark]
        public Task TaskDelay() => Task.Delay(Duration);
    }

    [RankColumn]
    [MemoryDiagnoser]
    public class MemoryBenchmarkerDemo
    {
        int NumberOfItems = 100_000;
        [Benchmark]
        public string ConcatStringsUsingStringBuilder()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < NumberOfItems; i++)
            {
                sb.Append("Hello World!" + i);
            }
            return sb.ToString();
        }
        [Benchmark]
        public string ConcatStringsUsingGenericList()
        {
            var list = new List<string>(NumberOfItems);
            for (int i = 0; i < NumberOfItems; i++)
            {
                list.Add("Hello World!" + i);
            }
            return list.ToString();
        }
    }
}