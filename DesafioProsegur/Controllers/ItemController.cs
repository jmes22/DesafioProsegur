using DAL;
using DesafioProsegur.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioProsegur.Controllers
{
    public class ItemController : Controller
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IUnitOfWork _unitOfwork;

        public ItemController(
            ILogger<ItemController> logger,
            IUnitOfWork unitOfwork
            )
        {
            _logger = logger;
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            var a = 0;
            var b = _unitOfwork.DetalleFacturaRepository.GetCantidad(1, 2);

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