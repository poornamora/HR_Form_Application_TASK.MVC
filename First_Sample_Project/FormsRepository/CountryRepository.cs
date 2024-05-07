using First_Sample_Project.Models;
using System;
using System.Linq;

namespace First_Sample_Project.FormsRepository
{
    public class CountryRepository : ICountry
    {
        private readonly ApplicationUser _context;

        public CountryRepository(ApplicationUser context)
        {
            _context = context;
        }
        public int AddCountries(Country countrymodel)
        {
            try
            {
                Country country = new Country();

                country.CountryName = countrymodel.CountryName;

                _context.countries.Add(country);

                var issuccess = _context.SaveChanges();
                return issuccess==1? 1:0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateCountries(int id, Country countrymodel)
        {
            try
            {
                if (id!=0 && countrymodel!=null)
                {

                    if (countrymodel.IsDeleted==true)
                    {
                        var existeddetails = _context.countries.FirstOrDefault(i => i.CountryId== id);

                        if (existeddetails!=null)
                        {
                            existeddetails.CountryName = countrymodel.CountryName;                           
                            _context.SaveChanges();
                        }
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        #region Delete Users
        public int DeleteCountries(int id)
        {
            try
            {
                if (id>0)
                {
                    var countriesdetails = _context.countries.FirstOrDefault(i => i.CountryId==id);
                    if (countriesdetails!=null)
                    {
                        _context.countries.Remove(countriesdetails);
                        var rowaffected = _context.SaveChanges();
                    }
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
