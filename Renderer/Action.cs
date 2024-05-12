using Hello_OpenTK.Componentes;
using OpenTK.Mathematics;

namespace Hello_OpenTK.Renderer
{
    public struct Action
    {
        static ITriangle Objeto { get; set; }

        public Action(ITriangle objeto)
        {
            Objeto = objeto;
        }

        public void Move(Vector PosFin)
        {
            Objeto.SetTranslation(PosFin);
        }
        public void Rotate(Vector RotFin)
        {
            Objeto.SetRotation(RotFin);
        }
        public void Scale(Vector ScaEnd)
        {
            Objeto.SetScale(ScaEnd);
        }

        static void Action1(Vector PosFin, Vector Dif, double time)
        {
            if (PosFin != Dif)
            {
                Objeto.SetTranslation(PosFin - Dif);
            }
            
        }
    }
}

// Movimiento parabolico 3D
// Px = -3t + t * t
// Py = -2t + 1.5 * t
// Pz = 0.5t * t
// Velocidad
// Vx = -3 + 2t
// Vy = -2 + 3t
// Vz =  0 +  t

