#include <iostream>
#include <vector>
#include <string>

using namespace std;

class Jugador {
public:
    string nombre;
    int puntaje;

    Jugador(string nombre, int puntaje) {
        this->nombre = nombre;
        this->puntaje = puntaje;
    }
};

class AdministradorJugadores {
private:
    vector<Jugador> jugadores;

public:
    void registrarJugador(string nombre, int puntaje) {
        Jugador nuevoJugador(nombre, puntaje);
        jugadores.push_back(nuevoJugador);
        cout << "Jugador registrado: " << nombre << " con puntaje " << puntaje << endl;
    }

    void mostrarJugadores() {
        if (jugadores.empty()) {
            cout << "No hay jugadores registrados." << endl;
            return;
        }

        cout << "\nLista de jugadores:" << endl;
        for (int i = 0; i < jugadores.size(); i++) {
            cout << i + 1 << ". Nombre: " << jugadores[i].nombre << ", Puntaje: " << jugadores[i].puntaje << endl;
        }
    }

    void ajustarPuntaje(int indice, int puntaje) {
        if (indice >= 0 && indice < jugadores.size()) {
            jugadores[indice].puntaje += puntaje;
            cout << "Puntaje actualizado para " << jugadores[indice].nombre << ". Nuevo puntaje: " << jugadores[indice].puntaje << endl;
        }
        else {
            cout << "Índice no válido." << endl;
        }
    }

    void eliminarJugador(int indice) {
        if (indice >= 0 && indice < jugadores.size()) {
            cout << "Jugador eliminado: " << jugadores[indice].nombre << endl;
            jugadores.erase(jugadores.begin() + indice);
        }
        else {
            cout << "Índice no válido." << endl;
        }
    }
};

int main() {
    AdministradorJugadores admin;
    bool enEjecucion = true;

    while (enEjecucion) {
        // Limpieza de pantalla (funciona en la mayoría de los sistemas UNIX y Windows).
        cout << "\033[2J\033[1;1H";

        cout << "\nSistema de Administración de Jugadores:" << endl;
        cout << "1. Registrar Jugador" << endl;
        cout << "2. Mostrar Jugadores" << endl;
        cout << "3. Modificar Puntaje" << endl;
        cout << "4. Eliminar Jugador" << endl;
        cout << "5. Salir" << endl;
        cout << "Elija una opción: ";
        int opcion;
        cin >> opcion;

        string nombre;
        int puntaje;
        int indice;

        switch (opcion) {
        case 1:
            cout << "Ingrese el nombre del jugador: ";
            cin >> nombre;
            cout << "Ingrese el puntaje inicial del jugador: ";
            cin >> puntaje;
            admin.registrarJugador(nombre, puntaje);
            break;

        case 2:
            admin.mostrarJugadores();
            break;

        case 3:
            cout << "Ingrese el índice del jugador para modificar el puntaje: ";
            cin >> indice;
            cout << "Ingrese la cantidad de puntos a ajustar (use negativo para restar): ";
            cin >> puntaje;
            admin.ajustarPuntaje(indice - 1, puntaje);
            break;

        case 4:
            cout << "Ingrese el índice del jugador a eliminar: ";
            cin >> indice;
            admin.eliminarJugador(indice - 1);
            break;

        case 5:
            enEjecucion = false;
            cout << "Cerrando el sistema..." << endl;
            break;

        default:
            cout << "Opción no válida. Intente nuevamente." << endl;
            break;
        }

        cout << "\nPresione Enter para continuar...";
        cin.ignore();
        cin.get();
    }

    return 0;
}
