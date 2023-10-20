using ConsoleApp3.Interfaces;

namespace ConsoleApp3.Tests;

public class InputManagerGenericTester
{
    protected IInputManagerInterface inputManager;
    
    [TestMethod]
    public void AddInputTestCase3()
    {
        new List<string>()
        {
            "2+3b4*6bb*8"
        }.ForEach(x =>
        {
            inputManager.AddInput(x);
        });
        Assert.AreEqual(48, inputManager.History.GetResult());
    }

    [TestMethod]
    public void GetResultDavid()
    {
        inputManager.AddInput("2++23");
        var res = inputManager.History.GetResult();
        Assert.AreEqual(25, res);
    }
    
    
    [TestMethod]
    public void AddInputWithEmptyAndNumberThenNumberIsAdded()
    {
        inputManager.AddInput("2");
        Assert.AreEqual(1, inputManager.History.Content.Count);
    }
    
    
    [TestMethod]
    public void AddInputWithEmptyAndOperatorThenEmpty()
    {
        inputManager.AddInput("+");
        Assert.IsFalse(inputManager.History.Content.Any());
    }
    
    [TestMethod]
    public void AddInputWithMinusOperator()
    {
        inputManager.AddInput("2-3");
        Assert.AreEqual(-1, inputManager.History.GetResult());
    }

    [TestMethod]
    public void AddInputTestCase1()
    {
        inputManager.AddInput("2");
        inputManager.AddInput("+");
        inputManager.AddInput("2");
        Assert.AreEqual(4, inputManager.History.GetResult());
    }
    
    [TestMethod]
    public void AddInputTestCase2()
    {
        new List<string>()
        {
            "2", "+", "3", "b", "4", "*","6","b","b","*","8"
        }.ForEach(x =>
        {
            inputManager.AddInput(x);
        });
        Assert.AreEqual(48, inputManager.History.GetResult());
    }
}