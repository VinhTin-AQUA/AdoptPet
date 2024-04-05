
namespace AdoptPet.Domain.Common.Interfaces
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
