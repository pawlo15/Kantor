namespace Kantor.Shared.Abstraction
{
    public interface IEntity<T> where T : struct
    {
        public T Id { get; set; }
    }
}
