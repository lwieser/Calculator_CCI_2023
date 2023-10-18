namespace ConsoleApp3.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestSuccess()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void TestFail()
    {
        Assert.IsTrue(false);
    }
}