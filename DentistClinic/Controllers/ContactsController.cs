using DentistClinic.Core.Models;
using DentistClinic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistClinic.Controllers
{
	public class ContactsController : Controller
	{
        private readonly IUnitOfWork _unitOfWork;

        public ContactsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
		[Authorize(Roles = "Doctor")]
		public IActionResult Index()
		{
            var model = _unitOfWork.contactRepository.GetAll();
            return View(model);
        }
		[Authorize(Roles = "Doctor")]
		public IActionResult Confirm(int id)
		{
			if (id == 0)
				return BadRequest();
			var msg = _unitOfWork.contactRepository.GetById(id);
			if (msg != null)
			{
				msg.IsConfirmed = true;
				_unitOfWork.contactRepository.Update(msg);
				return RedirectToAction("Index");
			}
			return NotFound();
		}
		[Authorize(Roles = "Doctor")]
		public IActionResult UnConfirm(int id)
		{
			if (id == 0)
				return BadRequest();
			var msg = _unitOfWork.contactRepository.GetById(id);
			if (msg != null)
			{
				msg.IsConfirmed = false;
				_unitOfWork.contactRepository.Update(msg);
				return RedirectToAction("Index");
			}
			return NotFound();
		}
		[Authorize(Roles = "Doctor")]
		public IActionResult Delete(int id)
		{
			if (id == 0)
				return BadRequest();
			var msg = _unitOfWork.contactRepository.GetById(id);
			if (msg != null)
			{
				_unitOfWork.contactRepository.Delete(msg);
				return RedirectToAction("Index");
			}
			return NotFound();
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(ContactMsg msg)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.contactRepository.Create(msg);
				return RedirectToAction("Index", "Home");
			}
			return View(msg);
		}

	}
}
