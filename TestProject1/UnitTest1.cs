using System;
using NUnit.Framework;

namespace TestProject1;

public class Tests
{
    private static int maxAttempts;
    private static Action actionWithException;
    private static Action actionWithoutException;
    
    [SetUp]
    public void Setup()
    {
        maxAttempts = 1000;
    }

    [Test]
    public void TestWithException()
    {
        var count = 0;
        actionWithException = () =>
        {
            while (count < 100)
            {
                count++;
                throw new Exception();
            }
        };
        Assert.IsTrue(Program.InvokeWithRetry(actionWithException, maxAttempts));
    }
    
    [Test]
    public void TestWithoutException()
    {
        var count = 0;
        actionWithoutException = () => count++;
        Assert.IsTrue(Program.InvokeWithRetry(actionWithoutException, maxAttempts));
    }
}