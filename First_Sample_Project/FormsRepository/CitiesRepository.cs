using First_Sample_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace First_Sample_Project.FormsRepository
{
    public class CitiesRepository : ICities
    {
        private readonly ApplicationUser _context;

        public CitiesRepository(ApplicationUser context)
        {
            _context=context;
        }
        public int AddCities(City citymodel)
        {
            try
            {
                City city = new City();
                citymodel.CityName = citymodel.CityName;
                _context.cities.Add(city);

                var issuccess = _context.SaveChanges();
                return issuccess==1 ? 1 : 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteCity(int id)
        {
            try
            {
                if (id>0)
                {
                    var citydetails = _context.cities.FirstOrDefault(i => i.CityId==id);
                    if (citydetails!=null)
                    {
                        _context.cities.Remove(citydetails);
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

        public void UpdateCountries(int id, City citymodel)
        {
            {
                if (id!=0 && citymodel!=null)
                {

                    if (citymodel.IsDeleted==true)
                    {
                        var existedcities = _context.cities.FirstOrDefault(i => i.CountryId== id);

                        if (existedcities!=null)
                        {
                            existedcities.CityName = citymodel.CityName;
                            _context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
