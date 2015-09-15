using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNEgzam
{
    internal class Matrix
    {
        private double[,] A;
        private double[,] B;

        public double[,] TransposeMatrix(double[,] A, int m, int n)
        {
            double[,] AT = new double[n, m];
            for (int i = 0; i + 1 < m; i++)
            {

                for (int j = 0; j - 1 < n; j++)
                {
                    AT[i, j] = A[j, i];
                    Console.WriteLine();
                    Console.Write(AT[i, j]);
                }

                Console.WriteLine();
            }
            return AT;
        }

        public double[,] MultiplyMatrix(double[,] A, double[,] B, int mA, int nA, int mB, int nB)
        {

            if (nA == mB)
            {
                double[,] C = new double[mA, nB];
                for (int i = 0; i < mA; i++)
                {
                    for (int k = 0; k < nB; k++)
                    {
                        for (int j = 0; j < nA; j++)
                        {
                            C[i, k] += A[i, j]*B[j, k];


                        }
                        Console.WriteLine();
                        Console.Write(C[i, k]);
                    }
                    Console.WriteLine();
                }
                return C;
            }
            return null;
        }

        public double DetCounter(double[,] A, int m, int n)
        {
            double[,] U;
            double[,] L;
            LuCompozition(A, n, m, out L, out U);
            double det = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        det *= U[i, j];
                    }
                   
                }
            }
            return det;
        }


        public void LuCompozition(double[,] A, int n, int m, out double[,] L, out double[,] U)
        {
            L = new double[n, n];
            U = new double[n, n];
            if (m == n)
            {

                double sumaU ;
                double sumaL;
               
                for (int i = 0; i < n; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        L[i, i] = 1;
                        U[0, i] = A[0, i];
                        L[j, 0] = A[j, 0]/A[0, 0];
                    }

                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        
                        sumaU = 0;
                        if (i <= j)
                        {
                            for (int k = 0; k < i; k++)
                            {

                                sumaU += L[i, k]*U[k, j];

                            }
                            U[i, j] = A[i, j] - sumaU;
                        }

                        sumaL = 0;
                        if (i < j)
                        {
                            for (int k = 0; k < i ; k++)
                            {

                                sumaL += L[j, k]*U[k, i];

                            }
                            L[j, i] = (A[j, i] - sumaL)/U[i, i];

                        }



                    }

                }

            }
            else
            {
                throw new ArgumentException();
            }
        }

        public double[,] InverseMatrix(double[,] A,int m, int n)
        {
            double[,] U;
            double[,] L;
            LuCompozition(A, n, m, out L, out U);
            double[,] e=new double[n,n];
            double [,] y=new double[n,n];
            double [,] x=new double[n,n];
            double sumaL = 0;
            double sumaU = 0;
            for (int i = 0; i < n; i++) // tworzenie macierzy jednostkowej e
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        e[i, j] = 1;
                    }
                }
            }
            for (int i = 0; i < n; i++)//wyepłnienie macierzy y pierwszym wierszem mac e - zawsze!
            {
                y[0, i] = e[0, i];
            }
            for (int i = 1; i < n; i++)//wyznaczenie y
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        sumaL += L[i, k]*y[k, j];
                    }
                    y[i, j] = e[i, j] - sumaL;
                    sumaL = 0;
                }
            }
            for (int i = 0; i <n; i++)//wypełnienie ostatniego wiersza mac x
            {
                x[n-1, i] = y[n-1, i]/U[n-1, n-1];
            }
            for (int i = n-2; i >=0; i--)
            {
                if(i < 0)
                    break;
                for (int j = 0; j < n; j++)
                {
                    for (int k = i; k < n; k++)
                    {
                        sumaU += x[k, j]*U[i, k];
                    }
                    x[i, j] =(y[i, j] - sumaU)/U[i, i];
                    sumaU = 0;
                }
            }

           return x;

        }
    }



}

    

