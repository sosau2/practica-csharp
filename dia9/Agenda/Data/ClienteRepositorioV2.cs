
using Agenda.Models;
using MySqlConnector;
//namespace
namespace Agenda.Data;
public class ClienteRepositorioV2
{
    private readonly string _cadenaConexion ;
    
    // El constructor del repositorio recibe la cadena de conexion y la guarda
    // en _cadenaConexion
    public ClienteRepositorioV2(string cadenaConexion)
    {
        //ver como arreglar null warning
        string _cadenaConexion = cadenaConexion;
    }
    public List<Cliente> ObtenerTodos()
    {
        //debe retornar lista de clientes
        //1 - crear lista vacia
        List<Cliente> clientes = new List<Cliente>();
        //2 - Crear conexion sql
        using MySqlConnection conexion = new MySqlConnection(_cadenaConexion);
        //3 - abrir conexion
        conexion.Open();
        //4 - crear query sql
        string sql = "SELECT id, nombre, telefono, ciudad FROM clientes ORDER BY nombre";
        //5 - crear MySqlCommand 
        using MySqlCommand comando = new MySqlCommand(sql,conexion);
        //6 - crear data reader
        using MySqlDataReader lector = comando.ExecuteReader();
        

    }
}