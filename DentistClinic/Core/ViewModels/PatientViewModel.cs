﻿using DentistClinic.Core.Constants;
using DentistClinic.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace DentistClinic.Core.ViewModels
{
    public class PatientViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = Errors.usernameLengthMSG, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(20, ErrorMessage = Errors.usernameLengthMSG, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        public string? FullName { get; set; }

        [Required]
        [RegularExpression(@"^(\+201|01|00201)[0-2,5]{1}[0-9]{8}", ErrorMessage = Errors.phoneValidation)]
        [Display(Name = "Mobile Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; } = null!;
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Occuopation")]
        public string Occupation { get; set; } = null!;
        [Required]
        [StringLength(200, ErrorMessage = Errors.usernameLengthMSG, MinimumLength = 5)]
        [Display(Name = "Address")]
        public string Address { get; set; } = null!;
        public double CurentBalance { get; set; } = 0;
        public Boolean IsDeleted { get; set; } = false;
        public byte[]? ProfilePicture { get; set; }
        public List<PaymentRecord> PaymentRecords { get; set; } = new List<PaymentRecord>();
        public  List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<ChiefComplainPatient> ChiefComplainPatients { get; set; } = new List<ChiefComplainPatient>();
        public List<Tplans> Tplans { get; set; } = new List<Tplans>();
        public List<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
