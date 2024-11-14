using Microsoft.Data.Sqlite;
using tp5.Repositorios;
using tp5.Models;

public class ProductoRepository : IProductoRepository
{
    private readonly string connectionString = "Data Source=Db/Tienda.db;Cache=Shared";
    public void CreateProducto(Productos producto)
    {
        var query = $"INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);

            command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));

            command.ExecuteNonQuery();

            connection.Close(); 
        }
    }

    public void DeletePorId(int id)
    {
        var query = $"DELETE FROM Productos WHERE idProducto = @idProducto";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = new SqliteCommand(query , connection);    

            command.Parameters.Add(new SqliteParameter("id", id));

            command.ExecuteNonQuery ();

            connection.Close();
        }
    }

    public Productos DetallesPorID(int id)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);

        var query = $"SELECT * FROM Productos WHERE idProducto = @idProducto";

        Productos producto = new Productos();

        SqliteCommand command = connection.CreateCommand();

        command.CommandText = query;
        command.Parameters.Add(new SqliteParameter ("id", id));

        connection.Open();

        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                producto.IdProducto = Convert.ToInt32(reader["idProducto"]);
                producto.Descripcion = reader["descripcion"].ToString();
                producto.Precio = Convert.ToInt32(reader["precio"]);

            }
        }

        connection.Close();

        return producto;
    }

    public List<Productos> ListProductos()
    {
        var query = $"SELECT * FROM Productos";

        List<Productos> productos = new List<Productos>();

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Productos();
                    product.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    product.Descripcion = reader["descripcion"].ToString();
                    product.Precio = Convert.ToInt32(reader["precio"]);
                    productos.Add(product);
                }
            }

            connection.Close();
        }

        return productos;
    }
    public void UpdateProducto(Productos producto, int idProducto)
    {
        var query = $"UPDATE producto SET descripcion = @desripcion, precio = @precio WHERE idProducto = {idProducto}";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);

            command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}