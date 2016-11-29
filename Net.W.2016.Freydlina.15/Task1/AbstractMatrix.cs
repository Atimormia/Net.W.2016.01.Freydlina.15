using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    public abstract class AbstractMatrix<T>: IEnumerable<T>
    {
        public event EventHandler<ElementChangedArgs<T>> ElementChanged;
        protected T[] matrix;

        private int size;
        public int Size
        {
            get { return size; }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                size = value;
            }
        }

        public T this[int i, int j]
        {
            get
            {
                ValidateIndex(i);
                ValidateIndex(j);
                return GetElement(i, j);
            }
            set
            {
                ValidateIndex(i);
                ValidateIndex(j);
                T oldValue = GetElement(i, j);
                SetElement(value, i, j);
                OnElementChanged(this, new ElementChangedArgs<T>(i, j, oldValue, GetElement(i, j)));
            }
        }

        protected abstract void SetElement(T element, int i, int j);

        protected abstract T GetElement(int i, int j);

        protected virtual void ValidateIndex(int index)
        {
            if (index < 0 || index >= Size)
                throw new InvalidMatrixIndexException(nameof(index));
        }

        protected virtual void OnElementChanged(object sender, ElementChangedArgs<T> e)
        {
            ElementChanged?.Invoke(sender, e);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return this[i, j];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ElementChangedArgs<T> : EventArgs
    {
        public int Row { get; }
        public int Column { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        public ElementChangedArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public class InvalidMatrixIndexException : Exception
    {
        public InvalidMatrixIndexException() { }
       
        public InvalidMatrixIndexException(string message) : base(message) {}

        public InvalidMatrixIndexException(string message, Exception innerException) : base(message, innerException) {}

        //protected InvalidMatrixIndexException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}
