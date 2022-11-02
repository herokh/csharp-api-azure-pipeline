using KhWebApi.WebApi.Models;
using KhWebApi.WebApi.Repositories.Interfaces;

namespace KhWebApi.WebApi.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private ModelContext _context;
        public IUserRepository UserRepository { get; private set; }


        public UnitOfWork(ModelContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
