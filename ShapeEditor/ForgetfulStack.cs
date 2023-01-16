using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEditing
{
    internal class ForgetfulStack<T>
    {
        private readonly List<T> values = new();
        private readonly int capacity;

        public int Length => values.Count;

        public int Capacity => capacity;

        public bool IsFull => Length >= capacity;

        public bool IsEmpty => Length == 0;

        public ForgetfulStack(int capacity)
        {
            this.capacity = capacity;
        }

        public void Push(T value)
        {
            values.Insert(0, value);

            if (Length > capacity)
            {
                values.RemoveAt(capacity);
            }
        }

        public T Pop()
        {
            var value = values[0];
            values.RemoveAt(0);
            return value;
        }

        public T Peek()
        {
            return values[0];
        }

        public bool TryPop(out T? value)
        {
            if (IsEmpty)
            {
                value = default;
                return false;
            }

            value = Pop();
            return true;
        }

        public bool TryPeek(out T? value)
        {
            if (IsEmpty)
            {
                value = default;
                return false;
            }

            value = Peek();
            return true;
        }
        
        public void Clear()
        {
            values.Clear();
        }
    }
}
