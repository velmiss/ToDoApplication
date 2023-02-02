/*using Todo.Models;

namespace TodoApp.Models
{
	public class Todoapi
	{
		private string httpConnect = "https://localhost:7244/api/";

		public List<TodoItemDTO> GetTodoItems()
		{
			List<TodoItemDTO> Todos;
			//call the API located at https://localhost:7244/ to get the list of TodoItems using entity framework and return the list of TodoItems
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP GET
				var responseTask = client.GetAsync("TodoItems");
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					//for each todo item in the list of todo items, add it to the list of todo items
					var readTask = result.Content.ReadFromJsonAsync<List<TodoItemDTO>>();
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
		public bool PostTodoItem(TodoItemDTO todoItem)
		{
			todoItem.Id = null;
			TodoNoID todoNoID = new TodoNoID();
			todoNoID.Name = todoItem.Name;
			todoNoID.IsComplete = todoItem.IsComplete;

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP POST
				var postTask = client.PostAsJsonAsync<TodoNoID>("TodoItems", todoNoID);
				postTask.Wait();

				var result = postTask.Result;
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
		//get a todoitem with a specific id
		public TodoItem GetTodoItem(int id)
		{
			TodoItem todoItem = new TodoItem();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP GET
				var responseTask = client.GetAsync("TodoItems/" + id);
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadFromJsonAsync<TodoItem>();
					readTask.Wait();
					if (readTask.Result != null)
					{
						todoItem = readTask.Result;
					}
					else
					{
						todoItem = new TodoItem();
					}
				}
				else //web api sent error response 
				{
					//log response status here..

					todoItem = new TodoItem();

				}
			}

			return todoItem;
		}


		//put edit post by id
		public bool PutTodoItem(int id, TodoItem todoItem)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP PUT
				var putTask = client.PutAsJsonAsync<TodoItem>("TodoItems/" + id, todoItem);
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



		// delete post with id
		public bool DeleteTodoItem(int id)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP DELETE
				var deleteTask = client.DeleteAsync("TodoItems/" + id);
				deleteTask.Wait();

				var result = deleteTask.Result;
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


		public bool CompleteChangestate(int id)
		{
			TodoItem todoItem = new TodoItem();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP GET
				var responseTask = client.GetAsync("TodoItems/" + id);
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadFromJsonAsync<TodoItem>();
					readTask.Wait();
					if (readTask.Result != null)
					{
						todoItem = readTask.Result;
					}
					else
					{
						todoItem = new TodoItem();
					}
				}
				else //web api sent error response 
				{
					//log response status here..

					todoItem = new TodoItem();

				}
			}
			if (todoItem.IsComplete == false) todoItem.IsComplete = true;
			else todoItem.IsComplete = false;


			todoItem.IsComplete = true;
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(httpConnect);
				//HTTP PUT
				var putTask = client.PutAsJsonAsync<TodoItem>("TodoItems/" + id, todoItem);
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
*/