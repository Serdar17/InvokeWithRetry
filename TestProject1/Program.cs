using System;

namespace TestProject1;

public class Program
{
    public static bool InvokeWithRetry(Action action, int maxAttempts)
    {
        var exceptionCount = 0;
        for (var i = 0; i < maxAttempts; i++)
        {
            try
            {
                action.Invoke();
            }
            catch
            {
                exceptionCount++;
            }
        }
        return maxAttempts > exceptionCount;
    }
}