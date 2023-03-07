using Microsoft.EntityFrameworkCore;

using Assignment3.Models;
namespace Assignment3.Controllers.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MyDbContext _dbContext;

        public FranchiseService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
        {
            return await _dbContext.Franchises.ToListAsync();
        }

        public async Task<Franchise> GetFranchiseByIdAsync(int id)
        {
            return await _dbContext.Franchises.FindAsync(id);
        }

        public async Task AddFranchiseAsync(Franchise franchise)
        {
            await _dbContext.Franchises.AddAsync(franchise);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateFranchiseAsync(Franchise franchise)
        {
            _dbContext.Franchises.Update(franchise);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFranchiseAsync(int id)
        {
            var franchise = await GetFranchiseByIdAsync(id);
            if (franchise != null)
            {
                _dbContext.Franchises.Remove(franchise);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}