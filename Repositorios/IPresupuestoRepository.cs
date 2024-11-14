using tp5.Models;
namespace tp5.Repositorios
{
    public interface IPresupuestoRepository
    {
        public void CreatePresupuesto(Presupuestos presupuesto);

        public List<Presupuestos> GetAllPresupuestos();

        public Presupuestos GetPresupuestosById(int id);

        public void AgregarProductoCantidad(int idPresupuesto, PresupuestoDetalle detalle);

        public void DeletePresupuesto(int id);
    }
}
