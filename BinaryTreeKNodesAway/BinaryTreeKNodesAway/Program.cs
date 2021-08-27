using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeKNodesAway
{
 public class TreeNode {
  public int val;
  public TreeNode left;
 public TreeNode right;
 public TreeNode(int x) { val = x; }
 }
 
    class Program
    {
        public static IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {

            List<int> result = new List<int>();
            List<TreeNode> path = new List<TreeNode>();
            if (FindPath(root, target, ref path))
            {
                for (int i = 0; i < path.Count; i++)
                {
                    List<int> lvl = new List<int>();
                    KLevelsDown(path[i], k - i, ref lvl, i == 0 ? null : path[i - 1]);
                    result.AddRange(lvl);
                }
            }
            return result;

        }
        public static void KLevelsDown(TreeNode root, int level, ref List<int> lvl, TreeNode blocker)
        {
            if (root == null || level < 0 || root == blocker)
                return;
            if (level == 0)
            {
                lvl.Add(root.val);
                return;
            }
            KLevelsDown(root.left, level - 1, ref lvl, blocker);
            KLevelsDown(root.right, level - 1, ref lvl, blocker);

        }
        public static bool FindPath(TreeNode root, TreeNode target, ref List<TreeNode> path)
        {
            if (root == null)
                return false;

            if (root.val == target.val)
            {
                path.Add(root);
                return true;
            }
            if (FindPath(root.left, target, ref path))
            {
                path.Add(root);
                return true;
            }
            if (FindPath(root.right, target, ref path))
            {
                path.Add(root);
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            //[3,5,1,6,2,0,8,null,null,7,4]
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(5);
            root.right = new TreeNode(1);

            root.left.left = new TreeNode(6);
            root.left.right = new TreeNode(2);

            root.left.left.left = new TreeNode(0);
            root.left.left.right = new TreeNode(8);

           
            root.left.left.left.left = new TreeNode(7);
            root.left.left.left.left = new TreeNode(4);

            var result = DistanceK(root, new TreeNode(5), 2);
            Console.ReadLine();
        }
    }
}
