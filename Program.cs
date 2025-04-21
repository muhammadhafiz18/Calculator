using Calculator.Services;

Console.WriteLine("Welcome to Calculator!");

List<HistoryItem> history = [];

string filePath = "history.json";

HistoryService.LoadHistory(filePath, history);

while (true)
{
    Console.WriteLine("availabe commands: calculate, history, clear, exit, cls");

    var input = Console.ReadLine()!.Trim().ToLower(); 

    if (input == "exit")
        break;

    else if (input == "cls")
        Console.Clear();

    else if (input == "history") 
        HistoryService.ShowHistory(history);

    else if (input == "clear")
        HistoryService.ClearHistory(history);
    
    else if (input == "calculate")
        CalculateService.Calculate(history);

    else
        Console.WriteLine("This command is not available");
}
Console.WriteLine("Good bye");