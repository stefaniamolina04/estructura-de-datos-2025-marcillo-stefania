public class Nodo
{
    public int Valor;
    public Nodo Siguiente;

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    public Nodo Cabeza;

    public ListaEnlazada()
    {
        Cabeza = null;
    }

    // M�todo para calcular el n�mero de elementos
    public int CalcularLongitud()
    {
        int contador = 0;
        Nodo actual = Cabeza;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }
}
