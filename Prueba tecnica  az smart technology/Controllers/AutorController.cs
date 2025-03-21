using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicio.Interfaz;

namespace Prueba_tecnica__az_smart_technology.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;
        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        #region GET

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Autor> autores = await _autorService.ObtenerAutores();
            return View(autores);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            Autor autor = new Autor(); 
            return View(autor);
        }

        #endregion

        #region POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Autor autor)
        {          
            if (ModelState.IsValid)
            {
                if (await _autorService.AutorExiste(autor.Nombre))
                {
                    ModelState.AddModelError("Nombre", "Ya existe un autor registrado con ese nombre.");
                    return View(autor);
                }
                await _autorService.CrearAutor(autor);
                return RedirectToAction("Index", "Libro");
            }

            return View(autor);
        }
        #endregion
    }
}
