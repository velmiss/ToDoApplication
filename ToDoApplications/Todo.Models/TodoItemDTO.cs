using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
	public class TodoItemDTO
	{
		public long Id { get; set; }
		[Required]
		public string Name { get; set; }
		public bool IsComplete { get; set; }

        public static implicit operator TodoItemDTO(Task<TodoItemDTO> v)
        {
            TodoItemDTO todoItem = new TodoItemDTO();
            todoItem.Name = v.Result.Name;
            todoItem.IsComplete = v.Result.IsComplete;
            todoItem.Id = v.Result.Id;
            return todoItem;
        }
        /*
public static implicit operator TodoItemDTO(Task<TodoItemDTO> v)
{

}*/
    }
}
