using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobBoard.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
