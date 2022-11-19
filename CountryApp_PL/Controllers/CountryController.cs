
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryApp_PL.Controllers
{
    public class CountryController : Controller
    {
        private IUintOfWork _uintOfWork;

        public CountryController(IUintOfWork uintOfWork)
        {
            _uintOfWork = uintOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Country> countries = _uintOfWork.CountryRepo.GetAll();
            return View(countries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                country.CreatedDate = DateTime.Now;
                _uintOfWork.CountryRepo.Add(country);
                _uintOfWork.Save();
                TempData["success"] = "Add record successfully";
                return RedirectToAction("Index");
            }
            return View(country);

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var country = _uintOfWork.CountryRepo.GetT(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var country = _uintOfWork.CountryRepo.GetT(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _uintOfWork.CountryRepo.Update(country);
                _uintOfWork.Save();
                TempData["success"] = "Update data successfully";
                return RedirectToAction("Index");
            }
            return View(country);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var country = _uintOfWork.CountryRepo.GetT(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {

            var country = _uintOfWork.CountryRepo.GetT(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            _uintOfWork.CountryRepo.Delete(country);
            _uintOfWork.Save();
            TempData["success"] = "Delete data successfully";
            return RedirectToAction("Index");

        }

    }
}
