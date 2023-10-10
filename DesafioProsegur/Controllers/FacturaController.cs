using DAL;
using DesafioProsegur.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioProsegur.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ILogger<FacturaController> _logger;
        private readonly IUnitOfWork _unitOfwork;

        public FacturaController(
            ILogger<FacturaController> logger,
            IUnitOfWork unitOfwork
            )
        {
            _logger = logger;
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            return View();
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