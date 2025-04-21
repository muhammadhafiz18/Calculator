public class DisplayService : IDisplayService
{
    public void PrintHistory(List<HistoryItem> historyItems)
    {
        for (int i = 0; i < historyItems.Count; i++)
            Console.WriteLine($"({i + 1}). {historyItems[i]} | {historyItems[i].CreatedAt:HH:mm:ss}");
    }
}