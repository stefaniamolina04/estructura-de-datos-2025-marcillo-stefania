// Programa para verificar si una f�rmula matem�tica est� balanceada
// y resolver el problema de las Torres de Hanoi usando pilas
using System;
using System.Collections.Generic;

class Program
{
	// M�todo para verificar si una f�rmula matem�tica est� balanceada
	public static bool IsBalanced(string formula)
	{
		Stack<char> stack = new Stack<char>();

		// Recorrer cada car�cter en la f�rmula
		foreach (char c in formula)
		{
			// Si encontramos un par�ntesis, corchete o llave de apertura, lo apilamos
			if (c == '(' || c == '[' || c == '{')
			{
				stack.Push(c);
			}
			// Si encontramos uno de cierre, verificamos el balance
			else if (c == ')' || c == ']' || c == '}')
			{
				// Si la pila est� vac�a, no est� balanceado
				if (stack.Count == 0)
				{
					return false;
				}

				// Sacamos el elemento de la pila
				char top = stack.Pop();

				// Comprobamos que coincida con el car�cter de cierre
				if ((c == ')' && top != '(') ||
					(c == ']' && top != '[') ||
					(c == '}' && top != '{'))
				{
					return false;
				}
			}
		}

		// Si la pila est� vac�a al final, la f�rmula est� balanceada
		return stack.Count == 0;
	}

	// M�todo para resolver las Torres de Hanoi usando pilas
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

			// Mover el disco m�s grande de la pila fuente a la pila objetivo
			target.Push(source.Pop());
			Console.WriteLine($"Mover disco de {GetStackName(source)} a {GetStackName(target)}");

			// Mover los n-1 discos de la pila auxiliar a la pila objetivo usando la pila fuente
			SolveTowersOfHanoi(n - 1, auxiliary, target, source);
		}
	}

	// M�todo auxiliar para obtener el nombre de la pila
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
		// Verificaci�n de f�rmula balanceada
		Console.WriteLine("Ingrese la f�rmula matem�tica:");
		string formula = Console.ReadLine();

		if (IsBalanced(formula))
		{
			Console.WriteLine("F�rmula balanceada.");
		}
		else
		{
			Console.WriteLine("F�rmula no balanceada.");
		}

		// Soluci�n de las Torres de Hanoi
		Console.WriteLine("\nIngrese el n�mero de discos para las Torres de Hanoi:");
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
