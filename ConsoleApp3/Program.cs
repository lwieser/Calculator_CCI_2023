// See https://aka.ms/new-console-template for more information

using ConsoleApp3;

string op;
var inputManager = new InputManager();
do
{
    inputManager.AddInput();
    Console.WriteLine(inputManager.Historique.ToString());
    Console.WriteLine("Le résultat est " + inputManager.Historique.GetResult());

} while (true);