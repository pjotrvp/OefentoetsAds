namespace DeepCopy
{
    class ListNode<T> : ICloneable where T : ICloneable
    {
        private ListNode<T> Next;
        private T Data;

        public ListNode(ListNode<T> previous, T data)
        {
            if (previous != null) previous.Next = this;
            Data = data;
        }

        public ListNode(ListNode<T> other)
        {
            if (other.Next != null)
            {
                Next = (ListNode<T>)other.Next.Clone();
            }
            Data = (T)other.Data.Clone();
        }

        public object Clone()
        {
            return new ListNode<T>(this);
        }

        public void ReplaceAt(int index, T newData)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("index does not exist in linked list");
            }
            else if (index == 0)
            {
                Data = newData;
            }
            else
            {
                Next.ReplaceAt(index - 1, newData);
            }
        }

        public override string ToString()
        {
            if (Next != null)
            {
                return String.Format("{0}, {1}", Data.ToString(), Next.ToString());
            }
            else
            {
                return Data.ToString();
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

