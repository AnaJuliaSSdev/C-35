using ToDoList.Enums;
using ToDoList.Models;

namespace ToDoList.Repositories;

public interface ITodoRepository
{
    void AddToDo(ToDo todo);
    public List<ToDo> GetAllToDos(int skip, int take, TodoPriority? priority, bool? isCompleted);
    ToDo GetToDoById(int id);
    void UpdateIsCompleted(int id);
    void DeleteToDo(ToDo todo);

}
