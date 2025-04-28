public interface IDisplayService
{
    void PrintHistory(List<HistoryItem> history);
    string ReadInput(string message);
}