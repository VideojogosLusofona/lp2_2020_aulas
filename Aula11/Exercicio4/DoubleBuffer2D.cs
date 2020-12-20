using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio4
{
    // A simple generic double buffer implementation
    public class DoubleBuffer2D<T> : IBuffer2D<T>
    {
        private T[,] current;
        private T[,] next;

        public int XDim => next.GetLength(0);
        public int YDim => next.GetLength(1);

        public T this[int x, int y]
        {
            get => current[x, y];
            set => next[x, y] = value;
        }

        private void Clear()
        {
            Array.Clear(next, 0, XDim * YDim);
        }

        public DoubleBuffer2D(int x, int y)
        {
            current = new T[x, y];
            next = new T[x, y];
            Clear();
        }

        public void Swap()
        {
            T[,] aux = current;
            current = next;
            next = aux;
            Clear();
        }
    }
}
