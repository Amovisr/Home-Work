using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

var bechmarkTest = new BechmarkTest();
bechmarkTest.GenerateNumberts();
bechmarkTest.TryToFindNumber();    
public class BechmarkTest
{
    string[] someStrings = new string[10001];
    string stringsToFind = "9956";
    
    
    public void GenerateNumberts()
    {
        for (int i = 0; i < someStrings.Length; i++)
        {
            someStrings[i] = Convert.ToString(i);
        }

    }

    public void TryToFindNumber()
    {
            if (someStrings.Contains(stringsToFind))
            {
                Console.WriteLine($"FIND {stringsToFind} in Array");
            }
    }

    [Benchmark]
    public string BechmarkCheckArray()
    {
        TryToFindNumber();
        return stringsToFind;
    }

}







