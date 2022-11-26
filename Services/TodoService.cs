using ToDoList.Models;
namespace ToDoList.Services;

public static class TodoService
{
    static List<ToDo> Todos { get;}

    static int nextId = 1;
    static TodoService()
    {
        Todos = new List<ToDo>();
    }

    public static List<ToDo> GetAll() => Todos;
    
    public static ToDo? Get(int id) => Todos.FirstOrDefault(item => item.Id == id);

    public static void Add(ToDo todo)
    {
        todo.Id = nextId++;
        Todos.Add(todo);
    }

    public static void Delete(int id)
    {
        var todo = Get(id);
        if (todo is null)
            return;

        Todos.Remove(todo);
    }

    public static void Update(ToDo todo)
    {
        var index = Todos.FindIndex(item => item.Id == todo.Id);
        if (index == -1)
            return;

        Todos[index] = todo;
    }
}