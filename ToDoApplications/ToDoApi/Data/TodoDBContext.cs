using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Data
{
	public class TodoDBContext : DbContext
	{
		public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
		{
		}
		
		public DbSet<TodoItem> TodoItems { get; set; }
	}
}
