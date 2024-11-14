namespace tp5.Models
{
    public class Presupuestos
    {
        private int idPresupuesto;
        private string nombreDestinatario;
        private List<PresupuestoDetalle> detalle;
        private DateOnly fechaCreacion;

        public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
        public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
        public List<PresupuestoDetalle> Detalle { get => detalle; set => detalle = value; }
        public DateOnly FechaCreacion { get => FechaCreacion; set => FechaCreacion = value; }

        public Presupuestos(int idPresupuesto, string nombreDestinatario, List<PresupuestoDetalle> detalle, DateOnly fechaCreacion)
        {
            this.idPresupuesto = idPresupuesto;
            this.nombreDestinatario = nombreDestinatario;
            this.detalle = detalle;
            FechaCreacion = fechaCreacion;

        }

        public Presupuestos() { }

        public int getIdPresupuesto() { return idPresupuesto; }


        public void MontoPresupuesto()
        {

        }

        public void MontoPresupuestoConIva()
        {

        }

        public void CantidadProductos()
        {

        }
    }
}
