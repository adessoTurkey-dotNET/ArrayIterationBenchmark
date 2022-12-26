using BenchmarkDotNet.Attributes;
using IterationBenchmark.Entities;

namespace IterationBenchmark.TestQuizes;

public class FiterTestQuize:BaseTestQuize
{
    [Benchmark(Baseline = true, Description = "for")]
        public User[] ForLoop()
        {
            var results = new List<User>();
            for (var i = 0; i < users.Length; i++)
            {
                var c = users[i];
                if (c.Point!<200)
                    results.Add(c);
            }
            return results.ToArray();
        }

        /*[Benchmark(Baseline = true, Description = "for int Array")]
        public int[] ForLoopIntArray()
        {
            var result = new List<int>();
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i]!<200)
                {
                    result.Add(points[i]);
                }
            }

            return result.ToArray();
        }*/
        
        /*[Benchmark(Description = "for int Array Ptr")]
        public int[] ForLoopIntArrayPtr()
        {
            var result = new List<int>(); 
            unsafe
            {
                fixed (int* ptr = points)
                {
                    for (var i = 0; i < size; i++)
                    {
                        if (*(ptr + i)!<200)
                        {
                            result.Add(*(ptr + i));
                        }
                    }
                }
            }

            return result.ToArray();
        }*/
        

        [Benchmark(Description = "foreach")]
        public User[] ForEachLoop()
        {
            var results = new List<User>();
            foreach (var c in users)
            {
                if (c.Point!<200)
                    results.Add(c);
            }
            return results.ToArray();
        }

        [Benchmark(Description = "LINQ")]
        public User[] FilteringByLinq() => users.Where(c => c.Point!<200).ToArray();
}