using Todo.Models;

namespace TodoApp.Models
{
	public class Todoapi
	{
		private string httpConnect = "https://localhost:7244/api/";

		public async Task<List<TodoItemDTO>>  GetTodoItems()
		{
			List<TodoItemDTO> Todos;
			//call the API located at https://localhost:7244/ to get the list of TodoItems using entity framework and return the list of TodoItems
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP GET
				var responseTask = await client.GetAsync("TodoItems");
				
				if (responseTask.IsSuccessStatusCode)
				{
					//for each todo item in the list of todo items, add it to the list of todo items
					var readTask = responseTask.Content.ReadFromJsonAsync<List<TodoItemDTO>>();
					readTask.Wait();
					if (readTask.Result != null)
					{
						Todos = readTask.Result;
					}
					else
					{
						Todos = new List<TodoItemDTO>();
					}
				}
				else //web api sent error response 
				{
					//log response status here..

					Todos = Enumerable.Empty<TodoItemDTO>().ToList();

				}
			}

			return Todos;
		}

		//post new item to the API
		public async Task<bool> PostTodoItem(TodoItemDTO todoItem)
		{
			TodoNoID todoNoID = new TodoNoID();
			todoNoID.Name = todoItem.Name;
			todoNoID.IsComplete = todoItem.IsComplete;
			
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP POST
				var postTask = await client.PostAsJsonAsync<TodoNoID>("TodoItems", todoNoID);

				if (postTask.IsSuccessStatusCode)
				{
					return true;
				}
				else
				{
					return false;
				}

			}
		}
		//get a todoitem with a specific id
		public async Task<TodoItemDTO> GetTodoItem(long? id)
		{
			if (id != null)
			{
				TodoItemDTO todoItem = new TodoItemDTO();
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(httpConnect);
					//HTTP GET
					var responseTask = await client.GetAsync("TodoItems/" + id);
				
				
					if (responseTask.IsSuccessStatusCode)
					{
						var readTask = responseTask.Content.ReadFromJsonAsync<TodoItemDTO>();

						if (readTask != null)
						{
							todoItem = readTask;
						}
						else
						{
							todoItem = new TodoItemDTO();
						}
					}
					else //web api sent error response 
					{
						//log response status here..

						todoItem = new TodoItemDTO();

					}
				}

				return todoItem;
			}
			else
			{
                return new TodoItemDTO();
            }

		}


		//put edit post by id
		public async Task<bool> PutTodoItem(long id, TodoItemDTO todoItem)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP PUT
				var putTask = await client.PutAsJsonAsync<TodoItemDTO>("TodoItems/" + id, todoItem);
				
				if (putTask.IsSuccessStatusCode)
				{
					return true;
				}
				else
				{
					return false;
				}
				
			}
		}



		// delete post with id
		//you should be able to await this method
		public async Task<bool> DeleteTodoItem(long id)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP DELETE
				var deleteTask = await client.DeleteAsync("TodoItems/" + id);
				
				if (deleteTask.IsSuccessStatusCode)
				{
					return true;
				}
				else
				{
					return false;
				}

			}
		}


		public async Task<bool> CompleteChangestate(int id)
		{
			TodoItemDTO todoItem = new TodoItemDTO();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP GET
				var responseTask = await client.GetAsync("TodoItems/" + id);
				
				if (responseTask.IsSuccessStatusCode)
				{
					var readTask = await responseTask.Content.ReadFromJsonAsync<TodoItemDTO>();
					if (readTask != null)
					{
						todoItem = readTask;
					}
					else
					{
						todoItem = new TodoItemDTO();
					}
				}
				else //web api sent error response 
				{
					//log response status here..

					todoItem = new TodoItemDTO();

				}
			}
			if (todoItem.IsComplete == false) todoItem.IsComplete = true;
			else todoItem.IsComplete = false;


			todoItem.IsComplete = true;
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP PUT
				var putTask = client.PutAsJsonAsync<TodoItemDTO>("TodoItems/" + id, todoItem);
				putTask.Wait();

				var result = putTask.Result;
				if (result.IsSuccessStatusCode)
				{
					return true;
				}
				else
				{
					return false;
				}

			}
		}
	}
}
