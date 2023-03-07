using System.Reflection;

namespace Assignment3.DTO.Characters
{
    public class CharacterCreateDto
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; }
    }

}