using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchmarkDemo
{
    [MemoryDiagnoser]
    public class StringConcatVsStringBuilder
    {

        public string str1, str2, str3, str4, str5;

        public StringConcatVsStringBuilder()
        {
            str1 = new string('1', 50);
            str2 = new string('1', 150);
            str3 = new string('1', 300);
            str4 = new string('1', 500);
            str5 = new string('1', 1500);
        }

        [Benchmark]
        public string StringConcat()
        {
            return str1 + str2 + str3 + str4 + str5;
        }

        [Benchmark]
        public string StringConcat_Slower()
        {
            var result = "";
            result += str1;
            result += str2;
            result += str3;
            result += str4;
            result += str5;

            return result;
        }

        [Benchmark]
        public string StringBuilder()
        {
            var sb = new StringBuilder();
            sb.Append(str1);
            sb.Append(str2);
            sb.Append(str3);
            sb.Append(str4);
            sb.Append(str5);
            
            return sb.ToString();        
        }

        [Benchmark]
        public string StringBuilder_WithCapacity()
        {
            var sb = new StringBuilder(str1.Length + str2.Length + str3.Length + str4.Length + str5.Length);
            sb.Append(str1);
            sb.Append(str2);
            sb.Append(str3);
            sb.Append(str4);
            sb.Append(str5);
            
            return sb.ToString();        
        }

    }
}