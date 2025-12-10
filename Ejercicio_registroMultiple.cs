using System;
using System.Collections.Generic;

public class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }

    public void MostrarInfo()
    {
        string estado = Stock > 0 ? "En stock" : "Agotado";
        Console.WriteLine($"Nombre: {Nombre} | Precio: ${Precio:F2} | Stock: {Stock} | Estado: {estado}");
    }
}

public class Program
{
    public static void Main()
    {
        List<Producto> productos = new List<Producto>();

        int cantidad;
        do
        {
            Console.Write("¿Cuántos productos desea registrar? (≥ 1): ");
        } while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 1);

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\n--- Producto {i + 1} ---");

            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();

            double precio;
            do
            {
                Console.Write("Precio del producto (número positivo): ");
            } while (!double.TryParse(Console.ReadLine(), out precio) || precio <= 0);

            int stock;
            do
            {
                Console.Write("Stock (entero ≥ 0): ");
            } while (!int.TryParse(Console.ReadLine(), out stock) || stock < 0);

            productos.Add(new Producto
            {
                Nombre = nombre,
                Precio = precio,
                Stock = stock
            });
        }

        Console.WriteLine("\n--- Lista de productos registrados ---");
        foreach (var producto in productos)
        {
            producto.MostrarInfo();
        }
    }
}
