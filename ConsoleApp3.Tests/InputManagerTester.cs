namespace ConsoleApp3.Tests;

[TestClass]
public class InputManagerTester
{
    private InputManager inputManager;

    public InputManagerTester()
    {
        inputManager = new InputManager();
    }

    [TestMethod]
    public void AddInputWithEmptyAndNumberThenNumberIsAdded()
    {
        inputManager.AddInput("2");
        Assert.AreEqual(1, inputManager.Historique.Content.Count);
    }
    
    
    [TestMethod]
    public void AddInputWithEmptyAndOperatorThenEmpty()
    {
        inputManager.AddInput("+");
        Assert.IsFalse(inputManager.Historique.Content.Any());
    }

    [TestMethod]
    public void AddInputTestCase1()
    {
        inputManager.AddInput("2");
        inputManager.AddInput("+");
        inputManager.AddInput("2");
        Assert.AreEqual(4, inputManager.Historique.GetResult());
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
        Assert.AreEqual(48, inputManager.Historique.GetResult());
    }
}