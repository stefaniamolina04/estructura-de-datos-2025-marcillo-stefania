using System;
using System.Collections.Generic;

class Persona
{
    public string Nombre { get; private set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

class Atraccion
{
    private Queue<Persona> colaEspera = new Queue<Persona>();
    private int capacidadMaxima;
    private List<Persona> asientosOcupados;

    public Atraccion(int capacidad)
    {
        capacidadMaxima = capacidad;
        asientosOcupados = new List<Persona>();
    }

    public void AgregarPersona(Persona persona)
    {
        if (colaEspera.Count + asientosOcupados.Count < capacidadMaxima)
        {
            colaEspera.Enqueue(persona);
            Console.WriteLine($"{persona.Nombre} ha ingresado a la fila de espera.");
        }
        else
        {
            Console.WriteLine($"La atracción está llena. {persona.Nombre} no puede ingresar.");
        }
    }

    public void AsignarAsientos()
    {
        while (asientosOcupados.Count < capacidadMaxima && colaEspera.Count > 0)
        {
            Persona persona = colaEspera.Dequeue();
            asientosOcupados.Add(persona);
            Console.WriteLine($"{persona.Nombre} ha ocupado un asiento.");
        }
    }

    public void MostrarOcupantes()
    {
        Console.WriteLine("\nAsientos ocupados:");
        foreach (var persona in asientosOcupados)
        {
            Console.WriteLine($"- {persona.Nombre}");
        }
    }
}

class Program
{
    static void Main()
    {
        Atraccion atraccion = new Atraccion(30);

        // Simulación de llegada de personas
        for (int i = 1; i <= 35; i++)
        {
            atraccion.AgregarPersona(new Persona($"Persona {i}"));
        }

        // Asignar los asientos en orden de llegada
        atraccion.AsignarAsientos();

        // Mostrar los ocupantes
        atraccion.MostrarOcupantes();
    }
}
