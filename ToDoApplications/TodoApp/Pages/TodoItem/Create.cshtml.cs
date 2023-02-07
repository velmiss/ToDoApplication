using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Todo.Models;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages.TodoItem
{
	public class CreateModel : PageModel
	{



		public IActionResult OnGet()
		{
            //if not logged in, redirect to login page
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Identity/Account/Login");
            }
            return Page();
		}

		public TodoItemDTO TodoItemDTO { get; set; } = new TodoItemDTO();
		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

		public async Task<IActionResult> OnPost(TodoItemDTO TodoItemDTO)
		{
            //if not logged in, redirect to login page
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Identity/Account/Login");
            }
            if (!ModelState.IsValid)
			{
				return Page();
			}
			else
			{
				var todoApi = new Todoapi();
				 bool yes = await  todoApi.PostTodoItem(TodoItemDTO);
	
				if (yes)
					{
						return RedirectToPage("./Index");
					}
				else
					{
						return Page();
					}
			}

		}

	}
}

