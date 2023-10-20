using ConsoleApp3.Interfaces;

namespace ConsoleApp3;

public class InputManagerV2 : IInputManagerInterface
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

    public string GetOperator(string input = null)
    {
        var operators = Operators.All();
        if (input == null)
        {
            Console.WriteLine("Veuillez saisir l'opérateur");
            input = Console.ReadLine();
        }

        do
        {
            if (!operators.Contains(input))
            {
                Console.WriteLine($"Opérateur invalide ({String.Join(",", operators)})");
            }
        } while (!operators.Contains(input));

        Historique.Add(input);
        return input;
    }

    public void AddInput(string input = null)
    {
        if (input == null)
        {
            input = Console.ReadLine();
        }

        if (input == "b")
        {
            Historique.Revert();
        }

        if (Operators.All().Contains(input) && input != "b" && Historique.Content.Any())
        {
            GetOperator(input);
        }

        var isNumber = int.TryParse(input, out var intValue);
        if (!isNumber)
        {
            if (input.Length > 2)
            {
                var elements = input.ToCharArray();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] == 'b') Historique.Revert();
                    else
                    {
                        // string value = "";
                        // while (int.TryParse(elements[i].ToString(), out var intValue2))
                        // {
                        //     value += elements[i];
                        //     i++;
                        // }
                        //
                        // if (value != "")
                        // {
                        //     Historique.Add(value);
                        // } else Historique.Add(elements[i].ToString());
                        Historique.Add(elements[i].ToString());
                        // if (i < elements.Length - 2 && int.TryParse(elements[i].ToString(), out intValue))
                        // {
                        //     var nextElementIsNumber = int.TryParse(elements[i + 1].ToString(), out intValue);
                        //     if (nextElementIsNumber)
                        //     {
                        //         var value = elements[i].ToString() + elements[i + 1];
                        //         // Historique.Content[i] = elements[i + 1];
                        //         Historique.Add(value);
                        //         i++;
                        //     }
                        // }
                    }
                }
            }
            else if (Historique.IsLastElementValue & input.Length < 2)
            {
                Historique.Add(input);
            }
        }

        if (!Historique.IsLastElementValue && isNumber)
        {
            Historique.Add(input);
        }
    }
}
