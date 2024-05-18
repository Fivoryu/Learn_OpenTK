using Hello_OpenTK.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_OpenTK.Renderer
{
    public class Animation
    {
        private List<Actions> actions;
        private List<ITriangle> objetos;
        private Thread animationThread;
        private bool isAnimating;
        private float deltaTime;
        private bool isPaused;
        private readonly object pauseLock = new object();

        public Animation(List<Actions> actions, List<ITriangle> objetos)
        {
            if (actions.Count != objetos.Count)
            {
                throw new ArgumentException("La cantidad de acciones debe ser igual a la cantidad de objetos");
            }

            this.actions = actions;
            this.objetos = objetos;
            this.isAnimating = false;
            this.isPaused = false;
        }

        public void Start(float deltaTime)
        {
            if (!isAnimating)
            {
                this.deltaTime = deltaTime;
                isAnimating = true;
                isPaused = false;
                animationThread = new Thread(() => Animate(deltaTime));
                animationThread.Start();
            }
        }

        public void Stop()
        {
            isAnimating = false;
            if (animationThread != null && animationThread.IsAlive)
            {
                animationThread.Join();
            }
        }

        public void Resume()
        {
            lock (pauseLock)
            {
                isPaused = false;
                Monitor.PulseAll(pauseLock);
            }
        }

        public void Pause()
        {
            lock (pauseLock)
                isPaused = true;
        }

        private void Animate(float deltaTime)
        {
            while (isAnimating)
            {
                lock (pauseLock)
                {
                    while (isPaused)
                    {
                        Monitor.Wait(pauseLock);
                    }
                }
                for (int i = 0; i < actions.Count; i++)
                {
                    actions[i].Update(deltaTime, objetos[i]);
                }
                Thread.Sleep((int)(deltaTime * 1000));
            }
        }

        public void Reset()
        {
            foreach (var action in actions)
            {
                action.Reset();
            }
        }
    }
}
