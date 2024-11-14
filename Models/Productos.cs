namespace tl2_tp6_2024_pnacusse.Models
{
    public class Productos
    {
        private int idProducto;
        private string descripcion;
        private int precio;
        public Productos()
        {

        }

        public Productos(int idProducto, string descripcion, int precio)
        {
            IdProducto = idProducto;
            Descripcion = descripcion;
            Precio = precio;

        }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Precio { get => precio; set => precio = value; }
    }
}
