namespace ConsoleApp3.Tests;

public class HistoriqueFactory
{
    public static Historique TwoPlusTwo()
    {
        var historique = new Historique();
        historique.Content = new List<string>()
        {
            "2", "+", "2"
        };

        return historique;
    }

    public static Historique TwoPlusTwoPlusTwo()
    {
        var res = TwoPlusTwo();
        TwoPlusTwo().Content.Add("+");
        return res;
    }
}