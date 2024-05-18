using Hello_OpenTK.Componentes;
using OpenTK.Mathematics;
using Hello_OpenTK.Math;
using Newtonsoft.Json.Serialization;

namespace Hello_OpenTK.Renderer
{
    public class Actions
    {
        private float TimeDiference;
        private float elapsedTime;
        private float initime;
        private Vector currentPosition;
        private Vector speedRotation;
        public float Endtime;

        public List<Polinomio> Polinomio { get; set; }

        public Actions(List<Polinomio> pol, float time_0 = 0.0f, float endtime = 0.0f, float timediference = 0.0f) 
        {
            Polinomio = pol;
            elapsedTime = 0.0f;
            initime = time_0;
            Endtime = endtime;
            TimeDiference = timediference;
            speedRotation = new Vector(0, 0, 0);
        }

        public void GetSpeedRotation(Vector speed)
        {
            speedRotation = speed;
        }

        public void Update(float deltaTime, ITriangle Objeto)
        {
            elapsedTime += deltaTime;
            if (elapsedTime >= initime && elapsedTime <= Endtime)
            {
                currentPosition.X = Polinomio[0].GetPol(elapsedTime - TimeDiference) + Objeto.FirstPosition.X;
                currentPosition.Y = Polinomio[1].GetPol(elapsedTime - TimeDiference) + Objeto.FirstPosition.Y;
                currentPosition.Z = Polinomio[2].GetPol(elapsedTime - TimeDiference) + Objeto.FirstPosition.Z;
                Objeto.SetTranslation(currentPosition);
                Objeto.SetRotation(speedRotation * (elapsedTime - TimeDiference));
            }
        }

        public void Reset()
        {
            elapsedTime = 0.0f;
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

