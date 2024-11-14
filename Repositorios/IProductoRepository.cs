using tp5.Models;
namespace tp5.Repositorios
{
    public interface IProductoRepository
    {
        public void CreateProducto(Productos producto);

        public void UpdateProducto(Productos producto, int idProducto);

        public List<Productos> ListProductos();

        public Productos DetallesPorID(int id);

        public void DeletePorId(int id);
       
    }
}
