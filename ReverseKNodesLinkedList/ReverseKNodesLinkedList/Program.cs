using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseKNodesLinkedList
{
public class ListNode {
 public int val;
 public ListNode next;
 public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
  }
}
   
    class Program
    {
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null) return null;
            ListNode next = null, prev = head;
            if(atlestKNodes(head, k))
            {
                next = MoveKNodesForward(head, k);
                prev = ReverseNode(head, k);
            }
            prev = AppendList(prev, ReverseKGroup(next, k));
            return prev;
            
        }

        private static ListNode AppendList(ListNode prev, ListNode next)
        {
            if (prev == null) return null;
            if (next == null) return prev;
            ListNode ptr = prev;
            while (ptr.next != null) ptr = ptr.next;
            ptr.next = next;
            return prev;
        }

        private static ListNode ReverseNode(ListNode head, int k)
        {
            ListNode curr = head, prev = null, next = null;
            while(curr != null && k > 0)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
                k--;
            }
            return prev;
        }

        private static ListNode MoveKNodesForward(ListNode head, int k)
        {
            ListNode ptr = head;
            while(ptr != null && k > 0)
            {
                ptr = ptr.next;
                k--;
            }
            return ptr;
        }

        private static bool atlestKNodes(ListNode curr, int k)
        {
            ListNode ptr = curr;
            while(ptr != null)
            {
                if (k == 0)
                    break;
                ptr = ptr.next;
                k--;
            }
            if (k == 0)
                return true;
            return false;
        }

        static void Main(string[] args)
        {
            ListNode root = new ListNode(1);
            root.next = new ListNode(2);
           root.next.next = new ListNode(3);
           root.next.next.next = new ListNode(4);
           root.next.next.next.next = new ListNode(5);

            ListNode newRoot = ReverseKGroup(root, 3);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
