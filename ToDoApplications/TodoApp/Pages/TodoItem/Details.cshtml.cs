﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
using TodoApp.Data;

namespace TodoApp.Pages.TodoItem
{
    public class DetailsModel : PageModel
    {
        
        public DetailsModel()
        {
        }

      public TodoItemDTO TodoItemDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			return Page();
        }
    }
}