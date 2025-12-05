using DesignliTest.Core.Domain;
using DesignliTest.Core.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace DesignliTest.Infrastructure.Repository
{
    /// <summary>
    /// UserApp repository implementation using EF InMemory.
    /// </summary>
    /// <inheritdoc/>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <inheritdoc />
        public async Task<UserApp?> GetByCredentialsAsync(string username, string password)
        {
            return await _dbContext.UserApp
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<UserApp>> GetAllAsync()
        {
            var list = await _dbContext.UserApp
                                       .AsNoTracking()
                                       .OrderBy(u => u.Username)
                                       .ToListAsync();

            return list;
        }
    }
}