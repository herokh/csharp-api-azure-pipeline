namespace KhWebApi.WebApi.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
