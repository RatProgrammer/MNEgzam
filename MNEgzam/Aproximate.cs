using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNEgzam
{
    class Aproximate
    {
        private double[,] A;
        private double[,] S;
        private double[,] T;
        private double[,] X;
        private double[,] Y;

        public double[,] LeastSquares(double[] X, double[] Y, int w,int n)
        {
            A = new double[w + 1,1];
            S=new double[w+1,w+1];
            T=new double[w+1,1];
            double sumaS = 0;
            double sumaT = 0;
            for (int k = 0; k<=w; k++)//w - stopień wielomianu którym aproksymujemy
            {
                for (int i = 0; i <=w; i++)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        sumaS += (Math.Pow(X[j], k+i));
                    }
                    S[i, k] = sumaS;
                }
            }
            for (int k = 0; k < w; k++)
            {
                for (int j = 0; j < n; j++)
                {
                    sumaT += (Math.Pow(X[j], k)*Y[j]);
                }
                T[k, 0] = sumaT;
            }
            Matrix inverseMatrix=new Matrix();
            double[,] sodwr = inverseMatrix.InverseMatrix(S, n, n);
            A = inverseMatrix.MultiplyMatrix(sodwr, T, n, n, n, n);

            return A;
        }

        public void FourierRowMethod(int n, double [] X,double []Y,out double A,out double [,] B, out double [,] C)
        {
            double w;
             A = 0;
             B=new double[n,1];
             C=new double[n,1];
            double sumaA = 0, sumaB, sumaC;
            w = (Math.PI*2)/n;

            for (int i = 0; i < n; i++)
            {
                sumaA += Y[i];
            }
            A = sumaA/n;
            for (int k = 0; k < n; k++)
            {
                sumaB = 0;
                sumaC = 0;
                for (int i = 0; i < n; i++)
                {
                    sumaB += Math.Cos((k + 1)*w*X[i])*Y[i];
                    sumaC += Math.Sin((k + 1)*w*X[i])*Y[i];
                }
                B[k,0] = (2*sumaB)/n;
                C[k,0] = (2*sumaC)/n;
            }


        }
    }
}
