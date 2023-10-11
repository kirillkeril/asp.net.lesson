using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Todo
{
    [Key]public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}
