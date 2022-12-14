namespace StudentProject.Models
{
    public class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
