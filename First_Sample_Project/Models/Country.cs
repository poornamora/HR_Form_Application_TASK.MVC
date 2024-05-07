using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Sample_Project.Models
{
    public class Country
    {
        
        public int CountryId { get; set; }

        public string? CountryName { get; set; }
        

        public ICollection<City>? Cities { get; set; }

        public bool IsDeleted { get; set; }

    }
}
