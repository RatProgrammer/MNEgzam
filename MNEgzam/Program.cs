using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNEgzam
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix=new Matrix();
            double[,] A = new double[,] { { 3, 0.6,7.5,-3 }, {0.4, 0.5, 4,-8.5}, {0.3,-1,1,5.2}, {1,0.5,-0.1,0.5} };
            double [,] B=new double[,] { {2,2},{1,4}};
            int m = 4;
            int n = 4;
            //double[,] D=matrix.TransposeMatrix(A, m, n);
            //double[,] C = matrix.MultiplyMatrix(A, B, 2, 2, 2, 2);

            double[,] U;
            double[,] L;
            //matrix.LuCompozition(A, n, m, out L, out U);
            //double det =matrix.DetCounter(A, m, n);
           // Console.WriteLine(det);
            double[,] C=matrix.InverseMatrix(A, m, n);
           
            Console.ReadKey();
        }
    }
}
