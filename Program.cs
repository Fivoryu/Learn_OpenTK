using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace Hello_OpenTK 
{
    public class Program
    {

        private static void Main()
        {

            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(1280, 600),
                Title = "Hello OpenTK",
            };

            using (var window = new Game(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}



// Tres clases, un televisor, un florero arriba del televisor, equipo de sonido
// Instancias que contenga una clase generica
// Lista de objetos, lista de partes, lista de caras, lista de puntos
// Escenario lista de objetos, objeto lista de caras, caras lista de puntos
// Lista hash, Dictionary
// Centro de masa en la clase
// Crear una interfaz
// Instruccion OpenGL, nop

// Simualar que alguien lanza una pelota y rebota hasta entrar al florero
// Sin importar el angulo
// Se tiene un escenario de n Objetos
// En una animacion se aplican ciertas transformaciones
// Hacer en paralelo que el objeto hagan ciertas transformaciones
// Usar una seria de hilos o subprocesos
// Hay dos maneras
// 1 Con hilos
// 1 Solo subproceso
// Asignar un tiempo a cada objeto
// La animacion es un libreto
// Crear una estructura que tenga una lista de acciones o movimientos
// No es la accion completo, sino una parte de la accion
// Lista de acciones <0,0,0,0,0>
// Se ejecuta la lista uno por uno
// Solo se hace un pedazo de la accion
// La lista de acciones contiene una pequena aninmacion
// La lista tiene los metodos de traslacion, rotacion y scalado al mismo tiempo
// Una accion puede tener una sola transformacion o varias transformaciones
// Si se quiere que se haga de forma dinamica se requiere un planificador
// 1. Quiero que un objeto se traslade a un punto
// La velocidad de la animacion es distancia sobre tiempo
// Construir una estructura de datos de lista de acciones
// Luego quiero hacer un proceso de movimiento
// Poder mover objetos al mismo tiempo
// Que va a tener animcion una lista de acciones
// lista de acciones
// Craer un controlador que recorra la lista 
// Si no tiene animacion no se ejecuta
// Boton de play, pause, resume
// Play se ejecuta la accion
// Pause se pausa la accion
// Resume la animacion sigue
// Siguiente clase lo mismo que el anterior
// La accion se termina cuando el tiempo se termina
// Crear clase ejecutor que ejecuta las animacioens