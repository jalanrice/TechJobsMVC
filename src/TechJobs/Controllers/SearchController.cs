using System.Collections.Generic;
using System.Globalization;
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
            ViewBag.previous = searchType;


            if (searchType.Equals("all"))
            {
                IEnumerable<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                return View("Index");
            }
            else
            {
                IEnumerable<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                //ViewBag.column = searchType;
                ViewBag.jobs = jobs;
                return View("Index");
            }

        }

    }
}
