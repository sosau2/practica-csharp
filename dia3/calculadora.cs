
double CalcularSubTotal(double precio, int cantidad)
{
    return (precio*cantidad);
}
double AplicarDescuento(double subtotal,double porcentaje)
{    
    return ((subtotal -( subtotal*(porcentaje/100))));
}



Console.WriteLine("==== Calcular Sub Total ====");
Console.WriteLine("Ingrese el precio");
double precio =  Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Ingrese la cantidad");
int cantidad = Convert.ToInt32(Console.ReadLine());
double subtotal = CalcularSubTotal(precio,cantidad);
Console.WriteLine("Porcentaje de descuento");
int porcentajeDescuento = Convert.ToInt32(Console.ReadLine());
double conDescuento = AplicarDescuento(subtotal,porcentajeDescuento);

Console.WriteLine("============================");
Console.WriteLine("Subtotal: "+subtotal + " Gs.");
Console.WriteLine("Descuento [" + porcentajeDescuento  +"%] : - "+(subtotal-conDescuento) + " Gs.");
Console.WriteLine("Con Descuento: "+conDescuento + " Gs.");
Console.WriteLine("============================");
