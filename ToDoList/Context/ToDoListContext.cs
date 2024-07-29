using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Context;

public class ToDoListContext : DbContext
{
    public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) {}

    public DbSet<ToDo> ToDos { get; set; }
}
