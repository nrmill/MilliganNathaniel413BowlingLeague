using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MilliganNathaniel413BowlingLeague.Models;
using MilliganNathaniel413BowlingLeague.Models.ViewModels;

namespace MilliganNathaniel413BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(long? teamId, string teamName, int pageNum = 0)
        {
            int pageSize = 5;


            return View(new IndexViewModel
            {
                //order Bowlers consistently and take the correct page's list of bowlers
                Bowlers = context.Bowlers
                .Where(b => b.TeamId == teamId || teamId == null)
                .OrderBy(b => b.BowlerFirstName)
                .Skip((pageNum - 1) * 5)
                .Take(pageSize)
                .ToList(),
                //set pagination info
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //if no team selected give total, else get count of selected team
                    TotalNumItems = teamId == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(b => b.TeamId == teamId).Count()

                },
                TeamName = teamName
            });


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
