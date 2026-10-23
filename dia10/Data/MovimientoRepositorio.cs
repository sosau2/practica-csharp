using MySqlConnector;
using Finanzas.Models;

namespace Finanzas.Data;
public class MovimientoRepositorio
{
    public readonly string _cadenaConexion ;
    
    public MovimientoRepositorio(string cadenaConexion)
    {
        _cadenaConexion = cadenaConexion;        
    }

    public List<Movimiento> ObtenerTodos()
    {
        using MySqlConnection conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();
        string sql = "SELECT id, monto, tipo, descripcion FROM movimientos ORDER BY id";
        using MySqlCommand comando = new MySqlCommand(sql,conexion);
        using MySqlDataReader lector = comando.ExecuteReader();

        List<Movimiento> movimientos = new List<Movimiento>();

        while (lector.Read())
        {
            movimientos.Add(LeerMovimientos(lector));
        }

        return movimientos;
        
    }

    public Movimiento? ObtenerPorId(int id)
    {
        using MySqlConnection conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();
        string sql = "SELECT * FROM movimientos WHERE id = @id ";

        using MySqlCommand comando = new MySqlCommand(sql,conexion);
        comando.Parameters.AddWithValue("@id",id);

        using MySqlDataReader lector = comando.ExecuteReader();

        if (lector.Read())
        {
            return LeerMovimientos(lector);
        }

        return null;
    }

    public void Agregar(Movimiento movimiento)
    {
        using MySqlConnection conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();
        
        string sql = "INSERT INTO movimientos (monto,tipo,descripcion) VALUES (@monto, @tipo, @descripcion)";
        using MySqlCommand comando = new MySqlCommand(sql,conexion);

        comando.Parameters.AddWithValue("@monto",movimiento.Monto);
        comando.Parameters.AddWithValue("@tipo",movimiento.TipoMovimiento);
        comando.Parameters.AddWithValue("@descripcion",movimiento.Descripcion);
        comando.ExecuteNonQuery();
        
    }

    public void Actualizar(Movimiento movimiento)
    {
        string sql = "UPDATE movimientos SET monto = @monto, tipo = @tipo, descripcion = @descripcion WHERE id = @id";
        using MySqlConnection conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();
        using MySqlCommand comando = new MySqlCommand (sql,conexion);
        comando.Parameters.AddWithValue("@monto",movimiento.Monto);
        comando.Parameters.AddWithValue("@tipo",movimiento.TipoMovimiento);
        comando.Parameters.AddWithValue("@descripcion",movimiento.Descripcion);
        comando.Parameters.AddWithValue("@id",movimiento.Id);
        comando.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        string sql = "DELETE FROM movimientos WHERE id = @id";
        using MySqlConnection conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();
        using MySqlCommand comando = new MySqlCommand (sql,conexion);
        comando.Parameters.AddWithValue("@id",id);
        comando.ExecuteNonQuery();
    }

    private Movimiento LeerMovimientos(MySqlDataReader lector)
    {
        Movimiento movimiento = new Movimiento();

        movimiento.Id = lector.GetInt32(0);
        movimiento.Monto = lector.GetInt32(1);
        movimiento.TipoMovimiento = Enum.Parse<TipoMovimiento>(lector.GetString(2));
        movimiento.Descripcion = lector.GetString(3);

        return movimiento;
    }

}