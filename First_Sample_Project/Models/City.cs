using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Sample_Project.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string? CityName { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public bool IsDeleted { get; set; } = true;
    }
}
