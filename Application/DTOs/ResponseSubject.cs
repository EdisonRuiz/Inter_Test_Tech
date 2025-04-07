namespace Application.DTOs
{
    public class ResponseSubject
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Teacher { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
        public IList<string> Classmates { get; set; } = new List<string>();
    }
}
