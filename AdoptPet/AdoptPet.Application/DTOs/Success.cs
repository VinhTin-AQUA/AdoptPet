
namespace AdoptPet.Application.DTOs
{
    public class Success<T>
    {
        public bool Status { get; set; }
        public List<string> Messages { get; set; } = [];
        public T? Data { get; set; }
    }
}
