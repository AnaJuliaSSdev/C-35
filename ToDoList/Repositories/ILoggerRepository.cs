using ToDoList.Models;

namespace ToDoList.Repositories;

public interface ILoggerRepository
{
    void AddLog(RequestLog log);
    List<RequestLog> GetAllLoggs();
}
