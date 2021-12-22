namespace Application.Interfaces.Repositoires
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call save change from db context
        /// </summary>
        Task CommitAsync();
    }
}
