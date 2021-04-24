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

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if ( ! ModelState.IsValid )
            {
                return RedirectToAction("Index");
            }

            var success = await _todoItemService.AddItemAsync(newItem);

            if ( !success )
            {
                return BadRequest("Failed");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var success = await _todoItemService.MarkDoneAsync(id);

            if ( ! success )
            {
                return BadRequest("Failed.");
            }

            return RedirectToAction("Index");
        }
	}
}