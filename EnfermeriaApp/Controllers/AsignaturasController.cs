using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EnfermeriaApp.Models;
using EnfermeriaApp.Services;

namespace EnfermeriaApp.Controllers
{
    public class AsignaturasController : Controller
    {
        private readonly AsignaturaService _service;
        private const int PageSize = 10; 

        public AsignaturasController(AsignaturaService service)
        {
            _service = service;
        }

        public IActionResult Index(int page = 1)
        {
            try
            {
                int totalRegistros;
                IEnumerable<Asignatura> asignaturas = _service.ObtenerAsignaturas(page, PageSize, out totalRegistros);

                int totalPages = (int)System.Math.Ceiling((double)totalRegistros / PageSize);

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = totalPages;
                ViewBag.PageSize = PageSize;

                return View(asignaturas);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }
    }
}
