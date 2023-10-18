namespace ConsoleApp3.Tests;

[TestClass]
public class HistoriqueTester
{
    [TestMethod]
    public void GetLastOperator_WithTwoPlusTwo_ThenPlus()
    {
        var res = HistoriqueFactory.TwoPlusTwo().GetLastOperator;
        Assert.AreEqual("+", res);
    }
    
    [TestMethod]
    public void GetLastOperator_WithTwoPlusTwoPlus_ThenPlus()
    {
        var res = HistoriqueFactory.TwoPlusTwoPlusTwo().GetLastOperator;
        Assert.AreEqual("+", res);
    }

    [TestMethod]
    public void GetResult_WithTwoPlusTwo_ThenFour()
    {
        Assert.AreEqual(4, HistoriqueFactory.TwoPlusTwo().GetResult());
    }
    [TestMethod]
    public void GetResult_WithPriorityzed_ThenFour()
    {
        Assert.AreEqual(20, HistoriqueFactory.Priorityzed().GetResult());
    }

    [TestMethod]
    public void Revert_WithTwoPlusTwo_ThenTwoPlus()
    {
        var hist = HistoriqueFactory.TwoPlusTwo();
        hist.Revert();
        Assert.IsTrue(hist.Content.SequenceEqual(new List<string>(){"2","+"}));
    }
    
    [TestMethod]
    public void Revert_WithPriorityezd_ThenTwoPlusTwo()
    {
        var hist = HistoriqueFactory.Priorityzed();
        hist.Revert();
        hist.Revert();
        Assert.IsTrue(hist.Content.SequenceEqual(new List<string>(){"2","+", "2"}));
    }
}