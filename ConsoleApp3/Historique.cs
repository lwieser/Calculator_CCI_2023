namespace ConsoleApp3;

public class Historique
{
    public List<string> Content { get; set; } = new List<string>();
    public string GetLastOperator =>  Content
        .Last(x => Operators.All.Contains(x));
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
        int result = 0;
        foreach (var element in Content)
        {
            // valeur  
            result = int.Parse(element);
            
            // operateur 
        }
        return result;
    }

    public void Revert()
    {
        throw new NotImplementedException();
    }
}