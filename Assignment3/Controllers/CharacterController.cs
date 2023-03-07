using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3.DTO.Characters;
using Assignment3.Controllers.Services;
using Assignment3.Models;



namespace Assignment3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("api/character")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetAll()
        {
            var character = await _characterService.GetAllCharactersAsync();
            var characterDtos = character.Select(c => new CharacterDto(c));
            return Ok(characterDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetById(string id)
        {

            var character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            var characterDto = new CharacterDto(character);
            return Ok(characterDto);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDto>> Create(CharacterCreateDto createDto)
        {
            var character = new Character(createDto.FullName, createDto.Alias, createDto.Gender, createDto.PictureUrl);
            await _characterService.AddCharacterAsync(character);
            var characterDto = new CharacterDto(character);
            return CreatedAtAction(nameof(GetById), new { id = character.Id }, characterDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CharacterDto>> Update(string id, CharacterUpdateDto updateDto)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            character.Update(updateDto.FullName, updateDto.Alias, updateDto.Gender, updateDto.PictureUrl);
            await _characterService.UpdateCharacterAsync(character);
            var characterDto = new CharacterDto(character);
            return Ok(characterDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _characterService.DeleteCharacterAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/characters")]
        public async Task<ActionResult<CharacterDto>> UpdateCharacters(string id, UpdateCharactersDto updateDto)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            var characters = await _characterService.GetCharactersByIdsAsync(updateDto.CharacterIds);
            character.UpdateCharacters(characters);
            await _characterService.UpdateCharacterAsync(character);
            var characterDto = new CharacterDto(character);
            return Ok(characterDto);
        }
    }
}
