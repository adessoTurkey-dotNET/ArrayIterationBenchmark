using BenchmarkDotNet.Attributes;

namespace IterationBenchmark.TestQuizes;

public class IterationTestQuize : BaseTestQuize
{
    [Benchmark(Description = "for")]
        public int ForLoop()
        {
            var count = 0;
            for (var i = 0; i < users.Length; i++)
            {
                if (users[i].Point<200)
                {
                    count++;
                }
            }
            return count;
        }

        [Benchmark(Description = "foreach")]
        public int ForEachLoop()
        {
            var count = 0;
            foreach (var c in users)
            {
                if (c.Point<200)
                {
                    count++;
                }
            }
            return count;
        }
        
        [Benchmark(Description = "LINQ")]
        public int LinqCount() => users.Count(c => c.Point<200);
}