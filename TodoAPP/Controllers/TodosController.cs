using Microsoft.AspNetCore.Mvc;
using TodoAPP.Models.Response;
using TodoAPP.Models.Request;
using TodoAPP.Services.Interfaces;

namespace TodoAPP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController: Controller
{
    
    private readonly ITodosService _todoService;
    private readonly IConfiguration _configuration;

    public TodosController(ITodosService todoService, IConfiguration _config)
    {
        _configuration = _config;
        _todoService = todoService;
    }

    [HttpPost("GetAllTodoList")]
    public GetAllTodoItemResponse GetAllTodoList()
    {
        return _todoService.GetAllTodoItemService(_configuration);
    }
    [HttpPost("GetTodoItemById/{Id}")]
    public GetTodoItemByIdResponse GetTodoItemById(int Id)
    {
        return _todoService.GetTodoItemByIdService( _configuration, Id);
    }
    [HttpPost("AddTodoItem")]
    public AddTodoItemResponse AddTodoItem(AddTodoItemRequest request)
    {
        return _todoService.AddTodoItemService( _configuration, request);
    }
    [HttpPut("UpdateTodoItem")]
    public UpdateTodoItemResponse UpdateTodoItem(UpdateTodoItemRequest request)
    {
        return _todoService.UpdateTodoItemService( _configuration, request);
    }
    [HttpDelete("DeleteTodoItemById/{Id}")]
    public DeleteTodoItemResponse DeleteTodoItemById(int Id)
    {
        return _todoService.DeleteTodoItemService( _configuration, Id);
    }
}