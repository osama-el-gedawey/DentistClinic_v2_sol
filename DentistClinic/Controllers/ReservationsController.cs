using DentistClinic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistClinic.Controllers
{
	[Authorize(Roles = "Doctor , Reception")]
	public class ReservationsController : Controller
	{
        private readonly IUnitOfWork _unitOfWork;

        public ReservationsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

		public IActionResult Index()
		{
			var model = _unitOfWork.appointmentRepository.UpComming();
			model = model.Where(a => a.PatientId != null).ToList();
			return View(model);
		}
	}
}
