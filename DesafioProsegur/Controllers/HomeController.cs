using DAL;
using DesafioProsegur.Models;
using Entity.Entities.Sistema;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace DesafioProsegur.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public HomeController(
            IUnitOfWork unitOfwork
            )
        {
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index(string rol)
        {
            SessionManager.SetRol(HttpContext, rol, _unitOfwork);
            return View();
        }
    }
}