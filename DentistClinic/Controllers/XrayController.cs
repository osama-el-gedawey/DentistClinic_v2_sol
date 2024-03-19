using DentistClinic.Core.Models;
using DentistClinic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistClinic.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class XrayController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public XrayController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var model= _unitOfWork.xrayRepository.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Xray xray)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.xrayRepository.Create(xray);
                return RedirectToAction("Index");
            }
            return View(xray);
        }
		public IActionResult Delete(int id)
		{
			if (id == 0)
				return BadRequest();
			var deleteXray = _unitOfWork.xrayRepository.GetById(id);
			if (deleteXray != null)
			{
                deleteXray.IsDeleted = true;
                _unitOfWork.xrayRepository.Update(deleteXray);
				return RedirectToAction("Index");
			}
			return NotFound();
		}
		public IActionResult UnDelete(int id)
		{
			if (id == 0)
				return BadRequest();
            var deleteXray = _unitOfWork.xrayRepository.GetById(id);
            if (deleteXray != null)
			{
                deleteXray.IsDeleted = false;
                _unitOfWork.xrayRepository.Update(deleteXray);
                return RedirectToAction("Index");
			}
			return NotFound();
		}
		public IActionResult Edit(int id)
		{
			if (id == 0)
				return BadRequest();
			var model = _unitOfWork.xrayRepository.GetById(id);
			if (model != null)
				return View(model);
			return NotFound();
		}

		[HttpPost]
        public IActionResult Edit(Xray xray)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.xrayRepository.Update(xray);
                return RedirectToAction("Index");
            }
            return View(xray);
        }
    }
}
