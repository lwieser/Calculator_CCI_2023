namespace ConsoleApp3.Tests;

[TestClass]
public class OperationManagerTester
{
    [TestMethod]
    public void ComputeWith4Divide2Then2()
    {
        var res = OperationManager.Compute("/", 4, 2);
        Assert.AreEqual(2, res);
    }

    [TestMethod, ExpectedException(typeof(NotImplementedException))]
    public void ComputeWithUnknwownOperatorThenNotImplementedException()
    {
        OperationManager.Compute("AZEAZE", 2, 2);
    }
}