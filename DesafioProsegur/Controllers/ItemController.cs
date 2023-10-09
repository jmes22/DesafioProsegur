﻿using DAL;
using DesafioProsegur.Models;
using Entity.Common;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioProsegur.Controllers
{
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public ItemController(
            IUnitOfWork unitOfwork
            )
        {
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var items = _unitOfwork.ItemRepository.GetAll();
            List<object> result = new List<object>();

            foreach (var item in items)
            {
                result.Add(new { 
                    id = item.Id,
                    nombre = item.Nombre,
                    precio = item.Precio,
                    cantidad = 0
                });
            }

            return Json(JsonReturn.SuccessConRetorno(result));
        }
    }
}