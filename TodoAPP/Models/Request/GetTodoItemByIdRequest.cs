namespace TodoAPP.Models.Request;

public class GetTodoItemByIdRequest
{
    public string TodoId { get; set; }
}

public class AddTodoItemRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
}

public class UpdateTodoItemRequest
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
}