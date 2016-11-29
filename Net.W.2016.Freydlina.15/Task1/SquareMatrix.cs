using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SquareMatrix<T> : AbstractMatrix<T>
    {
        public SquareMatrix(int size)
        {
            Size = size;
            matrix = new T[size*size];
        }

        protected override void SetElement(T element, int i, int j)
        {
            matrix[Size*i + j] = element;
        }

        protected override T GetElement(int i, int j)
        {
            return matrix[Size*i + j];
        }
    }
}
