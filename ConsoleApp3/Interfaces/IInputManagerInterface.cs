namespace ConsoleApp3.Interfaces;

public interface IInputManagerInterface
{
    string AddInput(string input = null);
    History History { get; set; }
}