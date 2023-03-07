using System.Reflection;
using Assignment3.Models;

namespace Assignment3.DTO.Franchises
{
    public class FranchiseDto
    {
        public FranchiseDto(Franchise franchise)
        {
            Id = franchise.Id.ToString();
            Name = franchise.Name;
            Description = franchise.Description;
        }

     

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Models.Franchise Franchise { get; }
    }
}
