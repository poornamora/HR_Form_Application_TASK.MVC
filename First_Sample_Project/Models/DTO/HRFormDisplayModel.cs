using System;
using System.Collections.Generic;

namespace First_Sample_Project.Models.DTO
{
    public class HRFormDisplayModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Status { get; set; }

        public string? Department { get; set; }

        public string? Phone { get; set; }

        public DateTime? DateofIncident { get; set; }

        public TimeSpan? TimeofIncident { get; set; }

        public string? IncidentLocation { get; set; }

        public string? Pleasespecifyincidentdetails { get; set; }

        public string? Witnessifavailable { get; set; }

        public string? Suggestions { get; set; }

        public string? AdditionalComments { get; set; }

        public bool IsDeleted { get; set; } = true;

        public string? CountryName { get; set; }

        public string? CityName { get; set; }


    }
}
