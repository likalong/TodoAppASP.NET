
using TodoAPP.Models.Response;
using TodoAPP.Models.Request;

namespace TodoAPP.Services.Interfaces;

public interface ITodosService
{
    GetAllTodoItemResponse GetAllTodoItemService(IConfiguration config );
    GetTodoItemByIdResponse GetTodoItemByIdService(IConfiguration config, int Id);
    AddTodoItemResponse AddTodoItemService(IConfiguration config, AddTodoItemRequest request);
    UpdateTodoItemResponse UpdateTodoItemService(IConfiguration config, UpdateTodoItemRequest request);
    DeleteTodoItemResponse DeleteTodoItemService(IConfiguration config, int Id);

}