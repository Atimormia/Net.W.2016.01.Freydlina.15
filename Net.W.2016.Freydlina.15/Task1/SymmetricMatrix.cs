using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SymmetricMatrix<T> : AbstractMatrix<T>
    {
        public SymmetricMatrix(int size)
        {
            Size = size;
            matrix = new T[size*(size + 1)/2];
        }

        protected override void SetElement(T element, int i, int j)
        {
            matrix[i*(i + 1)/2 + j] = element;
        }

        protected override T GetElement(int i, int j)
        {
            return j <= i ? matrix[i*(i + 1)/2 + j] : matrix[j*(j + 1)/2 + i];
        }
    }
}
