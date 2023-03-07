using Microsoft.EntityFrameworkCore;
using Assignment3.Models;



namespace Assignment3.Controllers.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetAllCharactersAsync();
        Task<Character> GetCharacterByIdAsync(int id);
        Task AddCharacterAsync(Character character);
        Task UpdateCharacterAsync(Character character);
        Task DeleteCharacterAsync(int id);

    }
}
