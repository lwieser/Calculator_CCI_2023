// See https://aka.ms/new-console-template for more information

string op;
var inputManager = new InputManager();
var a = inputManager.GetNumberInputLoop("A");
do
{
    op = inputManager.GetOperator();
    var b = inputManager.GetNumberInputLoop("B");
    a = OperationManager.Compute(op, a, b);
    Console.WriteLine(inputManager.PrintHistorique());
    Console.WriteLine("Le résultat est " + a);

} while (op != "bye");