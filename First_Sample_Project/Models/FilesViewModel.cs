using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Sample_Project.Models
{
    [Table("FileStorageTable")]
    public class FilesViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
    }
}
