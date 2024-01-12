namespace TodoAPP.Models.Response;

public class GetTodoItemByIdResponse
{
    public TodoItemInfo Data { get; set; }
}
public class GetAllTodoItemResponse
{
    public List<TodoItemInfo> Data { get; set; }
}
public class AddTodoItemResponse
{
    public BaseResponse Data { get; set; }
}

public class UpdateTodoItemResponse
{
    public BaseResponse Data { get; set; }
}

public class DeleteTodoItemResponse
{
    public BaseResponse Data { get; set; }
}
public class TodoItemInfo
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Desciption { get; set; }
    public int Status { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string ModifiedBy { get; set; }
}

public class BaseResponse
{
    public bool IsSucess { get; set;}
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}