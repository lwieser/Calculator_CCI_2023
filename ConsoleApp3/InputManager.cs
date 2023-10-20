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
    
    public static List<string> SplitInput(string input)
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

        res = res.Where(x => !String.IsNullOrEmpty(x)).ToList();
        return CleanMinus(res);
    }

    public static List<string> CleanMinus(List<string> res)
    {
        var newRes = new List<string>();
        for (int i = 0; i < res.Count; i++)
        {
            var element = res.ElementAt(i);
            if (int.TryParse(element, out _))
            {
                var prev = res.ElementAtOrDefault(i - 1);
                var prevprev = res.ElementAtOrDefault(i - 2);
                if (prev == "-" && !int.TryParse(prevprev, out _))
                {
                    newRes.RemoveAt(newRes.Count - 1);
                    newRes.Add(prev + element);
                }
                else
                {
                    newRes.Add(element);
                }
            }
            else
            {
                newRes.Add(element);
            }
        }

        return newRes;
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