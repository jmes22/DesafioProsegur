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
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfwork;

        public HomeController(
            ILogger<HomeController> logger,
            IUnitOfWork unitOfwork
            )
        {
            _logger = logger;
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index(string rol)
        {
            SessionManager.SetRol(HttpContext, rol);
            insertarDataInicial();

            return View();
        }

        private void insertarDataInicial() 
        {
            _unitOfwork.EstadoRepository.Iniciar();
            _unitOfwork.MateriaPrimaRepository.Iniciar();
            _unitOfwork.ItemRepository.Iniciar();
            _unitOfwork.ImpuestoRepository.Iniciar();
            _unitOfwork.ProvinciaRepository.Iniciar();
            _unitOfwork.MateriaPrimaXItemRepository.Iniciar();
            _unitOfwork.RolRepository.Iniciar();
            _unitOfwork.AccionRepository.Iniciar();
            _unitOfwork.AccionXRolRepository.Iniciar();
            _unitOfwork.UsuarioRepository.Iniciar();
            _unitOfwork.CommitTransaction();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}