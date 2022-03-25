using System;
using NUnit.Framework;

namespace TestProject1;

public class Program
{
    public static bool InvokeWithRetry(Action action, int maxAttempts)
    {
        for (var i = 0; i < maxAttempts; i++)
        {
            try
            {
                action.Invoke();
            }
            catch
            {
                continue;
            }
            return true;
        } 
        throw new Exception();
    }
}