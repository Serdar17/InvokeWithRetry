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
            if (count < 500)
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
        var invokeCount = 0;
        actionWithoutException = () => invokeCount++;
        Program.InvokeWithRetry(actionWithoutException, maxAttempts);
        Assert.AreNotEqual(maxAttempts, invokeCount);
    }
}