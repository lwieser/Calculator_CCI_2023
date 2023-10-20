namespace ConsoleApp3.Tests;




[TestClass]
public class InputManagerTester
{
    private InputManager inputManager;

    public InputManagerTester()
    {
        inputManager = new InputManager(new ConsoleReader());
    }



    [TestMethod]
    public void SplitInputWithTwoPlusTwo()
    {
        var res = inputManager.SplitInput("2+2");
        var execetedResult = new List<string>()
        {
            "2", "+", "2"
        };
        Assert.IsTrue(res.SequenceEqual(execetedResult));
    }

    [TestMethod]
    public void SplitInputWithNull()
    {
        var res = inputManager.SplitInput(null);
        Assert.AreEqual(0, res.Count);
    }

    [TestMethod]
    public void CleanMinusWithNegative()
    {
        var res = InputManager.CleanMinus(new List<string>()
        {
            "2","+","-","2"
        });
        Assert.IsTrue(res.SequenceEqual(new List<string>(){"2","+","-2"}));
        
    }
    
    [TestMethod]
    public void CleanMinusWithStartNegative()
    {
        var res = InputManager.CleanMinus(new List<string>()
        {
            "-2","+","-","2"
        });
        Assert.IsTrue(res.SequenceEqual(new List<string>(){"-2","+","-2"}));
    }
    
    [TestMethod]
    public void SplitInputWithDavid()
    {
        var res = inputManager.SplitInput("2++23");
        var execetedResult = new List<string>()
        {
            "2", "+","+", "23"
        };
        Assert.IsTrue(res.SequenceEqual(execetedResult));
    }

    [TestMethod]
    public void SplitInput_WithTestCase3ThenCheck()
    {
        var splitted = inputManager.SplitInput("2+3b4*6bb*8");
        Assert.AreEqual(3, splitted.Count(Operators.IsOperator));
        Assert.AreEqual(5, splitted.Count(Operators.IsNumber));
        Assert.AreEqual(3, splitted.Count(Operators.IsBack));
    }
}