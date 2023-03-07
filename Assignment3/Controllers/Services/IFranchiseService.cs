using Assignment3.Models;
namespace Assignment3.Controllers.Services
{
    public interface IFranchiseService
    {
        Task<IEnumerable<Franchise>> GetAllFranchisesAsync();
        Task<Franchise> GetFranchiseByIdAsync(int id);
        Task AddFranchiseAsync(Franchise franchise);
        Task UpdateFranchiseAsync(Franchise franchise);
        Task DeleteFranchiseAsync(int id);

    }
}
