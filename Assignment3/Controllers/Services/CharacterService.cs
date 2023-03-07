using Assignment3.Controllers.Services;
using Db;
using Assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Controllers.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly MyCustomDbContext _dbContext;

        public CharacterService (MyCustomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCharacterAsync(Character character)
        {
            await _dbContext.Characters.AddAsync(character);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            return await _dbContext.Characters.ToListAsync();
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await _dbContext.Characters.FindAsync(id);
        }

        public async Task UpdateCharacterAsync(Character character)
        {
            _dbContext.Characters.Update(character);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteCharacterAsync(int id)
        {
            var character = await GetCharacterByIdAsync(id);
            if (character != null)
            {
                _dbContext.Characters.Remove(character);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
