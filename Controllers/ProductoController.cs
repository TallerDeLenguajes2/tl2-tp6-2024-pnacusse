using Microsoft.AspNetCore.Mvc;
using tl2_tp6_2024_pnacusse.Models;
using tl2_tp6_2024_pnacusse.Repositorios;

namespace tl2_tp6_2024_pnacusse.Controllers
{
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public ActionResult Index()
        {
            var productos = _productoRepository.ListProductos();
            return View(productos);
        }

        private ActionResult View(List<Productos> productos)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult CreateProducto(Productos producto)
        {
            _productoRepository.CreateProducto(producto);
            return RedirecToAction("Index");
        }

        private ActionResult RedirecToAction(string v)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult EditProducto(int idProducto)
        {
            return View(_productoRepository.GetProductoById(idProducto));
        }

        private ActionResult View(Productos productos)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProducto(Productos producto)
        {
            _productoRepository.UpdateProducto(producto, producto.IdProducto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteProducto(int idProducto)
        {
            return View(_productoRepository.GetProductoById(idProducto));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int idProducto)
        {
            _productoRepository.DeletePorId(idProducto);
            return RedirectToAction("Index");
        }


    }

}

