namespace ConsoleApp3.Tests;

public class HistoriqueFactory
{
    private static History Init(params string[] content)
    {
        var historique = new History();
        historique.Content = content.ToList();
        return historique;
    }
    public static History TwoPlusTwo()
    {
        return Init("2", "+","2");
    }
    public static History Twenty25()
    {
        return Init("2", "+","3","*","5");
    }

    public static History Priorityzed()
    {
        return Init(            "(", "2", "+", "2",")","*","5");
    }

    public static History TwoPlusTwoPlusTwo()
    { 
        return Init("2", "+","2","+");
    }

    public static History Two()
    {
        return Init("2");
    }

    public static History Empty()
    {
        return Init();

    }
}