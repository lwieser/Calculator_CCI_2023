namespace ConsoleApp3;

public class Historique
{
    public List<string> Content { get; set; } = new List<string>();
    public string GetLastOperator =>  Content.ElementAt(Content.Count - 2);
    public bool IsLastElementValue => Content.Count % 2 != 0 && Content.Count > 2;
    public void Add(string input)
    {
        Content.Add(input);
        var priorityOperator = new List<string>()
        {
            "*", "/"
        };
        if (IsLastElementValue && priorityOperator.Contains(GetLastOperator))
        {
            Content.Insert(0, "(");
            Content.Insert(  Content.Count - 2, ")");
        }
    }

    public override string ToString()
    {
        return String.Join(" ", Content);
    }

    public int GetResult()
    {
        throw new NotImplementedException();
    }

    public void Revert()
    {
        throw new NotImplementedException();
    }
}