﻿using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.DataModels;

namespace Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Company company = new();

            if (id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                return View(company);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company, IFormFile? file)
        {

            if (ModelState.IsValid)
            {

                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                    TempData["success"] = "Company created successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                    TempData["success"] = "Company updated successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(company);
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll();
            return Json(new { data = companyList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (company == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(company);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}