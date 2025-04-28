using System.Data;

namespace Calculator.Services;

public class CalculateService : ICalculateService
{
    public void Calculate(List<HistoryItem> history)
    {
        var historyService = new HistoryService();

        string expression = "";
        
        while (true)
        {
            try
            {
                Console.Write("Enter expression or cancel: ");
    
                expression = Console.ReadLine()!.Trim().ToLower();
    
                if (string.IsNullOrEmpty(expression))
                {
                    Console.WriteLine("Expression cannot be");
                    continue;
                }
                else if (expression == "cancel")
                {
                    return;
                } 
                // faoilsdjkalsdkjf
                // 9 + 3
                var dataTable = new DataTable();

                double result = Convert.ToDouble(dataTable.Compute(expression, null));

                var historyItem = new HistoryItem
                {
                    Id = history.Last().Id + 1,
                    Expression = expression,
                    Result = result,
                    CreatedAt = DateTime.Now
                };

                history.Add(historyItem);
                historyService.SaveHistory("history.json", history);
                Console.WriteLine($"{expression} = {result}");
                break;
            }
            catch  
            { 
                Console.WriteLine($"Error: couldn't compute this expression"); 
            }
        }
    }
}