using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
public class StructTest
{
    PointStructHomeWork pointOne = new PointStructHomeWork(3,8);
    PointStructHomeWork pointTwo = new PointStructHomeWork(4,21);
 public float PointDistance2HomeWork(PointStructHomeWork pointOne, PointStructHomeWork pointTwo)
    {
        float x = pointOne.X - pointTwo.X;
        float y = pointOne.Y - pointTwo.Y;
        float answer = MathF.Sqrt((x * x) + (y * y));
        return answer;

    }

    [Benchmark]
    public void BenchmarkSecondHomerWork()
    {
        PointDistance2HomeWork(pointOne, pointTwo);
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
