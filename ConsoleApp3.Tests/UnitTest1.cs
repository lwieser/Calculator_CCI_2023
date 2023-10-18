namespace ConsoleApp3.Tests;

[TestClass]
public class HistoriqueTester
{
    [TestMethod]
    public void GetLastOperator_WithTwoPlusTwo_ThenPlus()
    {
        var historique = new Historique();
        historique.Content = new List<string>()
        {
            "2", "+", "2"
        };

        var res = historique.GetLastOperator;
        Assert.AreEqual("+", res);
    }
    
    [TestMethod]
    public void GetLastOperator_WithTwoPlusTwoPlus_ThenPlus()
    {
        var historique = new Historique();
        historique.Content = new List<string>()
        {
            "2", "+", "2", "+"
        };

        var res = historique.GetLastOperator;
        Assert.AreEqual("+", res);
    }
}

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