using DentistClinic.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace DentistClinic.Core.Models
{
    public class Xray
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        [MinLength(3,ErrorMessage ="Name must be at least 3 char")]
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<XrayPrescription>? XrayPrescriptions { get; set; }

    }
}
