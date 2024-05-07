using First_Sample_Project.Models;
using First_Sample_Project.Models.DTO;
using System;
using System.Collections.Generic;

namespace First_Sample_Project.FormsRepository
{
    public interface IHRFormsRepository
    {
        IEnumerable<HRFormModel> GetFormList();

        int AddDetails(HRFormModel FormModel);

        int DeleteDetails(int id);

        void UpdateFormDetails(int id, HRFormModel formdetails);

        HRFormModel GetDetailsbyId(int? id);
        List<HRFormDisplayModel> SP_FormList();

        int SP_AddFormDetails(string firstName, string lastName, string status, string department, string phone, DateTime dateOfIncident, TimeSpan timeOfIncident, string incidentLocation, string witnessIfAvailable, string specifyIncidentDetails, string suggestions, int countryId, int cityId, bool isDeleted);

    }
}
