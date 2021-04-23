using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;

namespace AspNetCoreTodo.Controllers
{
	public class TodoController : Controller
	{
        private readonly ILogger<TodoController> _logger;

        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
			var items = await _todoItemService.GetIncompleteItemsAsync();

			var model = new TodoViewModel()
            {
                Items = items
            };

			return View(model);
        }
	}
}