using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
public class StructTest
{
    PointStructHomeWork pointOne = new PointStructHomeWork(3, 8);
    PointStructHomeWork pointTwo = new PointStructHomeWork(4, 21);
    public static double PointDistance2HomeWork(PointStructHomeWork pointOne, PointStructHomeWork pointTwo)
    {
        double x = pointOne.X - pointTwo.X;
        double y = pointOne.Y - pointTwo.Y;
        return Math.Sqrt((x * x) + (y * y));
    }


    [Benchmark]
    public void BenchmarkSecondHomerWork()
    {
        PointDistance2HomeWork(pointOne, pointTwo);
    }
}
public struct PointStructHomeWork
{
    public double X;
    public double Y;
    public PointStructHomeWork(double x, double y)
    {
        X = x;
        Y = y;
    }
}