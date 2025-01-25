// Programa para verificar si una fórmula matemática está balanceada
// y resolver el problema de las Torres de Hanoi usando pilas
using System;
using System.Collections.Generic;

class Program
{
	// Método para verificar si una fórmula matemática está balanceada
	public static bool IsBalanced(string formula)
	{
		Stack<char> stack = new Stack<char>();

		// Recorrer cada carácter en la fórmula
		foreach (char c in formula)
		{
			// Si encontramos un paréntesis, corchete o llave de apertura, lo apilamos
			if (c == '(' || c == '[' || c == '{')
			{
				stack.Push(c);
			}
			// Si encontramos uno de cierre, verificamos el balance
			else if (c == ')' || c == ']' || c == '}')
			{
				// Si la pila está vacía, no está balanceado
				if (stack.Count == 0)
				{
					return false;
				}

				// Sacamos el elemento de la pila
				char top = stack.Pop();

				// Comprobamos que coincida con el carácter de cierre
				if ((c == ')' && top != '(') ||
					(c == ']' && top != '[') ||
					(c == '}' && top != '{'))
				{
					return false;
				}
			}
		}

		// Si la pila está vacía al final, la fórmula está balanceada
		return stack.Count == 0;
	}

	// Método para resolver las Torres de Hanoi usando pilas
	public static void SolveTowersOfHanoi(int n, Stack<int> source, Stack<int> target, Stack<int> auxiliary)
	{
		if (n == 1)
		{
			// Caso base: mover un disco de la pila fuente a la pila objetivo
			target.Push(source.Pop());
			Console.WriteLine($"Mover disco de {GetStackName(source)} a {GetStackName(target)}");
		}
		else
		{
			// Mover n-1 discos de la pila fuente a la pila auxiliar usando la pila objetivo
			SolveTowersOfHanoi(n - 1, source, auxiliary, target);

			// Mover el disco más grande de la pila fuente a la pila objetivo
			target.Push(source.Pop());
			Console.WriteLine($"Mover disco de {GetStackName(source)} a {GetStackName(target)}");

			// Mover los n-1 discos de la pila auxiliar a la pila objetivo usando la pila fuente
			SolveTowersOfHanoi(n - 1, auxiliary, target, source);
		}
	}

	// Método auxiliar para obtener el nombre de la pila
	private static string GetStackName(Stack<int> stack)
	{
		if (stack == sourceStack) return "Fuente";
		if (stack == targetStack) return "Destino";
		if (stack == auxiliaryStack) return "Auxiliar";
		return "Desconocido";
	}

	// Variables globales para las pilas de las Torres de Hanoi
	private static Stack<int> sourceStack;
	private static Stack<int> targetStack;
	private static Stack<int> auxiliaryStack;

	static void Main(string[] args)
	{
		// Verificación de fórmula balanceada
		Console.WriteLine("Ingrese la fórmula matemática:");
		string formula = Console.ReadLine();

		if (IsBalanced(formula))
		{
			Console.WriteLine("Fórmula balanceada.");
		}
		else
		{
			Console.WriteLine("Fórmula no balanceada.");
		}

		// Solución de las Torres de Hanoi
		Console.WriteLine("\nIngrese el número de discos para las Torres de Hanoi:");
		int numDisks = int.Parse(Console.ReadLine());

		// Inicializar las pilas
		sourceStack = new Stack<int>();
		targetStack = new Stack<int>();
		auxiliaryStack = new Stack<int>();

		// Llenar la pila fuente con los discos
		for (int i = numDisks; i >= 1; i--)
		{
			sourceStack.Push(i);
		}

		Console.WriteLine("\nMovimientos para resolver las Torres de Hanoi:");
		SolveTowersOfHanoi(numDisks, sourceStack, targetStack, auxiliaryStack);
	}
}
