namespace Application.DTOs
{
    public class ResponseDTO<T> : ResponseBaseDTO
    {
        public T Data { get; set; }
    }
}
