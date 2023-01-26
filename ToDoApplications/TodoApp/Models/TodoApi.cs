

namespace ToDoApp.Models
{
    public class TodoApi
    {

        public List<TodoItem> GetTodoItems()
        {
            List<TodoItem> Todos;
            //call the API located at https://localhost:7244/ to get the list of TodoItems using entity framework and return the list of TodoItems
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7244/api/TodoItems");
                //HTTP GET
                var responseTask = client.GetAsync("TodoItems");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //for each todo item in the list of todo items, add it to the list of todo items
                    var readTask = result.Content.ReadFromJsonAsync<List<TodoItem>>();
                    readTask.Wait();
                    if (readTask.Result != null)
                    {
                        Todos = readTask.Result;
                    }
                    else
                    {
                        Todos = new List<TodoItem>();
                    }
                }
                else //web api sent error response 
                {
                    //log response status here..
                    
                    Todos = Enumerable.Empty<TodoItem>().ToList();
                 
                }
            }

            return Todos;
        }
           

    }
}
