public static class OperationManager
{
    public static int Compute(string op, int i, int i1)
    {
        switch (op)
        {
            case "+":
                return i + i1;
            case "-":
                return i - i1;
            case "*":
                return i * i1;
            case "/":
                return i / i1;
            default:
                throw new NotImplementedException();
        }
    }
}