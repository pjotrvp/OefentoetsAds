namespace DeepCopy
{
    internal class ListNode<T> : ICloneable where T : ICloneable
    {
        private ListNode<T> _next;
        private T _data;

        public ListNode(ListNode<T> previous, T data)
        {
            if (previous != null) previous._next = this;
            _data = data;
        }

        public ListNode(ListNode<T> other)
        {
            if (other._next != null)
            {
                _next = (ListNode<T>)other._next.Clone();
            }
            _data = (T)other._data.Clone();
        }

        public object Clone()
        {
            return new ListNode<T>(this);
        }

        public void ReplaceAt(int index, T new_data)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("index does not exist in linked list");
            }
            else if (index == 0)
            {
                _data = new_data;
            }
            else
            {
                _next.ReplaceAt(index - 1, new_data);
            }
        }

        public override string ToString()
        {
            if (_next != null)
            {
                return String.Format("{0}, {1}", _data.ToString(), _next.ToString());
            }
            else
            {
                return _data.ToString();
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            ListNode<string> head = new ListNode<string>(null, "first");
            ListNode<string> second = new ListNode<string>(head, "second");
            ListNode<string> third = new ListNode<string>(second, "third");
            ListNode<string> fourth = new ListNode<string>(third, "fourth");

            Console.WriteLine(head);

            ListNode<string> shallowCopy = head;
            ListNode<string> deepCopy = (ListNode<string>)head.Clone();

            head.ReplaceAt(1, "replaced");

            ListNode<string> fifth = new ListNode<string>(fourth, "fifth");

            Console.WriteLine(shallowCopy);
            Console.WriteLine(deepCopy);
        }
    }

}

