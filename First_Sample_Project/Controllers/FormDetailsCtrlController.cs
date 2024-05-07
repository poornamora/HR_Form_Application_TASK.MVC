using First_Sample_Project.CustomFilters;
using First_Sample_Project.FormsRepository;
using First_Sample_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using First_Sample_Project.Models.DTO;



namespace First_Sample_Project.Controllers
{
    [Route("HRForm")]
    [CustomAuthorizationFilter]
    public class FormDetailsCtrlController : Controller
    {
        private readonly IHRFormsRepository _formsRepository;
        private readonly ApplicationUser _applicationUser;
        //private readonly HRFormsRepository _hrFormsRepository;

        public FormDetailsCtrlController(ApplicationUser applicationUser, IHRFormsRepository formsRepository)
        {
            _formsRepository=formsRepository;
            _applicationUser=applicationUser;
            //_hrFormsRepository=hrFormsRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region ListPageDetails

        [Route("GetFormBookingList")]
        public IActionResult ListPage()
        {
            try
            {
                //Normal method getting from database
                //IEnumerable<HRFormModel> formlist = _formsRepository.GetFormList();

                //SP Method
                IEnumerable<HRFormDisplayModel> formlist = _formsRepository.SP_FormList();
                if (formlist!=null)
                {
                    return View(formlist);
                }
                return Problem("Users List is Empty");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion



        [Route("GetFormBooking")]
        [HttpGet]
        public IActionResult FormBooking(string mode="submit")
        {
            List<Country> countryList = _applicationUser.countries.ToList();

            ViewBag.ListCountry = countryList;
            ViewBag.Mode = mode;

            return View();
        }

        [HttpPost]

        [Route("FormBooking")]
        public void FormBooking(HRFormModel FormModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var isvalid = _formsRepository.AddDetails(FormModel);

                    //var isvalid = _hrFormsRepository.SP_AddFormDetails(FormModel);
                    if (isvalid>=1)
                    {
                        View();
                    }
                    return;
                }
                else
                {                    
                    View(ModelState);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("GetHRFormUpdate/{id:int}")]
        public IActionResult FormBookingUpdate(int id,string mode = "Update")
        {
            try
            {
                var existingdetails = _applicationUser.HRFormModels.FirstOrDefault(i => i.Id ==id);
                if (existingdetails != null)
                {
                    List<Country> countryList = _applicationUser.countries.ToList();
                    ViewBag.ListCountry = countryList;
                    ViewBag.countryselected=existingdetails.CountryId;

                    List<City> cityList = _applicationUser.cities.ToList();
                    ViewBag.ListCity = cityList;

                    var countryname = _applicationUser.countries.Where(i => i.CountryId==existingdetails.CountryId).Select(c => c.CountryName).FirstOrDefault();
                    ViewBag.countryName=countryname;

                    var cityname = _applicationUser.cities.Where(i => i.CityId==existingdetails.CityId).Select(c => c.CityName).FirstOrDefault();
                    ViewBag.CityName=cityname;

                    ViewBag.Cityselected=existingdetails.CityId;
                    ViewBag.Mode = mode;

                    return View("~/views/formdetailsctrl/formbooking.cshtml", existingdetails);
                }
                return Problem("existing details is null");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("HRFormUpdate")]
        public IActionResult FormBookingUpdate(int id, HRFormModel model)
        {
            try
            {
                if (id<=0) 
                    NotFound();


                _formsRepository.UpdateFormDetails(id, model);
                return RedirectToAction("ListPage");
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpGet]

        [Route("GetFormViewDetails/{id}")]
        public IActionResult ViewDetails(int id, string mode="view")
        {
            try
            {
                var formdetails = _formsRepository.GetDetailsbyId(id);
                if (formdetails != null)
                {
                    var countryname=_applicationUser.countries.Where(i=>i.CountryId==formdetails.CountryId).Select(c=>c.CountryName).FirstOrDefault();
                    ViewBag.countryName=countryname;

                    var cityname = _applicationUser.cities.Where(i => i.CityId==formdetails.CityId).Select(c => c.CityName).FirstOrDefault();
                    ViewBag.CityName=cityname;

                    ViewBag.Mode = mode; 
                    return View("~/views/formdetailsctrl/formbooking.cshtml", formdetails);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("GetCities")]
        public List<City> GetCityDropdownList(int CountryId)
        {
            List<City> citieslist = _applicationUser.cities.Where(x => x.CountryId == CountryId).ToList();
            return citieslist;
        }


        
        [Route("DeleteFormDetails/{id}")]
        public IActionResult DeleteForm(int id)
        {
            try
            {
                if (id<=0) 
                    return NotFound();

                var isdelete=_formsRepository.DeleteDetails(id);

                return RedirectToAction("GetFormBookingList", "HRForm");
            }
            catch(Exception)
            {
                throw;
            }

        }

    }
}


