using ConsoleApp3;

public class ProgramRunner
{
    private IReader _reader;

    public ProgramRunner(IReader reader)
    {
        _reader = reader;
    }
    
    public void Run()
    {
        string op;
        var inputManager = new InputManager(_reader);
        string input;
        do
        {
            input = inputManager.AddInput();
            _reader.Write(inputManager.History.ToString());
            var message = "Le résultat est " + inputManager.History.GetResult();
            _reader.Write(message);
        
        } while (input != "stop");
    }   
}