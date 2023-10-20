using ConsoleApp3.Interfaces;

namespace ConsoleApp3;

public class InputManager : IInputManagerInterface
{
    public Historique Historique { get; set; } = new Historique();
    


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
    }
}