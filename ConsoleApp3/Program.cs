// See https://aka.ms/new-console-template for more information

string op;
int a ;
int b;
do
{ 
    a = InputManager.GetNumberInputLoop("A");
    op = InputManager.GetOperator();
    b = InputManager.GetNumberInputLoop("B");
    int result = a + b;
    Console.WriteLine("Le résultat est " + result);

} while (op != "bye");