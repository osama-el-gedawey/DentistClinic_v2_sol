using DentistClinic.Services.Interfaces;

namespace DentistClinic.Services.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        public IPatientRepository patientRepository { get; set;}
        public IAppointmentRepository appointmentRepository { get; set; }
        public IMedicineRepository medicineRepository { get; set;}
        public IXrayRepository xrayRepository { get; set; }
        public IAnalysisRepository analysisRepository { get; set; }
		public IContactRepository contactRepository { get; set; }

		public UnitOfWork(IPatientRepository patientRepository, IAppointmentRepository appointmentRepository, IMedicineRepository medicineRepository, IXrayRepository xrayRepository, IAnalysisRepository analysisRepository = null, IContactRepository contactRepository = null)
		{
			this.patientRepository = patientRepository;
			this.appointmentRepository = appointmentRepository;
			this.medicineRepository = medicineRepository;
			this.xrayRepository = xrayRepository;
			this.analysisRepository = analysisRepository;
			this.contactRepository = contactRepository;
		}


	}
}
