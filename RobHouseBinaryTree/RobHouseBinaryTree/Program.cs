using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobHouseBinaryTree
{
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }
 
    class Program
    {
        public static int Rob(TreeNode root)
        {

            Dictionary<TreeNode, int> robresult = new Dictionary<TreeNode, int>();
            Dictionary<TreeNode, int> notrobresult = new Dictionary<TreeNode, int>();

            return Math.Max(maxProfit(root, false, ref robresult, ref notrobresult),
                            maxProfit(root, true, ref robresult, ref notrobresult));
        }

        public static int maxProfit(TreeNode root, bool parentrobbed, ref Dictionary<TreeNode, int> robresult, ref Dictionary<TreeNode, int> notrobresult)
        {
            if (root == null) return 0;


            int rob = 0, notrob = 0;

            if (parentrobbed)
            {
                if (robresult.ContainsKey(root)) return robresult[root];
                rob = maxProfit(root.left, false, ref robresult, ref notrobresult) + maxProfit(root.right, false, ref robresult, ref notrobresult);
                robresult.Add(root, rob);
                return rob;

            }
            else
            {
                if (notrobresult.ContainsKey(root)) return notrobresult[root];
                rob = root.val + maxProfit(root.left, true, ref robresult, ref notrobresult) + maxProfit(root.right, true, ref robresult, ref notrobresult);
                notrob = maxProfit(root.left, false, ref robresult, ref notrobresult) + maxProfit(root.right, false, ref robresult, ref notrobresult);
                notrobresult.Add(root, Math.Max(rob, notrob));
                return Math.Max(rob, notrob);

            }

        }
        static void Main(string[] args)
        {
            //[4,1,null,2,null,3]
            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(1);

            root.left.left = new TreeNode(2);
            root.left.left.left = new TreeNode(3);


            int profit = Rob(root);
            Console.WriteLine(profit);
            Console.ReadLine();
        }
    }
}
