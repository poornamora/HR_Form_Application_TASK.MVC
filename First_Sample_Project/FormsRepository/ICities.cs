using First_Sample_Project.Models;

namespace First_Sample_Project.FormsRepository
{
    public interface ICities
    {
        int AddCities(City city);

        void UpdateCountries(int id, City citymodel);

        int DeleteCity(int id);
    }
}
