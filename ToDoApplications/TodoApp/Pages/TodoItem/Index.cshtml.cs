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
        private HttpClient mClient;
        public IndexModel()
        {
			mClient = new HttpClient();
            mClient.BaseAddress = new Uri("https://localhost:7244");
            mClient.DefaultRequestHeaders.Add("Accept", "application/json");
            mClient.DefaultRequestHeaders.Add("User-Agent", "TodoApp");
		

		    TodoItemDTOs = new List<TodoItemDTO>();
	
        }

        public IList<TodoItemDTO> TodoItemDTOs { get;set; } = default!;
		
        public async Task OnGetAsync()
        {
			var response= await mClient.GetAsync("/api/TodoItem");
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				//var json = await response.Content.ReadAsStringAsync();
				//TodoItemDTOs = JsonConvert.DeserializeObject<List<TodoItemDTO>>(json);
			}
			throw new HttpRequestException("Error getting TodoItemDTOs");
		}
	}
}
