using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;


            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.jobs = jobs;
                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                //ViewBag.column = searchType;
                ViewBag.jobs = jobs;
                return View("Index");
            }

        }

    }
}
