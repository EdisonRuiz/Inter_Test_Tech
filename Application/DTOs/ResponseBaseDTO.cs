namespace Application.DTOs
{
    public class ResponseBaseDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

    }
}
