using MailKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;

        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Privacy()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> About()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Contact()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Gallery()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> Nutrigenomics()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> Fitnessgenomics()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> Pharmacogenomics()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> Team()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> Appointment()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return View("index");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
