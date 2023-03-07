using System.Reflection;
using Assignment3.Models;

namespace Assignment3.DTO.Characters
{
    public class CharacterDto
    {
        public CharacterDto(Character character)
        {
            Id = character.Id;
            FullName = character.FullName;
            Alias = character.Alias;
            Gender = character.Gender;
            PictureUrl = character.PictureUrl;
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; }
    }
}
