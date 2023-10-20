namespace ConsoleApp3.Interfaces;

public interface IInputManagerInterface
{
    void AddInput(string input = null);
    History History { get; set; }
}