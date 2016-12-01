using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using Task1;

namespace Task2.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region BinarySearchTreeTests for System.Int32
        public class CustomIntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForGetPreOrderEnumeratorInts
        {
            get
            {
                IEnumerable<int> ints = new[] {7, 3, 10, 2, 5, 12, 1, 11, 15};
                IEnumerable<int> intResult = new[] { 7,3,2,1,5,10,12,11,15 };
                yield return new TestCaseData(ints, null).Returns(intResult);

                intResult = new[] { 7,10,12,15,11,3,5,2,1};
                yield return new TestCaseData(ints, new CustomIntComparer()).Returns(intResult);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForGetPreOrderEnumeratorInts))]
        public IEnumerable<int> TestGetPreOrderEnumeratorInts(int[] items,IComparer<int> comparer)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(items,comparer);
            IEnumerator<int> actual = tree.GetPreorderEnumerator();
            
            while (actual.MoveNext())
            {
                Console.Write(actual.Current+" ");
                yield return actual.Current;
            }
        }
        #endregion

        #region BinarySearchTreeTests for System.String

        public class CustomStringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(y, x, false, CultureInfo.InvariantCulture);
            }
        }
        
        public static IEnumerable<TestCaseData> TestCasesForGetPreOrderEnumeratorStrings
        {
            get
            {
                IEnumerable<string> strings = new[] { "7", "3", "10", "2", "5", "12", "1", "11", "15" };
                IEnumerable<string> stringResult = new[] { "7", "3", "10", "1", "2", "12", "11", "15", "5" };
                yield return new TestCaseData(strings,null).Returns(stringResult);

                stringResult = new[] { "7", "3", "5", "10", "2", "12", "15", "11", "1" };
                yield return new TestCaseData(strings, new CustomStringComparer()).Returns(stringResult);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForGetPreOrderEnumeratorStrings))]
        public IEnumerable<string> TestGetPreOrderEnumeratorStrings(string[] items, IComparer<string> comparer)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(items,comparer);
            IEnumerator<string> actual = tree.GetPreorderEnumerator();

            while (actual.MoveNext())
            {
                Console.Write(actual.Current + " ");
                yield return actual.Current;
            }
        }
        #endregion

        #region BinarySearchTreeTests for Book
        public class CustomBookComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                return x.CompareTo(y, (b1, b2) => b1.PublishingYear.CompareTo(b2.PublishingYear));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForGetPreOrderEnumeratorBooks
        {
            get
            {
                IEnumerable<Book> books = new[] 
                {
                    new Book(".NET Core - .NET Goes Cross - Platform with.NET Core", "Microsoft", 2016,
                        "Carter, Phillip", "Knezevic, Zlatko"),
                    new Book("CrossNet", "Codeplex.com", 2012),
                    new Book("Announcing.NET Framework 4.6.2", "Microsoft", 2016, "Haffner, Stacey"),
                    new Book("Understanding .NET Just-In-Time Compilation", "Telerik"),
                    new Book("Understanding Garbage Collection in .NET"),
                };
                IEnumerable<Book> bookResult = new[]
                {
                    new Book(".NET Core - .NET Goes Cross - Platform with.NET Core", "Microsoft", 2016,
                        "Carter, Phillip", "Knezevic, Zlatko"),
                    new Book("CrossNet", "Codeplex.com", 2012),
                    new Book("Understanding .NET Just-In-Time Compilation", "Telerik"),
                    new Book("Understanding Garbage Collection in .NET"),
                    new Book("Announcing.NET Framework 4.6.2", "Microsoft", 2016, "Haffner, Stacey"),
                };
                yield return new TestCaseData(books, null).Returns(bookResult);

                bookResult = new[] 
                {
                    new Book("Announcing.NET Framework 4.6.2", "Microsoft", 2016, "Haffner, Stacey"),
                    new Book(".NET Core - .NET Goes Cross - Platform with.NET Core", "Microsoft", 2016,
                        "Carter, Phillip", "Knezevic, Zlatko"),
                    new Book("Understanding .NET Just-In-Time Compilation", "Telerik"),
                    new Book("Understanding Garbage Collection in .NET"),
                    new Book("CrossNet", "Codeplex.com", 2012)
                };
                yield return new TestCaseData(books, new CustomStringComparer()).Returns(bookResult);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForGetPreOrderEnumeratorBooks))]
        public IEnumerable<Book> TestGetPreOrderEnumeratorBooks(Book[] items, IComparer<Book> comparer)
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(items, comparer);
            IEnumerator<Book> actual = tree.GetPreorderEnumerator();

            while (actual.MoveNext())
            {
                Console.Write(actual.Current + " ");
                yield return actual.Current;
            }
        }
        #endregion

        #region BinarySearchTreeTests for struct Point
        public struct Point
        {
            private int x;
            private int y;
            public int X => x;
            public int Y => y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class PointComparer : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                int res = x.X.CompareTo(y.X);
                if (res == 0)
                    res = x.Y.CompareTo(y.Y);
                return res;
            }
        }

        public static IEnumerable<TestCaseData> GetPreorderEnumeratorPointTestData
        {
            get
            {
                var items = new[]
                {
                    new Point(20, 20), new Point(10, 10), new Point(30, 30), new Point(5, 5), new Point(15, 15),
                    new Point(35, 35), new Point(3, 3), new Point(8, 8), new Point(33, 33)
                };
                var result = new[]
                {
                    new Point(20, 20), new Point(10, 10), new Point(5, 5), new Point(3, 3), new Point(8, 8),
                    new Point(15, 15), new Point(30, 30), new Point(35, 35), new Point(33, 33)
                };
                yield return new TestCaseData(items, new PointComparer()).Returns(result);
                
            }
        }

        [Test,TestCaseSource(nameof(GetPreorderEnumeratorPointTestData))]
        public IEnumerable<Point> TestGetPreOrderEnumeratorPoints(Point[] items, IComparer<Point> comparer)
        {
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(items, comparer);
            IEnumerator<Point> actual = tree.GetPreorderEnumerator();
            
            while (actual.MoveNext())
            {
                yield return actual.Current;
            }
        }
        #endregion
    }
}
