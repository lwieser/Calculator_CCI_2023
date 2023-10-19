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
        int? result = null;
        string op = "";
        foreach (var element in Content)
        {
            if (Operators.All.Contains(element))
            {
                op = element;
            }
            else
            {
                if (result == null)
                {
                    result = int.Parse(element);
                }
                else
                {
                    result = OperationManager.Compute(op, result.Value, int.Parse(element));
                }
            }
        }
        return !result.HasValue ? 0 : result.Value;
    }

    public void Revert()
    {
        Content.RemoveAt(Content.Count - 1);
    }
}