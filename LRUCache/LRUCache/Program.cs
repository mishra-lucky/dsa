using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    public class ListNode<K, T>
    {
        public K key { get; set; }
        public T val { get; set; }
        public ListNode<K, T> next { get; set; }
        public ListNode<K, T> prev { get; set; }
        public ListNode(K key, T val, ListNode<K,T> next = null, ListNode<K,T> prev = null)
        {
            this.key = key;
            this.val = val;
            this.next = next;
            this.prev = prev;
        }
    }
    public class LruCache<K,T>
    {
        private int capacity;
        private Dictionary<K, ListNode<K,T>> map;
        private ListNode<K,T> head;
        private ListNode<K, T> tail;

        public LruCache(int cap)
        {
            capacity = cap;
            map = new Dictionary<K, ListNode<K,T>>(capacity);
            head = null;
        }
        public T GetEntry(K key)
        {
            if(map.ContainsKey(key))
            {
                ListNode<K, T> oldNode = map[key];
                K oKey = oldNode.key;
                T value = oldNode.val;                
                DeleteFromList(oldNode);
                ListNode<K,T> newNode = AddToList(oKey, value);
                map[key] = newNode;
                return newNode.val;
            }
            return default(T);
        }
        public void AddEntry(K key, T value)
        {
            if(map.Count == this.capacity)
            {
                map.Remove(head.key);
                DeleteFromList(head);
            }
            ListNode<K, T> add = AddToList(key, value);
            map.Add(key, add);
        }
        public void RemoveEntry(K key)
        {
            if (map.ContainsKey(key))
            {                
                DeleteFromList(map[key]);
                map.Remove(key);
            }            
        }
        private void DeleteFromList(ListNode<K, T> node)
        {             
            if(node.prev == null) // node is head
            {
                head = head.next;
                head.prev = null;
            }
            else if(node.next == null)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }
        }

        private ListNode<K,T> AddToList(K key, T value)
        {
            ListNode<K, T> newnode = new ListNode<K, T>(key, value);
            if (this.head == null)
            {
                head = newnode;
                tail = head;
            }
            else
            {
                newnode.prev = tail;
                tail.next = newnode;
                tail = tail.next;
            }
            return newnode;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LruCache<int, string> cache = new LruCache<int, string>(5);
            cache.AddEntry(1, "a");
            cache.AddEntry(2, "b");
            cache.AddEntry(3, "c");
            cache.AddEntry(4, "d");
            cache.AddEntry(5, "e");
            cache.AddEntry(6, "f");

            string s = cache.GetEntry(6);
            Console.WriteLine(s);

            cache.RemoveEntry(3);
            cache.RemoveEntry(4);

            s = cache.GetEntry(3);
            Console.WriteLine(s);
        }
    }
}
