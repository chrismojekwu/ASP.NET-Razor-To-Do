using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public List<ToDo> Todos = new();
    [BindProperty]
    public ToDo NewTodo { get; set; } = new();
    public void OnGet()
    {
        Todos = TodoService.GetAll();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        TodoService.Add(NewTodo);
        return RedirectToAction("Get");
    }

    public IActionResult OnPostDelete(int id)
    {
        TodoService.Delete(id);
        return RedirectToAction("Get");
    }
}
