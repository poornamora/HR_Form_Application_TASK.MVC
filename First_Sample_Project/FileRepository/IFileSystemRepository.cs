using First_Sample_Project.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace First_Sample_Project.FileRepository
{
    public interface IFileSystemRepository
    {
        //string[] GetFiles(string directory);
        List<FilesViewModel> FileList();
        int AddFiles(List<IFormFile> postedfiles);

        int AddFileswithversion(List<IFormFile> files);

        //int DownloadFile();
    }
}
