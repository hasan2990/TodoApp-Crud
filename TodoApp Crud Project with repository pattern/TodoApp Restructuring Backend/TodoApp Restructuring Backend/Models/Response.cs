namespace TodoApp_Restructuring_Backend.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public Todo? Todo { get; set; }
        public List<Todo>? listtodo { get; set; }
    }
}
