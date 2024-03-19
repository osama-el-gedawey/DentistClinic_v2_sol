﻿using System.ComponentModel.DataAnnotations;

namespace DentistClinic.Core.Models
{
    public class Analysis
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]

        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        [MinLength(4, ErrorMessage = "Type must be at least 3 characters long.")]
        public string Type { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<AnalysisPrescription>? AnalysisPrescriptions { get; set; }
    }
}
