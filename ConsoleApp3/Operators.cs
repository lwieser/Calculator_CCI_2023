namespace ConsoleApp3;

public class Operators
{
    public static List<string> All() => Actions.Concat(AllOperator).ToList();
    
    
    public static List<string> Actions = new List<string>()
    {
        "b", "stop"
    };

    public static List<string> Parenthesis = new List<string>()
    {
        "(", ")"
    };
    
    public static List<string> AllOperator = new List<string>()
    {
        "+", "*", "/", "-"
    };

    public static bool IsOperator(string arg)
    {
        return AllOperator.Contains(arg);
    }

    public static bool IsNumber(string arg)
    {
        return int.TryParse(arg, out var _);
    }

    public static bool IsBack(string arg)
    {
        return arg == "b";
    }
}