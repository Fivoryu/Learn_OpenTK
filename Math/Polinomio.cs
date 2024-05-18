using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.ApplicationServices;
using OpenTK.Mathematics;

namespace Hello_OpenTK.Math
{
    public class Polinomio
    {
        private List<float> Coeficiente {  get; set; }
        public Polinomio(List<float> coef) 
        {
            Coeficiente = new List<float>();
            Coeficiente.AddRange(coef);
        }

        public void SetPol(List<float> coef)
        {
            Coeficiente.AddRange(coef);
        }

        public float GetPol(float X)
        {
            float Y = 0;

            for (int i = 0; i < Coeficiente.Count; i++)
            {
                Y += Coeficiente[i] * (float)MathF.Pow(X, i);
            }
            
            return Y;
        }


    }
}
