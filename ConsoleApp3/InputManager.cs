using ConsoleApp3.Interfaces;

namespace ConsoleApp3;

public class InputManager : IInputManagerInterface
{
    private IReader _reader;
    public History History { get; set; } = new History();

    public InputManager(IReader reader)
    {
        _reader = reader;
    }
    
    public List<string> SplitInput(string input)
    {
        if (input == null) return new List<string>();
        
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
    
    public string AddInput(string inputToSplit = null)
    {
        if (inputToSplit == null)
        {
            inputToSplit = _reader.Read();
        }

        var inputs = SplitInput(inputToSplit);
        foreach (var input in inputs)
        {
            if (Operators.IsBack(input))
            {
                History.Revert();
            }
            else
            {
                var isNumber = int.TryParse(input, out var intValue);
                if (History.IsLastElementValue && !isNumber)
                {
                    History.Add(input);
                }
                if (!History.IsLastElementValue && isNumber)
                {
                    History.Add(input);
                }
            }

        }

        return inputs.LastOrDefault();
    }
}