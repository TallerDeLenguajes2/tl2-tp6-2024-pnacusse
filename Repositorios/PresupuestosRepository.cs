using Microsoft.Data.Sqlite;
using System.Windows.Input;
using tl2_tp6_2024_pnacusse.Controllers;
using tl2_tp6_2024_pnacusse.Models;

namespace tl2_tp6_2024_pnacusse.Repositorios
{
    public class PresupuestoRepository : IPresupuestoRepository
    {
        private readonly string connectionString = "Data Source=Db/Tienda.db;Cache=Shared";

        public void AgregarProductoCantidad(int idPresupuesto, PresupuestoDetalle detalle)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var query = "INSERT INTO PresupuestosDetalle (idPresupuesto, idProducto, Cantidad) "
                                   + "VALUES (@idPresupuesto, @idProducto, @Cantidad);";

                SqliteCommand command = new(query, connection);
                command.Parameters.Add(new SqliteParameter("@idPresupuesto", idPresupuesto));
                command.Parameters.Add(new SqliteParameter("@idProducto", detalle.Producto.IdProducto));
                command.Parameters.Add(new SqliteParameter("@Cantidad", detalle.Cantidad));
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void CreatePresupuesto(Presupuestos presupuesto)
        {
            var query = $"INSERT INTO Presupuestos (idPresupuesto, NombreDestinatario, FechaCreacion) VALUES (@idPresupuesto, @NombreDestinatario, @FechaCreacion)";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(query, connection);

                command.Parameters.Add(new SqliteParameter("@idPresupuestos", presupuesto.IdPresupuesto));
                command.Parameters.Add(new SqliteParameter("@NombreDestinatario", presupuesto.NombreDestinatario));
                command.Parameters.Add(new SqliteParameter("@FechaCreacion", presupuesto.FechaCreacion));

                command.ExecuteNonQuery();

                connection.Close();
            }
        }


        public void DeletePresupuesto(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var query = "DELETE FROM Preupuestos Where idPresupuesto = (@idPresupuesto)";

                SqliteCommand command = new SqliteCommand(query, connection);

                command.Parameters.Add(new SqliteParameter("@idPresupuesto", id));
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<Presupuestos> GetAllPresupuestos()
        {
            var query = $"SELECT * FROM Presupuestos";

            List<Presupuestos> presupuestos = new List<Presupuestos>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);
                connection.Open();

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateOnly FechaPresupuesto = new();
                        DateOnly.TryParseExact((string?)reader["FechaCreacion"], "yyyy-MM-dd", out FechaPresupuesto);
                        var presupuesto = new Presupuestos();
                        presupuesto.IdPresupuesto = Convert.ToInt32(reader["idProducto"]);
                        presupuesto.NombreDestinatario = reader["nombreDestinatario"].ToString();
                        presupuesto.FechaCreacion = FechaPresupuesto;
                        presupuestos.Add(presupuesto);
                    }
                }

                connection.Close();
            }

            return presupuestos;
        }

        public Presupuestos GetPresupuestosById(int idPresupuesto)
        {
            Presupuestos presupuesto = new Presupuestos();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT P.idPresupuesto, P.NombreDestinatario, P.FechaCreacion, PR.idProducto, PR.Descripcion "
                                   + "AS Producto, PR.Precio, PD.Cantidad, (PR.Precio * PD.Cantidad) AS Subtotal "
                                   + "FROM Presupuestos P "
                                   + "JOIN PresupuestosDetalle PD ON P.idPresupuesto = PD.idPresupuesto "
                                   + "JOIN Productos PR ON PD.idProducto = PR.idProducto "
                                   + "WHERE P.idPresupuesto = (@idPresupuesto);";

                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.Add(new SqliteParameter(@"idPresupuesto", idPresupuesto));
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (presupuesto.NombreDestinatario == null || presupuesto.FechaCreacion == new DateOnly(1, 1, 1))
                    {
                        DateOnly FechaPresupuesto = new();
                        DateOnly.TryParseExact((string?)reader["FechaCreacion"], "yyyy-MM-dd", out FechaPresupuesto);
                        presupuesto.IdPresupuesto = Convert.ToInt32(reader["idProducto"]);
                        presupuesto.NombreDestinatario = reader["descripcion"].ToString();
                        presupuesto.Detalle = new List<PresupuestoDetalle>();
                        presupuesto.FechaCreacion = FechaPresupuesto;
                    }

                    var producto = new Productos
                    {
                        IdProducto = Convert.ToInt32(reader["idProducto"]),
                        Descripcion = reader["Producto"].ToString(),
                        Precio = Convert.ToInt32(reader["Precio"])
                    };

                    var detalle = new PresupuestoDetalle
                    {
                        Producto = producto,
                        Cantidad = Convert.ToInt32(reader["Cantidad"])
                    };

                    presupuesto.Detalle.Add(detalle);
                }

                connection.Close();

            }

            return presupuesto;
        }
    }
}
