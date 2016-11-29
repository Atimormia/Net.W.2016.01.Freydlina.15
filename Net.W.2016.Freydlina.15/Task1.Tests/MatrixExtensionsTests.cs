using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class MatrixExtensionsTests
    {
        public static IEnumerable<TestCaseData> TestCasesForAddMatrix
        {
            get
            {
                SquareMatrix<int> squareMatrix = new SquareMatrix<int>(3)
                {
                    [0, 0] = 1, [0, 1] = 2, [0, 2] = 3,
                    [1, 0] = 4, [1, 1] = 5, [1, 2] = 6,
                    [2, 0] = 7, [2, 1] = 8, [2, 2] = 9
                };
                AbstractMatrix<int> result = new SquareMatrix<int>(3)
                {
                    [0, 0] = 2, [0, 1] = 4, [0, 2] = 6,
                    [1, 0] = 8, [1, 1] = 10, [1, 2] = 12,
                    [2, 0] = 14, [2, 1] = 16, [2, 2] = 18
                };
                yield return new TestCaseData(squareMatrix,squareMatrix).Returns(result);

                DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(3)
                {
                    [0, 0] = 1, [1, 1] = 2, [2, 2] = 3
                };
                result = new SquareMatrix<int>(3)
                {
                    [0, 0] = 2, [0, 1] = 2, [0, 2] = 3,
                    [1, 0] = 4, [1, 1] = 7, [1, 2] = 6,
                    [2, 0] = 7, [2, 1] = 8, [2, 2] = 12
                };
                yield return new TestCaseData(squareMatrix,diagonalMatrix).Returns(result);

                result = new DiagonalMatrix<int>(3)
                {
                    [0, 0] = 2, [1, 1] = 4, [2, 2] = 6
                };
                yield return new TestCaseData(diagonalMatrix,diagonalMatrix).Returns(result);

                SymmetricMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(3)
                {
                    [0, 0] = 1, 
                    [1, 0] = 2, [1, 1] = 3, 
                    [2, 0] = 4, [2, 1] = 5, [2, 2] = 6
                };
                result = new SquareMatrix<int>(3)
                {
                    [0, 0] = 2, [0, 1] = 4, [0, 2] = 7,
                    [1, 0] = 6, [1, 1] = 8, [1, 2] = 11,
                    [2, 0] = 11, [2, 1] = 13, [2, 2] = 15
                };
                yield return new TestCaseData(squareMatrix, symmetricMatrix).Returns(result);

                result = new SymmetricMatrix<int>(3)
                {
                    [0, 0] = 2, 
                    [1, 0] = 4, [1, 1] = 6, 
                    [2, 0] = 8, [2, 1] = 10, [2, 2] = 12
                };
                yield return new TestCaseData(symmetricMatrix,symmetricMatrix).Returns(result);

                result = new SymmetricMatrix<int>(3)
                {
                    [0, 0] = 2, 
                    [1, 0] = 2, [1, 1] = 5, 
                    [2, 0] = 4, [2, 1] = 5, [2, 2] = 9
                };
                yield return new TestCaseData(diagonalMatrix,symmetricMatrix).Returns(result);
                
            }
        }

        [Test,TestCaseSource(nameof(TestCasesForAddMatrix))]
        public AbstractMatrix<int> TestAddMatrix(AbstractMatrix<int> rhs, AbstractMatrix<int> lhs)
        {
            AbstractMatrix<int> result = rhs.AddMatrix(lhs);
            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            return result;
        }
    }
}
