using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class MatrixExtentions
    {
        public static AbstractMatrix<T> AddMatrix<T>(this AbstractMatrix<T> rhs, AbstractMatrix<T> lhs)
        {
            if (rhs.Size != lhs.Size)
                throw new MatrixExtensionsException();
            AbstractMatrix<T> result = new SquareMatrix<T>(rhs.Size);
            for (int i = 0; i < result.Size; i++)
                for (int j = 0; j < result.Size; j++)
                    result[i, j] = (dynamic) rhs[i, j] + lhs[i, j];
            return result;
        }
    }

    public class MatrixExtensionsException : Exception
    {
        public MatrixExtensionsException() {}

        public MatrixExtensionsException(string message) : base(message) {}

        public MatrixExtensionsException(string message, Exception innerException) : base(message, innerException) {}
    }
}
