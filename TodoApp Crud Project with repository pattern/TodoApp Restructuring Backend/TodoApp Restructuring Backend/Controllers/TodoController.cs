
using Microsoft.AspNetCore.Mvc;

using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Services.Implementations;
using TodoApp_Restructuring_Backend.Services.Interfaces;

namespace TodoApp_Restructuring_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGetAllTodoService _getAllTodoService;
        private readonly IAddTodoService _addTodoService;
        private readonly IDeleteTodoService _deleteTodoService;
        private readonly IUpdateTodoService _updateTodoService;
        private readonly IGetByIdTodoService _getByIdTodoService;
        public TodoController(IConfiguration configuration,IGetAllTodoService getAllTodoService , IAddTodoService addTodoService,IDeleteTodoService deleteTodoService,IUpdateTodoService updateTodoService,IGetByIdTodoService getByIdTodoService)
        {
            _configuration = configuration;
            _getAllTodoService = getAllTodoService;
            _addTodoService = addTodoService;
            _deleteTodoService = deleteTodoService;
            _updateTodoService = updateTodoService;
            _getByIdTodoService = getByIdTodoService;
        }

        [HttpGet]
        [Route("GetAllTodos")]
        public Response GetAllTodos()
        {
            return _getAllTodoService.GetAllTodos();
          
        }

        [HttpGet]
        [Route("GetAllTodoById/{id}")]
        public Response GetAllTodoById(int id)
        {
            return _getByIdTodoService.GetByIdTodos(id);

        }

        [HttpPost]
        [Route("AddTodo")]
        public Response AddTodos(Todo todo)
        {
            return _addTodoService.AddTodos(todo);
        }

        [HttpDelete]
        [Route("DeleteTodo/{id}")]
        public Response DeleteTodo(int id)
        {
            return _deleteTodoService.DeleteTodos(id);
        }

        [HttpPut]
        [Route("UpdateTodo")]
        public Response UpdateTodos(Todo todo)
        {
            return _updateTodoService.UpdateTodos(todo);
        }


    }
}
