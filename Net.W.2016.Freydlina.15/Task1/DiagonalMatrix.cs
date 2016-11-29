using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        public DiagonalMatrix(int size)
        {
            Size = size;
            matrix = new T[size];
        }

        protected override void SetElement(T element, int i, int j)
        {
            if (i != j)
                throw new InvalidMatrixIndexException();
            matrix[i] = element;
        }

        protected override T GetElement(int i, int j)
        {
            return i == j ? matrix[i] : default(T);
        }
    }
}
