using Entidades.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Servicio.Interfaz;

namespace Prueba_tecnica__az_smart_technology.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroService _libroService;
        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        #region GET

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var libros = await _libroService.ObtenerLibros();
            return View(libros);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            LibroVM libroVM = await _libroService.ObtenerLibroVM();
            return View(libroVM);
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            var libro = await _libroService.ObtenerLibroPorID(id);

            return PartialView("_DetalleLibro", libro);
        }

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            LibroVM libro = await _libroService.ObtenerLibroVMPorID(id);

            return View(libro);
        }

        #endregion

        #region POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(LibroVM libroVM)
        {
            try
            {             
                if (ModelState.IsValid)
                {
                    await _libroService.CrearLibro(libroVM);
                    return RedirectToAction("Index");
                }

                libroVM.ListaAutores = await _libroService.ObtenerListaAutores();
                return View(libroVM);
            }
            catch (Exception)
            {

                return Json(new { success = true, message = "Ocurrio un error." });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actualizar(LibroVM libroVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine(libroVM.Libro.ID);
                    await _libroService.ActualizarLibro(libroVM);
                    return RedirectToAction("Index");
                }
                else
                {
                    libroVM.ListaAutores = await _libroService.ObtenerListaAutores();
                    return View(libroVM);
                }
            }
            catch (Exception)
            {

                return Json(new { success = true, message = "Ocurrio un error." });
            }
        }
        #endregion

        #region DELETE

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool resultado = _libroService.EliminarLibro(id);

            if (resultado == false)
            {
                return Json(new { success = false, message = "No se encontró el libro." });
            }
           
            return Json(new { success = true, message = "El libro ha sido eliminado correctamente" });
        }

        #endregion
    }
}