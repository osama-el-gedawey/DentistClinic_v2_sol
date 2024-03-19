using DentistClinic.Core.Models;
using DentistClinic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentistClinic.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalysisController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var analysis = _unitOfWork.analysisRepository.GetAll();
            return View(analysis);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Analysis analyis)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.analysisRepository.Create(analyis);
                return RedirectToAction("Index");
            }

            return View(analyis);

        }
        [HttpGet]
		public IActionResult Delete(int id)
		{
			if (id == 0)
				return BadRequest();
			var deleteAnalysis = _unitOfWork.analysisRepository.GetById(id);
			if (deleteAnalysis != null)
			{
				deleteAnalysis.IsDeleted = true;
				_unitOfWork.analysisRepository.Update(deleteAnalysis);
				return RedirectToAction("Index");
			}
			return NotFound();
		}

		[HttpGet]
		public IActionResult UnDelete(int id)
		{
			if (id == 0)
				return BadRequest();
			var deleteAnalysis = _unitOfWork.analysisRepository.GetById(id);
			if (deleteAnalysis != null)
			{
				deleteAnalysis.IsDeleted = false;
				_unitOfWork.analysisRepository.Update(deleteAnalysis);
				return RedirectToAction("Index");
			}
			return NotFound();
		}

		[HttpGet]
        public IActionResult Edit(int id)
        {
            var editedAnlysis = _unitOfWork.analysisRepository.GetById(id);

            if (editedAnlysis == null)
                return NotFound();

            return View(editedAnlysis);
        }



        [HttpPost]
        public IActionResult Edit(Analysis analysis)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.analysisRepository.Update(analysis);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(analysis);

        }

    }
}
