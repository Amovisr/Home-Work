using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

var benchmarkTest = new BenchmarkTest();
benchmarkTest.GenerateHash();
benchmarkTest.BenchmarkTestHashSet();

public class BenchmarkTest
{
    HashSet<string> hash = new HashSet<string>();
    string hashToFind = "9567";

    public string GenerateHash()
    {

        for (int i = 0; i < 10000; i++)
        {
            hash.Add(Convert.ToString(i));
        }
        return hash.ToString();
    }

    public void TryToFindHash()
    {
        if (hash.Contains(hashToFind))
        {
            Console.WriteLine($"Find number : {hashToFind}");
        }
    }
    [Benchmark]
    public void BenchmarkTestHashSet()
    {
        TryToFindHash();
    }

}

