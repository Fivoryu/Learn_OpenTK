using Hello_OpenTK.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_OpenTK.Renderer
{
    public struct SetActions
    {
        public static Actions Ac1 ()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float>{0.0f, -1.75f}),
                new Polinomio(new List<float> {0.0f, 0.0f, -1.125f }),
                new Polinomio(new List<float> {0.0f, 0.0f }),
            };

            Actions act1 = new Actions(polinomios,0.0f, 2.0f);
            act1.GetSpeedRotation(new Vector(0.0f, 0.0f, 540.0f));

            return act1;
        }

        public static Actions Ac2 ()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float>{-1.8928568f, -0.6964288f, -0.0535714f}),
                new Polinomio(new List<float> {-11.25f, 4.125f, -0.375f }),
                new Polinomio(new List<float> {0.0f, 0.0f }),
            };

            Actions act1 = new Actions(polinomios, 2.0f, 6.0f);
            act1.GetSpeedRotation(new Vector(0.0f, 0.0f, 540.0f));

            return act1;
        }

        public static Actions Ac3()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float>{ -8.0f}),
                new Polinomio(new List<float> {0.0f, -0.25f}),
                new Polinomio(new List<float> {0.0f, 0.0f }),
            };

            Actions act1 = new Actions(polinomios, 6.0f, 8.0f, 6.0f);
            act1.GetSpeedRotation(new Vector(0.0f));

            return act1;
        }

        public static Actions RightUpAct()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float>{ 0.0f, 12.0f}),
                new Polinomio(new List<float> {0.0f, 3.0f}),
                new Polinomio(new List<float> {0.0f, 0.0f }),
            };

            Actions act1 = new Actions(polinomios, 8.0f, 12.0f, 8.0f);
            act1.GetSpeedRotation(new Vector(540.0f, 0.0f, 0.0f));

            return act1;
        }

        public static Actions RightDownAct()
        {
           List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float>{ 0.0f, 12.0f}),
                new Polinomio(new List<float> {0.0f, -3.0f}),
                new Polinomio(new List<float> {0.0f, 0.0f }),
            };

            Actions act1 = new Actions(polinomios, 8.0f, 12.0f, 8.0f);
            act1.GetSpeedRotation(new Vector(540.0f, 0.0f, 0.0f));

            return act1;
        }

        public static Actions LeftUpAct()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float> {0.0f, -12.0f}),
                new Polinomio(new List<float> {0.0f, 3.0f}),
                new Polinomio(new List<float> {0.0f, 0.0f}),
            };

            Actions act1 = new Actions(polinomios, 8.0f, 12.0f, 8.0f);
            act1.GetSpeedRotation(new Vector(540.0f, 0.0f, 0.0f));

            return act1;
        }

        public static Actions LeftDownAct()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float> {0.0f, -12.0f}),
                new Polinomio(new List<float> {0.0f, -3.0f}),
                new Polinomio(new List<float> {0.0f, 0.0f}),
            };

            Actions act1 = new Actions(polinomios, 8.0f, 12.0f, 8.0f);
            act1.GetSpeedRotation(new Vector(540.0f, 0.0f, 0.0f));

            return act1;
        }

        public static Actions RightScreenAct()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float>{ 0.0f, 24.0f}),
                new Polinomio(new List<float> {0.0f}),
                new Polinomio(new List<float> {0.0f, -24.0f }),
            };

            Actions act1 = new Actions(polinomios, 8.0f, 12.0f, 8.0f);
            act1.GetSpeedRotation(new Vector(540.0f, 0.0f, 0.0f));

            return act1;
        }

        public static Actions LeftScreenAct()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float>{ 0.0f, -24.0f}),
                new Polinomio(new List<float> {0.0f}),
                new Polinomio(new List<float> {0.0f, -24.0f }),
            };

            Actions act1 = new Actions(polinomios, 8.0f, 12.0f, 8.0f);
            act1.GetSpeedRotation(new Vector(540.0f, 0.0f, 0.0f));

            return act1;
        }

        public static Actions RightBackAct()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float>{ 0.0f, 24.0f}),
                new Polinomio(new List<float> {0.0f}),
                new Polinomio(new List<float> {0.0f, 24.0f }),
            };

            Actions act1 = new Actions(polinomios, 8.0f, 12.0f, 8.0f);
            act1.GetSpeedRotation(new Vector(540.0f, 0.0f, 0.0f));

            return act1;
        }

        public static Actions LeftBackAct()
        {
            List<Polinomio> polinomios = new List<Polinomio>
            {
                new Polinomio(new List<float>{ 0.0f, -24.0f}),
                new Polinomio(new List<float> {0.0f}),
                new Polinomio(new List<float> {0.0f, 24.0f}),
            };

            Actions act1 = new Actions(polinomios, 8.0f, 12.0f, 8.0f);
            act1.GetSpeedRotation(new Vector(540.0f, 0.0f, 0.0f));

            return act1;
        }

    }
}
