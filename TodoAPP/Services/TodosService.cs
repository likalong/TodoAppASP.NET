using TodoAPP.Services.Interfaces;
using TodoAPP.Models.Response;
using TodoAPP.Models.Request;
using Dapper;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace TodoAPP.Services;
public class TodosService: ITodosService
{
    private IConfiguration _configuration;
    // public TodosService(IConfiguration _config) {
    //     _configuration = _config;
    // }
    public GetAllTodoItemResponse GetAllTodoItemService(IConfiguration config)
    {
        _configuration = config;
        var response = GetAllTodoListDB();
        Console.WriteLine("response = ", response);
        return response.Result;
    }
    public async Task<GetAllTodoItemResponse> GetAllTodoListDB()
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        var response = await connection.QueryAsync<TodoItemInfo>("select * from TodoList");
        
        var json = JsonConvert.SerializeObject(response);
        Console.WriteLine("json 1111 = ");
        Console.WriteLine(json);
        System.Diagnostics.Debug.WriteLine(json[0]);
        return new GetAllTodoItemResponse()
        {
            Data = response.ToList()
        };
    }
    
    public GetTodoItemByIdResponse GetTodoItemByIdService(IConfiguration config, int Id)
    {
        _configuration = config;
        Console.WriteLine("request = ", Id);
        var response = GetTodoItemByIdDB(Id);
        Console.WriteLine("response = ", response);
        return response.Result;
    }
    public async Task<GetTodoItemByIdResponse> GetTodoItemByIdDB(int Id)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        // var Id = request.TodoId;
        var response = await connection.QueryFirstAsync<TodoItemInfo>("SELECT * FROM TodoList WHERE Id = @Id", new {Id});
        var json = JsonConvert.SerializeObject(response);
        Console.WriteLine("get by id 1111 = ");
        Console.WriteLine(json);
        return new GetTodoItemByIdResponse()
        {
            Data = response
        };
    }
    public AddTodoItemResponse AddTodoItemService(IConfiguration config, AddTodoItemRequest request)
    {
        _configuration = config;
        Console.WriteLine("request = ", request);
        var response = AddTodoItemDB(request);
        Console.WriteLine("response = ", response);
        return response.Result;
    }
    public async Task<AddTodoItemResponse> AddTodoItemDB(AddTodoItemRequest request)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        var Body = request;
        Console.WriteLine("add Body 1111 = ");
        Console.WriteLine(Body);
        var response = await connection.ExecuteAsync("INSERT INTO TodoList (Title, Description, Status, CreatedOn,CreatedBy, ModifiedOn, ModifiedBy) values (@Title, @Description, @Status, GETDATE(), 'Lia', GETDATE(), 'Lia')", Body);
        // if (response > 0)
        Console.WriteLine("add 1111 = ");
        Console.WriteLine(response);
        return new AddTodoItemResponse()
        {
            Data = new BaseResponse()
            {
                IsSucess = true,
                ErrorCode = 0,
                ErrorMessage = ""
            }
        };
    }
    public UpdateTodoItemResponse UpdateTodoItemService(IConfiguration config, UpdateTodoItemRequest request)
    {
        _configuration = config;
        var response = UpdateTodoItemDB(request);
        return response.Result;
    }
    public async Task<UpdateTodoItemResponse> UpdateTodoItemDB(UpdateTodoItemRequest request)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        var Body = request;
        string sql = "UPDATE TodoList SET Title = @Title, Description = @Description, Status = @Status, CreatedOn = GETDATE(), CreatedBy = 'Lia', ModifiedOn = GETDATE(), ModifiedBy = 'Lia' WHERE Id = @Id";
        var response = await connection.ExecuteAsync(sql, Body);
        return new UpdateTodoItemResponse()
        {
            Data = new BaseResponse()
            {
                IsSucess = true,
                ErrorCode = 0,
                ErrorMessage = ""
            }
        };
    }
    public DeleteTodoItemResponse DeleteTodoItemService(IConfiguration config,  int Id)
    {
        _configuration = config;
        var response = DeleteTodoItemByIdDB(Id);
        return response.Result;
    }
    public async Task<DeleteTodoItemResponse> DeleteTodoItemByIdDB(int Id)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        string sql = "DELETE FROM TodoList WHERE Id = @Id";
        var response = await connection.ExecuteAsync(sql, new {Id});
        return new DeleteTodoItemResponse()
        {
            Data = new BaseResponse()
            {
                IsSucess = true,
                ErrorCode = 0,
                ErrorMessage = ""
            }
        };
    }
}