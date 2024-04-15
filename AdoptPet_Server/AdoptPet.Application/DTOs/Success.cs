
namespace AdoptPet.Application.DTOs
{
    public class Success<T>
    {
        public bool Status { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<string> Messages { get; set; } = [];
        public T? Data { get; set; }
    }
}
