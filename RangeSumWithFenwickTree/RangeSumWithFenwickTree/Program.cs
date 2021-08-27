using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeSumWithFenwickTree
{
    public class FenWickTree
    {
        private int[] nums;
        private int[] bit;

        public FenWickTree(int[] nums)
        {
            this.nums = nums;
            this.bit = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
                _update(i+1, nums[i]);
        }
        private void _update(int i, int delta)
        {
            for (; i <= nums.Length; i += (i & -i))
                bit[i] += delta;
        }

        public void Update(int index, int val)
        {
            _update(index + 1, val - nums[index]);
            nums[index] = val;
        }
        public int Sum(int left, int rigth)
        {
            return _sum(rigth) - _sum(left-1);
        }
        private int _sum(int i)
        {
            int sum = 0;
            i += 1;
            for (; i > 0; i -= (i & -i))
                sum += bit[i];

            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // ["NumArray","sumRange","update","sumRange"]
           // [[[1,3,5]],[0,2],[1,2],[0,2]]

            int[] nums = {-1};
            FenWickTree tree = new FenWickTree(nums);
            int s = tree.Sum(0, 0);
            Console.WriteLine(s);
            tree.Update(0, 1);
            s = tree.Sum(0, 0);
            Console.WriteLine(s);
            Console.ReadLine();

        }
    }
}
