namespace ConsoleApp3.Tests;

public class HistoriqueFactory
{
    private static Historique Init(params string[] content)
    {
        var historique = new Historique();
        historique.Content = content.ToList();
        return historique;
    }
    public static Historique TwoPlusTwo()
    {
        return Init("2", "+","2");
    }
    public static Historique Twenty25()
    {
        return Init("2", "+","3","*","5");
    }

    public static Historique Priorityzed()
    {
        return Init(            "(", "2", "+", "2",")","*","5");
    }

    public static Historique TwoPlusTwoPlusTwo()
    { 
        return Init("2", "+","2","+");
    }

    public static Historique Two()
    {
        return Init("2");
    }
}