using First_Sample_Project.Models;
using First_Sample_Project.Models.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace First_Sample_Project.FormsRepository
{
    public class HRFormsRepository : IHRFormsRepository
    {
        private readonly ApplicationUser _context;

        public HRFormsRepository(ApplicationUser context)
        {
            _context = context;
        }
        public int AddDetails(HRFormModel FormModel)
        {

            try
            {
                HRFormModel model = new HRFormModel();
                model.FirstName = FormModel.FirstName;
                model.LastName = FormModel.LastName;
                model.Status = FormModel.Status;
                model.Department = FormModel.Department;
                model.Phone = FormModel.Phone;
                model.DateofIncident = FormModel.DateofIncident;
                model.TimeofIncident = FormModel.TimeofIncident;
                model.IncidentLocation = FormModel.IncidentLocation;
                model.Pleasespecifyincidentdetails=FormModel.Pleasespecifyincidentdetails;
                model.Witnessifavailable = FormModel.Witnessifavailable;
                model.Suggestions = FormModel.Suggestions;
                model.AdditionalComments = FormModel.AdditionalComments;
                model.CityId = FormModel.CityId;
                model.CountryId=FormModel.CountryId;
                _context.HRFormModels.Add(model);

                var success = _context.SaveChanges();
                return success==1 ? 1 : 0;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<HRFormModel> GetFormList()
        {
            try
            {
                List<HRFormModel> formlist = _context.HRFormModels.ToList();

                //softdelete
                var result = from form in formlist where form.IsDeleted==true select form;
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateFormDetails(int id, HRFormModel model)
        {
            try
            {
                if (id!=0 && model!=null)
                {


                    var existeddetails = _context.HRFormModels.FirstOrDefault(i => i.Id== id);

                    if (existeddetails!=null)
                    {
                        existeddetails.FirstName = model.FirstName;
                        existeddetails.LastName = model.LastName;
                        existeddetails.Status = model.Status;
                        existeddetails.Department = model.Department;
                        existeddetails.Phone = model.Phone;
                        existeddetails.DateofIncident = model.DateofIncident;
                        existeddetails.TimeofIncident = model.TimeofIncident;
                        existeddetails.IncidentLocation =model.IncidentLocation;
                        existeddetails.IncidentLocation = model.IncidentLocation;
                        existeddetails.Pleasespecifyincidentdetails=model.Pleasespecifyincidentdetails;
                        existeddetails.Witnessifavailable = model.Witnessifavailable;
                        existeddetails.Suggestions = model.Suggestions;
                        existeddetails.AdditionalComments = model.AdditionalComments;
                        existeddetails.CityId = model.CityId;
                        existeddetails.CountryId=model.CountryId;
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region Delete FormDetails
        public int DeleteDetails(int id)
        {
            try
            {
                if (id>0)
                {
                    var formdetails = _context.HRFormModels.FirstOrDefault(i => i.Id==id);
                    if (formdetails!=null)
                    {
                        _context.HRFormModels.Remove(formdetails);
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

        public HRFormModel GetDetailsbyId(int? id)
        {
            try
            {
                var details = GetFormList().FirstOrDefault(i => i.Id==id);
                if (details!=null)
                {
                    return details;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }



        public List<HRFormDisplayModel> SP_FormList()
        {
            //var data = _context.Database.SqlQuery<HRFormDisplayModel>($"EXECUTE SP_FormBookingList").ToList();
            List<HRFormDisplayModel> data=_context.Database.SqlQuery<HRFormDisplayModel>($"EXECUTE SP_FormBookingList").ToList();
           
            List<HRFormDisplayModel> list= new List<HRFormDisplayModel>();

            foreach (var item in data)
            {
                HRFormDisplayModel obj = new HRFormDisplayModel();
                obj.Id = item.Id;
                obj.FirstName = item.FirstName;
                obj.LastName = item.LastName;
                obj.Status = item.Status;
                obj.Department = item.Department;
                obj.Phone = item.Phone;
                obj.DateofIncident = item.DateofIncident;

                obj.TimeofIncident = item.TimeofIncident;
                obj.AdditionalComments = item.AdditionalComments;
                obj.CountryName = item.CountryName;
                obj.CityName = item.CityName;
                list.Add(obj);
            }
            return list;
        }

        public int SP_AddFormDetails(string firstName, string lastName, string status, string department, string phone, DateTime dateOfIncident, TimeSpan timeOfIncident, string incidentLocation, string witnessIfAvailable, string specifyIncidentDetails, string suggestions, int countryId, int cityId, bool isDeleted)
        {
            var firstnameparam =new SqlParameter("@FirstName",firstName);
            var lastnameparam= new SqlParameter("@LastName",lastName);
            var stausparam=new SqlParameter("@Status",status);
            var departmenparam=new SqlParameter("@Department",department);
            var phoneparam=new SqlParameter("@phone",phone);
            var dateofincidentparam= new SqlParameter("@DateofIncident",dateOfIncident);
            var timeofincident=new SqlParameter("@TimeofIncident",timeOfIncident);
            var incidentlocationparam=new SqlParameter("@IncidentLocation",incidentLocation);
            var withnessparam=new SqlParameter("@Witnessifavailable",witnessIfAvailable);
            var specifyincidentparam=new SqlParameter("@Pleasespecifyincidentdetails", specifyIncidentDetails);
            var suggestionsparam=new SqlParameter("@Suggestions",suggestions);
            var countryidparam=new SqlParameter("@CountryId",countryId);
            var cityidparam=new SqlParameter("@CityId",cityId);
            var isdeletedparam=new SqlParameter("@IsDeleted",isDeleted);

            var affectedrows = _context.Database.ExecuteSqlRaw("EXEC SP_AddFormDetails @FirstName,@LastName,@Status,@Department,@phone,@DateofIncident,@TimeofIncident,@IncidentLocation,@Witnessifavailable,@Pleasespecifyincidentdetails,@Suggestions,@CountryId,@CityId,@IsDeleted",
                firstnameparam,lastnameparam,stausparam,departmenparam,phoneparam,dateofincidentparam,timeofincident, incidentlocationparam, withnessparam, specifyincidentparam, suggestionsparam, countryidparam, cityidparam, isdeletedparam);

            return affectedrows;
        }
    }
}

