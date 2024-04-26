using ToDoList.Models;

namespace ToDoList.Repositories;

public class LoggerRepository : ILoggerRepository
{
    private readonly List<RequestLog> logs = new();
    public void AddLog(RequestLog log)
    {
        logs.Add(log);
    }

    public List<RequestLog> GetAllLoggs()
    {
       return logs;
    }
}
