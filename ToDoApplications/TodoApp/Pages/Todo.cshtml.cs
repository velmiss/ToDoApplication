using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoApp.Models;

namespace ToDoApp.Pages
{
    public class TodopubModel : PageModel
    {
        public List<TodoItem> TodoItemspub { get; set; } = new List<TodoItem>();
        public void OnGet()
        {
            TodoApi api = new TodoApi();
            TodoItemspub = api.GetTodoItems();
        }
    
    }
}
