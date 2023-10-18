// See https://aka.ms/new-console-template for more information

string op;
var a = InputManager.GetNumberInputLoop("A");
do
{
    op = InputManager.GetOperator();
    var b = InputManager.GetNumberInputLoop("B");
    a = OperationManager.Compute(op, a, b);
    Console.WriteLine("Le résultat est " + a);

} while (op != "bye");