// See https://aka.ms/new-console-template for more information

using ConsoleApp3;

string op;
var inputManager = new InputManager();
do
{
    inputManager.AddInput();
    Console.WriteLine(inputManager.History.ToString());
    Console.WriteLine("Le résultat est " + inputManager.History.GetResult());

} while (true);