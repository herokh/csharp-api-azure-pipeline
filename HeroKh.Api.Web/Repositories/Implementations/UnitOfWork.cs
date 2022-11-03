using KhWebApi.WebApi.Models;
using KhWebApi.WebApi.Repositories.Interfaces;

namespace KhWebApi.WebApi.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private ModelContext _context;
        public IUserRepository UserRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IProductCategoryRepository ProductCategoryRepository { get; private set; }

        public UnitOfWork(ModelContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            ProductRepository = new ProductRepository(_context);
            ProductCategoryRepository = new ProductCategoryRepository(_context);
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
