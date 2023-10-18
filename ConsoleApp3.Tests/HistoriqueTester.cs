namespace ConsoleApp3.Tests;

[TestClass]
public class HistoriqueTester
{
    [TestMethod]
    public void GetLastOperator_WithTwoPlusTwo_ThenPlus()
    {
        var res = HistoriqueFactory.TwoPlusTwo();
        Assert.AreEqual("+", res);
    }
    
    [TestMethod]
    public void GetLastOperator_WithTwoPlusTwoPlus_ThenPlus()
    {
        var res = HistoriqueFactory.TwoPlusTwoPlusTwo().GetLastOperator;
        Assert.AreEqual("+", res);
    }
}