using System.Text;
namespace IterationBenchmark.Helpers;

public static class StringGenerator
{
    public static string RandomString(int size)
    {
        Random random = new Random();
        var builder = new StringBuilder(size);  
        
        char offset = 'A';  
        const int lettersOffset = 26;
  
        for (var i = 0; i < size; i++)  
        {  
            var @char = (char)random.Next(offset, offset + lettersOffset);  
            builder.Append(@char);  
        }  
  
        return builder.ToString();  
    }  
}