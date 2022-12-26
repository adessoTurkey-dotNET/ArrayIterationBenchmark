using BenchmarkDotNet.Attributes;
using IterationBenchmark.Entities;
using IterationBenchmark.Helpers;

namespace IterationBenchmark.TestQuizes;

[RPlotExporter]
[SimpleJob(id: "TestQuize")]
public class BaseTestQuize
{
    protected User[] users;
    protected int[] points;
    private readonly Random _random = new Random();
    //[Params(1_000, 10_000, 100_000, 200_000, 300_000, 400_000, 500_000, 600_000, 700_000, 800_000, 900_000, 1_000_000, 2_000_000, 3_000_000)]
    [Params(1_000,100_000, 800_000)]
    public int size;

    [IterationSetup]
    public void Setup()
    {
        System.Diagnostics.Debugger.Launch();
        var launch = true;
        points = new int[size];
        if (launch)
        {
            users = new User[size];
            for (var i = 0; i < size; i++)
            {
                users[i] = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = StringGenerator.RandomString(_random.Next(5, 10)),
                    LastName = StringGenerator.RandomString(_random.Next(5, 10)),
                    Point = _random.Next(0, 1000)
                };
            }
        }
        else
        {
            for (var i = 0; i < size; i++)
            {
                points[i] = _random.Next(0, 1000);
            }
        }
    }
}