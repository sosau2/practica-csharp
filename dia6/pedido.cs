Cliente cliente = new Cliente("Lucia Benitez","0981 123 123");
//cliente.Presentarse();
//Console.WriteLine($"Teléfono:{cliente.Telefono}");


Producto gaseosa = new Producto("Gaseosa 500ml",6000);
Producto alfajor = new Producto("Alfajor",3500);

Pedido pedido = new Pedido(cliente);
pedido.Agregar(gaseosa,3);
pedido.Agregar(alfajor,2);
pedido.Mostrar();




class Persona
{
    public string Nombre {get;}
    public Persona(string nombre){

        Nombre = nombre;
        
    }

    public void Presentarse()
    {
        Console.WriteLine($"Hola, soy {Nombre}.");
    }
}

class Cliente : Persona
{
    public string Telefono{get;}

    public Cliente(string nombre,string telefono):base(nombre)
    {
        Telefono = telefono;
    }
}

class Producto
{
    public string Nombre {get;}
    public double Precio {get;}

    public Producto(string nombre,double precio)
    {
        Nombre = nombre;
        Precio = precio;
    }
}



class PedidoDetalle
{
    public Producto Producto{get;}
    public int Cantidad {get;}

    public PedidoDetalle(Producto producto,int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }
    public double SubTotal()
    {
        return Producto.Precio * Cantidad;
    }
}

class Pedido
{
    public Cliente Cliente {get;}
    private List<PedidoDetalle> _detalle = new List<PedidoDetalle>();

    public Pedido(Cliente cliente)
    {
        Cliente = cliente;
    }

    public void Agregar(Producto producto , int cantidad)
    {
        _detalle.Add(new PedidoDetalle(producto,cantidad));
    }

    public double Total()
    {
        double suma = _detalle.Sum(d =>
        {
            return d.SubTotal();
        });
        return suma;

    }
    public void Mostrar()
    {
        Console.WriteLine("+"+"=".PadRight(36,'=')+"+");
        Console.WriteLine($"Pedido de cliente: {Cliente.Nombre}");
        foreach (PedidoDetalle linea in _detalle)
        {
            Console.WriteLine($"{linea.Cantidad}x{linea.Producto.Precio.ToString("N0")}  {linea.Producto.Nombre.PadRight(18)}={linea.SubTotal().ToString("N0")}Gs.");

        }
        Console.WriteLine("+"+"=".PadRight(36,'=')+"+");
        Console.WriteLine($"Total:".PadRight(28)+$"{Total().ToString("N0")}Gs.");
        Console.WriteLine("+"+"=".PadRight(36,'=')+"+");
    }

}