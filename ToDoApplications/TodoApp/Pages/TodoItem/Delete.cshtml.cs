using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages.TodoItem
{
    public class DeleteModel : PageModel
    {

		private readonly Todoapi todoApi = new();

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

            TodoItemDTO = await todoApi.GetTodoItem(id);

            if (TodoItemDTO == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(long? id)
        {
            //If user is admin
            if (User.IsInRole("admin"))
            {
                if (id == null)
                {
                    return Page();
                }
                else
                {
                    await todoApi.DeleteTodoItem(id.Value);
                }
                return RedirectToPage("./Index");
            }
            else return RedirectToPage("./Login");
        }
		
    }
}
