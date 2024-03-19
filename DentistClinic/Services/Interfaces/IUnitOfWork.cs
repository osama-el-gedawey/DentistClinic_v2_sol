namespace DentistClinic.Services.Interfaces
{
    public interface IUnitOfWork
    {
        public IPatientRepository patientRepository { get; set; }
        public IAppointmentRepository appointmentRepository { get; set; }
        public IMedicineRepository medicineRepository { get; set; }
        public IXrayRepository xrayRepository { get; set; }
        public IAnalysisRepository analysisRepository { get; set; }
        public IContactRepository contactRepository { get; set; }
    }
}
