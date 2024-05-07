using First_Sample_Project.CustomFilters;
using First_Sample_Project.FileRepository;
using First_Sample_Project.Models;
using First_Sample_Project.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace First_Sample_Project.Controllers
{

    [Route("Files")]
    [CustomAuthorizationFilter]
    public class DataController : Controller
    {

        private readonly IWebHostEnvironment _webhostbuilder;
        private readonly IFileSystemRepository _Ifilesystemrepository;

        public DataController(IWebHostEnvironment webhostbuilder, IFileSystemRepository filerepository)
        {
            _webhostbuilder =webhostbuilder;
            _Ifilesystemrepository=filerepository;
            
        }

        [HttpGet]
        [Route("GetFolder")]

        public IActionResult GetFiles(string foldername,string fileName)
        {
            try
            {
                var wwwrootpath = _webhostbuilder.WebRootPath;
                var folderpath = Path.Combine(wwwrootpath, foldername);
                
                if(!Directory.Exists(folderpath))
                {
                    return NotFound("Folder Not Found");
                }


                var filepath=Path.Combine(folderpath, fileName);

                
                if (System.IO.File.Exists(filepath))
                {
                    return Ok(new { fileExists = true });
                }
                else
                {
                    return Ok(new { fileExists = false });
                }
            }
            catch(Exception)
            {
                throw;
            }
        }


        [Route("FileListPage")]
        [HttpGet]
        public IActionResult FileIndex()
        {
            try
            {
                List<FilesViewModel> filelist = _Ifilesystemrepository.FileList();
                if(filelist.Count == 0)
                {
                    return NotFound();
                }
                return View(filelist);
            }
            catch(Exception)
            {
                throw;
            }
        }


        [Route("GetFileUploading")]
        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }


       
        [HttpPost]
        [Route("PostFileUpload")]
        public IActionResult FileUpload(List<IFormFile> files)
        {
            try
            {

                var returnedvalue=_Ifilesystemrepository.AddFiles(files);
                if(returnedvalue>=1)
                {
                    TempData["Message"]="File uploaded successfully";
                    return View();
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Route("UploadwithVersion")]
        [HttpPost]
        public IActionResult FileUploadwithversion(List<IFormFile> files)
        {
            try
            {

                var returnedvalue = _Ifilesystemrepository.AddFileswithversion(files);
                if (returnedvalue>=1)
                {
                    TempData["Message"]="File uploaded successfully";
                    return View("~/Views/Data/FileUpload.cshtml");
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }



        #region FileDownload
        [Route("DownloadFiles")]
        public IActionResult DownloadFile(string filename)
        {
            try
            {
                string path = Path.Combine(_webhostbuilder.WebRootPath, "FileDocuments", filename);

                var memory = new MemoryStream();

                var stream = new FileStream(path, FileMode.Open);
                {
                    stream.CopyTo(memory);
                }

                memory.Position=0;
                return File(memory, GetContentType(path),Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while downloading the file: {ex.Message}");
                throw;
            }
        }

        private string GetContentType(string path)
        {
            var types = extensions();
            var extension=Path.GetExtension(path).ToLowerInvariant();
            return types[extension];
        }

        private Dictionary<string,string> extensions()
        {
            return new Dictionary<string, string>
            {
                {".txt","text/plain" },
                {".pdf","application/pdf" },
                {".docx","application/vnd.ms-word"},
                {".xls","application/vnd.ms-excel"},
                {".jpg","image/jpg"},
                {".jpeg","image/jpeg" },
                {".ppt", "application/vnd.ms-powerpoint" },
                {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                {".png", "image/png"},
            };
        }
        #endregion 
    }
}
