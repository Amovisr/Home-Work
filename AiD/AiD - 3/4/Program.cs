using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
public class StructTest
{
    PointStructHomeWork pointOne = new PointStructHomeWork(3, 8);
    PointStructHomeWork pointTwo = new PointStructHomeWork(4, 21);
    public static float PointDistance4HomeWork(PointStructHomeWork pointOne, PointStructHomeWork pointTwo)
    {
        float x = pointOne.X - pointTwo.X;
        float y = pointOne.Y - pointTwo.Y;
        return (x * x) + (y * y); 
    }


    [Benchmark]
    public void BenchmarkFourthHomerWork()
    {
        PointDistance4HomeWork(pointOne, pointTwo);
    }
}
public struct PointStructHomeWork
{
    public float X;
    public float Y;
    public PointStructHomeWork(float x, float y)
    {
        X = x;
        Y = y;
    }
}