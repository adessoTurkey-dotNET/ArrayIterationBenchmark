using BenchmarkDotNet.Attributes;
using IterationBenchmark.Entities;

namespace IterationBenchmark.TestQuizes;

public class TransformationTestQuize : BaseTestQuize
{
    private static User ToNamesInLowerCase(User c) => new User
    {
        Id = c.Id,
        FirstName = c.FirstName.ToLower(),
        LastName = c.LastName.ToLower(),
        Point = c.Point
    };

        [Benchmark(Baseline = true, Description = "for")]
        public User[] UsersToNamesInLowerCase_For()
        {
            var usersToNamesInLowerCase = new List<User>(users.Length);
            for (var i = 0; i < users.Length; i++)
            {
                usersToNamesInLowerCase.Add(ToNamesInLowerCase(users[i]));
            }
            return usersToNamesInLowerCase.ToArray();
        }

        [Benchmark(Description = "foreach")]
        public User[] UsersToNamesInLowerCase_ForEach()
        {
            var usersToNamesInLowerCase = new List<User>(users.Length);
            foreach (var user in users)
            {
                usersToNamesInLowerCase.Add(ToNamesInLowerCase(user));
            }
            return usersToNamesInLowerCase.ToArray();
        }

        [Benchmark(Description = "LINQ select")]
        public User[] UsersToNamesInLowerCase_LINQ() => users.Select(ToNamesInLowerCase).ToArray();
}