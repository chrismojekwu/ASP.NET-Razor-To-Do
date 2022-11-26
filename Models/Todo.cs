using System.ComponentModel.DataAnnotations;
namespace ToDoList.Models;

public class ToDo
{
    [Required]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Details { get; set; }
    public string? Priority { get; set; }
    public string date_created { get; set; } = DateTime.Now.ToString();
}

public enum Priority { High, Medium, Low }