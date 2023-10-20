namespace ConsoleApp3;

public class History : IHistorique
{
    public List<string> Content { get; set; } = new List<string>();
    public string GetLastOperator =>  Content
        .LastOrDefault(x => Operators.AllOperator.Contains(x));

    public bool IsLastElementValue => int.TryParse(Content.LastOrDefault(), out _);
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
        foreach (var element in Content.Where(x => !Operators.Parenthesis.Contains(x)))
        {
            if (Operators.AllOperator.Contains(element))
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
        if (Content.Count == 0) return;
        Content.RemoveAt(Content.Count - 1);
        if (Content.Last() == ")")
        {
            Content.RemoveAt(0);
            Content.RemoveAt(Content.Count - 1);
        }
    }
}