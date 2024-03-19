﻿namespace DentistClinic.Core.Models
{
    public class Tplans
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Notes { get; set; }
        public int PatientId { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
