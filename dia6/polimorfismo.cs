List<Tarjeta> tarjetas = new List<Tarjeta>();
tarjetas.Add(new Tarjeta("Lucia"));
tarjetas.Add(new TarjetaEstudiante("Mateo"));
tarjetas.Add(new Tarjeta("Rosa"));

foreach (Tarjeta tarjeta in tarjetas)
{
    tarjeta.Recargar(10000);
    tarjeta.Pagar(3400);
    Console.WriteLine($"{tarjeta.Titular} ({tarjeta.GetType().Name} Saldo: {tarjeta.Saldo})");
    Console.WriteLine("=======================");
}


class Tarjeta
{
    private int _saldo ;
    public string Titular;

    
    public int Saldo
    {
        get{return _saldo;}
    }
    public Tarjeta(string titular)
    {
        Titular = titular;
    }

    public void Recargar (int monto)
    {
        
        if (monto < 0)
        {
            Console.WriteLine("La recarga ("+ monto +") debe ser mayor a cero");
        }
        else
        {
            Console.WriteLine("Recargar: "+monto);
            _saldo += monto;            
        }
        
    }
    public virtual bool Pagar(int monto)
    {
        Console.WriteLine("Pagar: "+monto);

        if (monto > _saldo)
        {
            Console.WriteLine("Saldo insuficiente");
            return false;
        }
        else
        {
            Console.WriteLine("Pago exitoso");
            _saldo -= monto;
            return true;    
        }        
        
    }

}
class TarjetaEstudiante : Tarjeta
{
    public TarjetaEstudiante(string titular ):base(titular)
    {
        
    }
    public override bool Pagar(int monto)
    {
        return base.Pagar(monto/2);
    }

}