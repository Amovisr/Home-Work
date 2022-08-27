using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

public class DistancePoint
{
    PointClass1HomeWork pointOne = new PointClass1HomeWork(3, 5);
    PointClass1HomeWork pointTwo = new PointClass1HomeWork(6, 3);
    public float PointDistance1HomeWork(PointClass1HomeWork pointOne, PointClass1HomeWork pointTwo)
    {
        float x = pointOne.X - pointTwo.X;
        float y = pointOne.Y - pointTwo.Y;
        float answer = MathF.Sqrt((x * x) + (y * y));
        return answer;

    }

    [Benchmark]
    public void BenchmarkFirstHomerWork()
    {
        PointDistance1HomeWork(pointOne, pointTwo);
    }
}
public class PointClass1HomeWork
{
    public float X;
    public float Y;

    public PointClass1HomeWork(float x, float y)
    {
        X = x;
        Y = y;
    }

}

