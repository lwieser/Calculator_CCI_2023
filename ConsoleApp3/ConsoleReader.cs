namespace ConsoleApp3;

public class ConsoleReader : IReader
{
    public string Read()
    {
        return Console.ReadLine();
    }

    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}