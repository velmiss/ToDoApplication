using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo.Models;
using TodoApp.Data;

namespace TodoApp.Pages.TodoItem
{
    public class IndexModel : PageModel
    {

        public IndexModel()
        {
		    TodoItemDTOs = new List<TodoItemDTO>();
	
        }

        public IList<TodoItemDTO> TodoItemDTOs { get;set; } = default!;

        public async Task OnGetAsync()
        {

		}
	}

}
