using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

internal class Program
{
    private static void Main(string[] args)
    {
        //var summary = BenchmarkRunner.Run<MemoryBenchmarkerDemo>();

        int n = 17;
        System.Console.WriteLine(Math.Log2(n));
        System.Console.WriteLine(Math.Log2(n) % 1);
    }

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