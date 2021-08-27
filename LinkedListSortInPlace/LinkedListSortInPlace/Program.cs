using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListSortInPlace
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        public static ListNode SortList(ListNode head)
        {

            if (head == null || head.next == null) return head;
            return MergeSort(head); ;
        }
        public static ListNode getMid(ListNode head)
        {
            if (head == null) return null;
            ListNode fast = head.next, slow = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public static ListNode MergeSort(ListNode head)
        {
            if (head == null || head.next == null) return head;          
            ListNode mid = getMid(head);
            ListNode nextToMid = mid.next;
            mid.next = null;
            ListNode left = MergeSort(head);
            ListNode right = MergeSort(nextToMid);
            return Merge(left, right);
            
        }     

        public static ListNode Merge(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l1.val < l2.val)
            {
                l1.next = Merge(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = Merge(l1, l2.next);
                return l2;
            }
        }
        static void Main(string[] args)
        {
            ListNode head = new ListNode(4, new ListNode(2, new ListNode(3, new ListNode(1))));
            head = SortList(head);
            printList(head);
            Console.ReadLine();
        }

        private static void printList(ListNode head)
        {
            while (head != null)
            {
                Console.WriteLine(head.val + " ,");
                head = head.next;
            }
        }
    }
}
