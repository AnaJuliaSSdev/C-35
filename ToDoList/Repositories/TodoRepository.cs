using ToDoList.Enums;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private static List<ToDo> toDos = new List<ToDo>();

        public void AddToDo(ToDo toDo)
        {
            toDos.Add(toDo);
        }

        public void DeleteToDo(ToDo toDo)
        {
            toDos.Remove(toDo);
        }

        public ToDo GetToDoById(int id)
        {
            return toDos.FirstOrDefault(toDo => toDo.Id == id);
        }

        public List<ToDo> GetAllToDos(int skip = 0, int take = 20, TodoPriority? priority = null, bool? isCompleted = null)
        {
            var filteredTodos = toDos.AsQueryable();

            if (priority.HasValue)
            {
                filteredTodos = filteredTodos.Where(toDo => toDo.Priority == priority);
            }

            if (isCompleted.HasValue)
            {
                filteredTodos = filteredTodos.Where(toDo => toDo.IsCompleted == isCompleted);
            }

            filteredTodos = filteredTodos.Skip(skip).Take(take);

            return filteredTodos.ToList(); 
        }

        public void UpdateIsCompleted(int id)
        {
            var toDo = toDos.FirstOrDefault(toDo => toDo.Id == id)!;
            toDo.IsCompleted = !toDo.IsCompleted;
        }
    }
}
