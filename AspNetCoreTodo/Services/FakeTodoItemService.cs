using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
	public class FakeTodoItemService : ITodoItemService
	{
		public Task<TodoItem[]> GetIncompleteItemsAsync()
		{
			var item1 = new TodoItem { 
				Title = "Todo 01", 
				DueAt = DateTimeOffset.Now.AddDays(1) 
			};

			var item2 = new TodoItem { 
				Title = "Todo 02", 
				DueAt = DateTimeOffset.Now.AddDays(1) 
			};
			
			var item3 = new TodoItem { 
				Title = "Todo 03", 
				DueAt = DateTimeOffset.Now.AddDays(1) 
			};
			
			var item4 = new TodoItem { 
				Title = "Todo 04", 
				DueAt = DateTimeOffset.Now.AddDays(1) 
			};
			
			var item5 = new TodoItem { 
				Title = "Todo 05", 
				DueAt = DateTimeOffset.Now.AddDays(1) 
			};

			return Task.FromResult( new[] { item1, item2 } );
		}
	}
}