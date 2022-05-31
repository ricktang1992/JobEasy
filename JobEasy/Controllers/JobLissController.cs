using JobEasy.Data;
using JobEasy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobEasy.Controllers
{
    public class JobListController : Controller
    {
        private readonly ApplicationDbContext _db;
        public JobListController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<JobList> objJobListList = _db.JobLists.ToList();

            return View(objJobListList);
        }

        //GET
        public IActionResult Create()
        {


            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobList obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.JobLists.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "JobList created successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        private IActionResult RedirectResult(Func<IActionResult> index)
        {
            throw new NotImplementedException();
        }
        //GET
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var JobListformDb = _db.JobLists.Find(id);
            if (JobListformDb == null)
            {
                return NotFound();
            }


            return View(JobListformDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit
            (JobList obj)
        {
          
            if (ModelState.IsValid)
            {
                _db.JobLists.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "JobList updated successfully.";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int id)
        {

            var JobListformDb = _db.JobLists.Find(id);
            if (JobListformDb == null)
            {
                return NotFound();
            }


            return View(JobListformDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(JobList obj)
        {
          

            _db.JobLists.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "JobList deleted successfully.";

            return RedirectToAction("Index");


        }


        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var JobListformDb = _db.JobLists.Find(id);
            if (JobListformDb == null)
            {
                return NotFound();
            }


            return View(JobListformDb);
        }

    }
}