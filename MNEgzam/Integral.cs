using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNEgzam
{
    class Integral
    {
        public double Trapez(double[] X, double [] Y,int n)
        {
            double h = X[1] - X[0];
            double integral;
            double sum1 = (Y[0] + Y[n])/2;
            double sum2=0;
            for (int i = 1; i < n; i++)
            {
                sum2 += Y[i];
            }
            integral = h*(sum1 + sum2);
            return integral;
        }

        public double Parabola(double[] X, double[] Y, int n)
        {
            double h = X[1] - X[0];
            double integral;
            double sum1 = Y[0] + Y[n];
            double sum2 = 0;
            double sum3 = 0;
            for (int i = 1; i < n; i += 2)//pętla po wyrazach nieparzystych
            {
                sum2 += Y[i];
            }
            for (int i = 2; i < n; i += 2)
            {
                sum3 += Y[i];
            }
            integral = (h*(sum1 + (4*sum2) + (2*sum3)))/3;
            return integral;
        }
    }
}
