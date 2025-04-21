using System.Text.Json;

namespace Calculator.Services;

public class HistoryService : IHistoryService
{
    public void ShowHistory(List<HistoryItem> history)  
    {
        if (history.Count == 0)
        {
            Console.WriteLine("History is empty");
            return;
        }

        DisplayService.PrintHistory(history);
    }
    public void ClearHistory(List<HistoryItem> history)
    {
        if (history.Count == 0)
        {
            Console.WriteLine("Nothing to clear.");
            return;
        }
        ShowHistory(history);

        while (true)
        {
            Console.Write("Delete Index or 'all' or 'cancel' to go back: ");
            string input = Console.ReadLine()?.ToLower()!;

            if (input == "all")
            {
                history.Clear();
                SaveHistory(history);
                Console.WriteLine("History cleared.");
                break;
            }
            else if (input == "cancel")
            {
                Console.WriteLine("Cancelled.");
                break;
            }
            else if (int.TryParse(input, out int index) && index > 0 && index <= history.Count)
            {

                history.RemoveAt(index - 1);
                SaveHistory(history);
                Console.WriteLine("Entry removed.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
    public void SaveHistory(List<HistoryItem> historyItems)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string jsonString = JsonSerializer.Serialize(historyItems, options);
        File.WriteAllText("history.json", jsonString);
    }
    public void LoadHistory(string path, List<HistoryItem> historyItems)
    {
        if(File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var history = JsonSerializer.Deserialize<List<HistoryItem>>(jsonString, options);

            if(history != null)
                historyItems.AddRange(history);
        }
    }
}