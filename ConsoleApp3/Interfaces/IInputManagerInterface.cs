namespace ConsoleApp3.Interfaces;

public interface IInputManagerInterface
{
    void AddInput(string input = null);
    Historique Historique { get; set; }
}