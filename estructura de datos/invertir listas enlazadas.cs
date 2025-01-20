class Program
{
	static void Main(string[] args)
	{
		ListaEnlazada lista = new ListaEnlazada();

		// Agregar elementos a la lista
		lista.Cabeza = new Nodo(1);
		lista.Cabeza.Siguiente = new Nodo(2);
		lista.Cabeza.Siguiente.Siguiente = new Nodo(3);

		// Calcular longitud
		Console.WriteLine("Longitud de la lista: " + lista.CalcularLongitud());

		// Invertir la lista
		lista.Invertir();

		// Mostrar elementos después de invertir
		Nodo actual = lista.Cabeza;
		Console.WriteLine("Lista invertida:");
		while (actual != null)
		{
			Console.WriteLine(actual.Valor);
			actual = actual.Siguiente;
		}
	}
}
