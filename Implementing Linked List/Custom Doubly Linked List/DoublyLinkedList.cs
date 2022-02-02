using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private bool IsReversed = false;
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int Count { get; private set; }

        public void AddFirst(Node node)
        {
            if (!CheckIfFirst(node))
            {
                Node previousHead = Head;
                Head = node;
                node.Next = previousHead;
                previousHead.Previous = node;
            }
            Count++;
        }

        public void AddLast(Node node)
        {
            if (!CheckIfFirst(node))
            {
                Node previousTail = Tail;
                Tail = node;
                node.Previous = previousTail;
                previousTail.Next = node;
            }
            Count++;
        }

        public void ForEach(Action<Node> action)
        {
            var node = Head;
            if (IsReversed)
            {
                node = Tail;
            }

            while (node != null)
            {
                action(node);
                if (IsReversed)
                {
                    node = node.Previous;
                }
                else
                {
                    node = node.Next;
                }
            }
        }

        private bool CheckIfFirst(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return true;
            }

            return false;
        }

        public void Reversed()
        {
            IsReversed = !IsReversed;
        }

        public int[] ToArray()
        {
            int index = 0;
            int[] array = new int[Count];
            Node node = Head;
            while (node!= null)
            {
                array[index++] = node.Value;
                node = node.Next;
            }

            return array;
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                return;
            }
            var privious = Head;
            var next = Head.Next;
            if (next != null)
            {
                next.Previous = null;
            }

            Head = next;
            Count--;
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                return;
            }
            var privious = Tail;
            var next = Tail.Previous;
            if (next == null)
            {
                Head = next;
                return;
            }
            if (next != null)
            {
                Tail = next;
                next.Next = null;
                Count--;
            }
            
        }
    }
}
