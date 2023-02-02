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

namespace TodoApp.Pages.TodoItem
{
    public class EditModel : PageModel
    {
        

        public EditModel()
        {
        }

        [BindProperty]
        public TodoItemDTO TodoItemDTO { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
			//not yet implemented
			return Page();
		}

		

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
        

            return RedirectToPage("./Index");
        }


    }
}
