
namespace Domain.Abstractions
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }

        ///// <summary>
        ///// True if domain entity has an identity
        ///// </summary>
        ///// <returns></returns>
        //public bool IsTransient()
        //{
        //    return Id.Equals(default(T));
        //}
    }
}