using First_Sample_Project.Models;

namespace First_Sample_Project.FormsRepository
{
    public interface ICountry
    {
        int AddCountries(Country countrymodel);

        void UpdateCountries(int id, Country countrymodel);

        int DeleteCountries(int id);
    }
}
