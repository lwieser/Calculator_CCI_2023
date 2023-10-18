namespace ConsoleApp3;

public class InputManager
{
    public Historique Historique { get; set; } = new Historique();
    
    public int GetNumberInputLoop(string label)
    {
        int? a = null;
        do
        {
            Console.WriteLine("Veuillez saisir la valeur de  " + label);
            a = GetNumberInput();
        } while (a == null);

        Historique.Add(a.ToString());

        return a.Value;
    }

    public static int? GetNumberInput()
    {
        var canParse = int.TryParse(Console.ReadLine(), out var result);
        if (!canParse)
        {
            Console.WriteLine("La valeur saisie n'est pas un entier");
            return null;
        }

        return result;
    }

    public string GetOperator()
    {
        string input;
        List<string> operators = new List<string>()
        {
            "+", "-", "*", "/"
        };
        do
        {
            input = Console.ReadLine();
            if (!operators.Contains(input))
            {
                Console.WriteLine($"Opérateur invalide ({String.Join(",", operators)})");
            }
        } while (!operators.Contains(input));
        Historique.Add(input);
        return input;
    }

}