using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo.Models;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages.TodoItem
{
    public class IndexModel : PageModel
    {
		public IList<TodoItemDTO> TodoItemDTOs { get;set; } = default!;

		public async Task OnGetAsync()
		{
            //if not logged in, redirect to login page
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Identity/Account/Login");
            }

            Todoapi todoapi = new Todoapi();
			TodoItemDTOs = await todoapi.GetTodoItems();
		}


		//when page loads for the first time, get the list of todo items from the API
		public async Task<IActionResult> OnPost()
		{
			//make a new todoapi
			var todoApi = new Todoapi();
			//get the list of todo items from the API
			TodoItemDTOs = await todoApi.GetTodoItems();
			//return the page
			return Page();
		}
	}
}
