using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Hello_OpenTK
{
    public static class Program
    {
        private static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(800, 600),
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