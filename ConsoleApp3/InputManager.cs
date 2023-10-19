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
        Console.WriteLine("Veuillez saisir l'opérateur");
        string input;
        var operators = Operators.AllOperator;
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

    public List<string> SplitInput(string input)
    {
        var res = new List<string>()
        {
            input
        };
        foreach (var actions in Operators.All())
        {
            var splitted = res.Select(x => x.Split(actions)).ToList();
            res = new List<string>();
            foreach (var split in splitted)
            {
                if (split.Length == 1)
                {
                    res.Add(split.First());
                }
                else
                {
                    for (var i = 0; i < split.Length; i++)
                    {
                        if (i == 0)
                        {
                            res.Add(split[i]);
                        }
                        else
                        {
                            res.Add(actions);
                            res.Add(split[i]);
                        }
                    }
                }
            }

        }

        return res.Where(x => !String.IsNullOrEmpty(x)).ToList();
    }
    
    public void AddInput(string inputToSplit = null)
    {
        if (inputToSplit == null)
        {
            inputToSplit = Console.ReadLine();
        }

        foreach (var input in SplitInput(inputToSplit))
        {
            if (input == "b")
            {
                Historique.Revert();
            }
            else
            {
                var isNumber = int.TryParse(input, out var intValue);
                if (Historique.IsLastElementValue && !isNumber)
                {
                    Historique.Add(input);
                }
                if (!Historique.IsLastElementValue && isNumber)
                {
                    Historique.Add(input);
                }
            }
        }

        ;
    }
}