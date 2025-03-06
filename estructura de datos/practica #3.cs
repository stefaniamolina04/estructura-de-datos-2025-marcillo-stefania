#include <iostream>
#include <map>
#include <set>
#include <string>
#include <chrono> // Para medir tiempo de ejecución

// Mapa que almacena equipos y sus jugadores
map<string, set<string>> torneo;

// Función para agregar un equipo
void agregarEquipo(const string& equipo)
{
    if (torneo.find(equipo) == torneo.end())
    {
        torneo[equipo] = set<string>();
        cout << "Equipo '" << equipo << "' agregado.\n";
    }
    else
    {
        cout << "El equipo ya existe.\n";
    }
}

// Función para agregar un jugador a un equipo
void agregarJugador(const string& equipo, const string& jugador)
{
    if (torneo.find(equipo) != torneo.end())
    {
        torneo[equipo].insert(jugador); // Se usa set para evitar duplicados
        cout << "Jugador '" << jugador << "' agregado al equipo '" << equipo << "'.\n";
    }
    else
    {
        cout << "El equipo no existe.\n";
    }
}

// Función para mostrar los equipos y sus jugadores
void mostrarEquipos()
{
    cout << "\n=== Equipos y Jugadores ===\n";
    for (const auto& [equipo, jugadores] : torneo) {
        cout << "Equipo: " << equipo << "\nJugadores: ";
        for (const string&jugador : jugadores) {
            cout << jugador << " ";
        }
        cout << "\n-------------------------\n";
    }
}

// Función para buscar un jugador en los equipos
void buscarJugador(const string& jugador)
{
    for (const auto& [equipo, jugadores] : torneo) {
        if (jugadores.find(jugador) != jugadores.end())
        {
            cout << "El jugador '" << jugador << "' está en el equipo '" << equipo << "'.\n";
            return;
        }
    }
    cout << "Jugador no encontrado.\n";
}

// Función principal
int main()
{
    auto start = high_resolution_clock::now(); // Iniciar medición de tiempo

    // Agregar equipos y jugadores
    agregarEquipo("Leones");
    agregarEquipo("Águilas");

    agregarJugador("Leones", "Juan");
    agregarJugador("Leones", "Pedro");
    agregarJugador("Águilas", "Carlos");

    // Mostrar equipos y jugadores
    mostrarEquipos();

    // Buscar jugador
    buscarJugador("Juan");

    auto end = high_resolution_clock::now(); // Fin de medición de tiempo
    auto duration = duration_cast<microseconds>(end - start);
    cout << "Tiempo de ejecución: " << duration.count() << " microsegundos.\n";

    return 0;
}
