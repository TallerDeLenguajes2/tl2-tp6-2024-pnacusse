using tl2_tp6_2024_pnacusse.Models;
namespace tl2_tp6_2024_pnacusse.Repositorios
{
    public interface IProductoRepository
    {
        public void CreateProducto(Productos producto);

        public Productos GetProductoById(int idProducto);

        public void UpdateProducto(Productos producto, int idProducto);

        public List<Productos> ListProductos();

        public Productos DetallesPorID(int id);

        public void DeletePorId(int id);
       
    }
}
