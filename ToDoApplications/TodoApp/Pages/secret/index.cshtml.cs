using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoApp.Models;

namespace ToDoApp.Pages.secret

{
    public class IndexModel : PageModel
    {
        public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
        public void OnGet()
        {
            TodoApi api = new TodoApi();
            TodoItems = api.GetTodoItems();
        }
    
    }
}
