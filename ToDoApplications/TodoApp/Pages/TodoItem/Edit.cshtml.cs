using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages.TodoItem
{
    public class EditModel : PageModel
    {
        

        public EditModel()
        {
        }

        [BindProperty]
        public TodoItemDTO TodoItemDTO { get; set; } = default!;
        //method to search for the todo item using the api
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            //if not logged in, redirect to login page
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Identity/Account/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            Todoapi todoApi = new Todoapi();
            TodoItemDTO = await todoApi.GetTodoItem(id);

            if (TodoItemDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return Page();
            }
            else
            {
                Todoapi todoApi = new Todoapi();
                await todoApi.PutTodoItem(id.Value, TodoItemDTO);
            }
            return RedirectToPage("./Index");
        }

    }
}
