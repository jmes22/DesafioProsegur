using DAL;
using DesafioProsegur.Models;
using Entity.Common;
using Entity.Entities.Sistema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioProsegur.Controllers
{
    public class MateriaPrimaController : Controller
    {
        private readonly ILogger<MateriaPrimaController> _logger;
        private readonly IUnitOfWork _unitOfwork;

        public MateriaPrimaController(
            ILogger<MateriaPrimaController> logger,
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

        [HttpGet]
        public JsonResult GetAll()
        {
            var data = _unitOfwork.MateriaPrimaRepository.GetAll();
            return Json(JsonReturn.SuccessConRetorno(data));
        }

        [HttpPost]
        public JsonResult Guardar(MateriaPrimaViewModel oViewModel)
        {
            if(oViewModel == null || oViewModel.MateriasPrima == null)
                return Json(JsonReturn.ErrorConMsjSimple());

            oViewModel.ValidarModelo(oViewModel, out string msjError);
            if (!string.IsNullOrEmpty(msjError))
                return Json(JsonReturn.ErrorConMsjSimple(msjError));


            _unitOfwork.MateriaPrimaRepository.Guardar(oViewModel.MateriasPrima);
            _unitOfwork.CommitTransaction();

            return Json(JsonReturn.SuccessSinRetorno());
        }
    }
}