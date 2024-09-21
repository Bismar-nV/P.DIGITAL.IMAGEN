#include <iostream>
#include <vector>
#include <string>

using namespace std;

class Jugador {
public:
    string nombre;
    int puntaje;

    Jugador(string nombre, int puntaje) : nombre(nombre), puntaje(puntaje) {}
};

class AdministracionUsuarios {
private:
    vector<Jugador> listaJugadores;

public:
    void registrarJugador(string nombre, int puntaje) {
        Jugador nuevoJugador(nombre, puntaje);
        listaJugadores.push_back(nuevoJugador);
        cout << "Jugador registrado: " << nombre << " con puntaje de " << puntaje << endl;
    }

    void mostrarJugadores() {
        if (listaJugadores.empty()) {
            cout << "No hay jugadores en la lista." << endl;
            return;
        }

        cout << "\nListado de jugadores:" << endl;
        for (int i = 0; i < listaJugadores.size(); i++) {
            cout << i + 1 << ". Nombre: " << listaJugadores[i].nombre << ", Puntaje: " << listaJugadores[i].puntaje << endl;
        }
    }

    void incrementarPuntaje(int indice, int puntos) {
        if (indice >= 0 && indice < listaJugadores.size()) {
            listaJugadores[indice].puntaje += puntos;
            cout << "Puntaje incrementado para " << listaJugadores[indice].nombre << ". Puntaje actual: " << listaJugadores[indice].puntaje << endl;
        }
        else {
            cout << "Índice fuera de rango." << endl;
        }
    }

    void reducirPuntaje(int indice, int puntos) {
        if (indice >= 0 && indice < listaJugadores.size()) {
            listaJugadores[indice].puntaje -= puntos;
            cout << "Puntaje reducido para " << listaJugadores[indice].nombre << ". Puntaje actual: " << listaJugadores[indice].puntaje << endl;
        }
        else {
            cout << "Índice fuera de rango." << endl;
        }
    }
};

int main() {
    AdministracionUsuarios sistema;
    bool enEjecucion = true;

    while (enEjecucion) {
        cout << "\033[2J\033[1;1H"; // Limpia la consola

        cout << "\nSistema de Administración de Jugadores:" << endl;
        cout << "1. Registrar Jugador" << endl;
        cout << "2. Mostrar Jugadores" << endl;
        cout << "3. Añadir Puntos" << endl;
        cout << "4. Restar Puntos" << endl;
        cout << "5. Salir del Sistema" << endl;
        cout << "Elija una opción: ";
        int opcion;
        cin >> opcion;

        string nombre;
        int puntaje;
        int indice;

        switch (opcion) {
        case 1:
            cout << "Introduce el nombre del jugador: ";
            cin >> nombre;
            cout << "Introduce el puntaje del jugador: ";
            cin >> puntaje;
            sistema.registrarJugador(nombre, puntaje);
            break;

        case 2:
            sistema.mostrarJugadores();
            break;

        case 3:
            cout << "Introduce el número del jugador para añadir puntos: ";
            cin >> indice;
            cout << "Cantidad de puntos a añadir: ";
            cin >> puntaje;
            sistema.incrementarPuntaje(indice - 1, puntaje);
            break;

        case 4:
            cout << "Introduce el número del jugador para restar puntos: ";
            cin >> indice;
            cout << "Cantidad de puntos a restar: ";
            cin >> puntaje;
            sistema.reducirPuntaje(indice - 1, puntaje);
            break;

        case 5:
            enEjecucion = false;
            cout << "Cerrando el sistema..." << endl;
            break;

        default:
            cout << "Opción no válida, intenta de nuevo." << endl;
            break;
        }

        cout << "\nPresiona cualquier tecla para continuar...";
        cin.ignore();
        cin.get();
    }

    return 0;
}
