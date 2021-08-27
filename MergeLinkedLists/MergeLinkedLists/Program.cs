using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeLinkedLists
{
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

    public class HeapNode
    {
        public ListNode node { get; set; }
        public int listnumber { get; set; }
        public int indexinlist { get; set; }

    }
    public class Heap
    {
        public List<HeapNode> storage = new List<HeapNode>();
        public void Heapify()
        {
            for (int i = (storage.Count -1)/ 2 ; i >= 0; i--)
            {
                MinHeapify(i, storage.Count);
            }
        }
        public HeapNode Pop()
        {
            if (storage == null || storage.Count == 0) return null;

            swap(0, storage.Count - 1);
            HeapNode tobepop = storage[storage.Count - 1];
            storage.RemoveAt(storage.Count - 1);
            MinHeapify(0, storage.Count);
            return tobepop;
        }
        public void MinHeapify(int i, int n)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest = i;

            if (left < n && storage[left].node.val <= storage[smallest].node.val)
                smallest = left;
            if (right < n && storage[right].node.val < storage[smallest].node.val)
                smallest = right;
            if (smallest != i)
            {
                swap(i, smallest);
                MinHeapify(smallest, n);
            }

        }
        public void swap(int i, int j)
        {
            var temp = storage[i];
            storage[i] = storage[j];
            storage[j] = temp;
        }

    }     
    class Program
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {

            ListNode result = null;
            if (lists == null || lists.Length == 0) return result;

            Heap heap = new Heap();
            heap.storage = new List<HeapNode>();

            for (int i = 0; i < lists.Length; i++)
            {
                if (getLength(lists[i]) > 0)
                {
                    HeapNode node = new HeapNode();
                    ListNode indexnode = getIndexedNode(lists[i], 0);
                    node.node = indexnode; node.listnumber = i; node.indexinlist = 0;
                    heap.storage.Add(node);
                }
            }
            heap.Heapify();

            while (heap.storage.Any())
            {
                HeapNode r = heap.Pop();
                appendToList(ref result, r.node);
                ListNode nextnode = getIndexedNode(lists[r.listnumber], r.indexinlist + 1);
                if (nextnode != null)
                {
                    HeapNode n = new HeapNode();
                    n.node = nextnode; n.listnumber = r.listnumber; n.indexinlist = r.indexinlist + 1;
                    heap.storage.Add(n);
                    heap.Heapify();
                }
            }
            return result;

        }
        public static int getLength(ListNode head)
        {
            if (head == null)
                return 0;
            return 1;
        }
        public static ListNode getIndexedNode(ListNode head, int index)
        {
            if (head == null) return null;
            int ctr = 0;

            ListNode curr = head;
            while (ctr != index || curr != null)
            {
                if (ctr == index)
                    break;                    
                curr = curr.next;
                ctr++;
                                
            }
            if (ctr == index)
                return curr;
            return null;
        }
        public static void appendToList(ref ListNode head, ListNode node)
        {
            if (head == null)
            {
                head = new ListNode();
                head.val = node.val;
                head.next = null;
            }
            else
            {
                ListNode curr = head;
                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = new ListNode(node.val);
            }
        }
        static void Main(string[] args)
        {
            // [[1,4,5],[1,3,4],[2,6]]
            ListNode[] lists = new ListNode[3];
            ListNode head1 = new ListNode(1);
            appendToList(ref head1, new ListNode(2));
            appendToList(ref head1, new ListNode(3));

            ListNode head2 = new ListNode(4);
            appendToList(ref head2, new ListNode(5));
            appendToList(ref head2, new ListNode(6));
            appendToList(ref head2, new ListNode(7));

            lists[0] = head1; lists[1] = head2;
            ListNode result = MergeKLists(lists);
            Console.ReadLine();

        }      
    }
}
