namespace ConsoleApp3;

public interface IHistorique
{
    List<string> Content { get; set; }
    string GetLastOperator { get; }
    bool IsLastElementValue { get; }
    void Add(string input);
    string ToString();
    int GetResult();
    void Revert();
}