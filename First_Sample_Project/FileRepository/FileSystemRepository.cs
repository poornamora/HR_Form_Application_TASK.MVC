using First_Sample_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace First_Sample_Project.FileRepository
{
    public class FileSystemRepository : IFileSystemRepository
    {

        private readonly ApplicationUser _context;

        private readonly IWebHostEnvironment _webhostbuilder;

        public FileSystemRepository(ApplicationUser context, IWebHostEnvironment webhostbuilder)
        {
            _context = context;
            _webhostbuilder = webhostbuilder;
        }
        #region FileList
        public List<FilesViewModel> FileList()
        {
            try
            {
                var files = _context.filesViewModels.ToList();
                if (files.Count<1)
                {
                    return null;
                }
                return files;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region AddFiles
        public int AddFiles(List<IFormFile> postedfiles)
        {
            try
            {
                if (postedfiles==null)
                {
                    return 0;
                }
                else
                {
                    var Iscuccess=0;
                    List<FilesViewModel> uploadedFiles = new List<FilesViewModel>();
                    foreach (var file in postedfiles)
                    {
                        string Uploadfile = Path.Combine(_webhostbuilder.WebRootPath, "FileDocuments");
                        if (!Directory.Exists(Uploadfile))
                        {
                            Directory.CreateDirectory(Uploadfile);
                        }

                        //string filename=Guid.NewGuid().ToString()+'_'+file.Name;

                        var filename = Path.GetFileName(file.FileName);
                        var filepath = Path.Combine(Uploadfile, filename);


                        using (var filestream = new FileStream(filepath, FileMode.Create))
                        {
                            file.CopyTo(filestream);
                        }

                        var fileEntity = new FilesViewModel
                        {
                            FileName=filename,
                            FilePath= filepath
                        };

                        FilesViewModel uploaded = new FilesViewModel();
                        uploaded.FileName=file.FileName;
                        uploaded.FilePath=fileEntity.FilePath;


                        _context.filesViewModels.Add(uploaded);

                        //if exists already exists doesn't update in database
                        var existsdata = _context.filesViewModels.Where(i=>i.FileName==filename).FirstOrDefault();
                        if (existsdata==null)
                        {
                            Iscuccess = _context.SaveChanges();
                        }
                    }
                    return Iscuccess==1 ? 1 : 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion



        #region AddFileswithversion
        public int AddFileswithversion(List<IFormFile> postedfiles)
        {
            try
            {
                if (postedfiles==null)
                {
                    return 0;
                }
                else
                {
                    var Iscuccess = 0;
                    List<FilesViewModel> uploadedFiles = new List<FilesViewModel>();
                    foreach (var file in postedfiles)
                    {
                        string Uploadfile = Path.Combine(_webhostbuilder.WebRootPath, "FileDocuments");

                        string filename = Path.GetFileName(file.FileName);

                        var versionedfilename = filename;
                        int i = 1;
                        while (File.Exists(Path.Combine(Uploadfile, versionedfilename)))
                        {
                            versionedfilename= $"{Path.GetFileNameWithoutExtension(filename)}_V{i}{Path.GetExtension(filename)}";
                            i++;
                        }

                        var filepath = Path.Combine(Uploadfile,versionedfilename);


                        using (var filestream = new FileStream(filepath, FileMode.Create))
                        {
                            file.CopyTo(filestream);
                        }

                        var fileEntity = new FilesViewModel
                        {
                            FileName=versionedfilename,
                            FilePath= filepath
                        };

                        FilesViewModel uploaded = new FilesViewModel();
                        uploaded.FileName=fileEntity.FileName;
                        uploaded.FilePath=fileEntity.FilePath;


                        _context.filesViewModels.Add(uploaded);

                        Iscuccess = _context.SaveChanges();
                    }
                    return Iscuccess==1 ? 1 : 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}


