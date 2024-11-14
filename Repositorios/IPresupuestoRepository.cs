using tl2_tp6_2024_pnacusse.Models;
namespace tl2_tp6_2024_pnacusse.Repositorios
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
