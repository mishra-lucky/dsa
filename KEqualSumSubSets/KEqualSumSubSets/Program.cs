using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEqualSumSubSets
{
    class Program
    {
        public static bool CanPartitionKSubsets(int[] nums, int k)
        {

            List<List<int>> partitions = new List<List<int>>();
            List<int> subsetsum = new List<int>();

            for (int i =0; i < k; i++)
            {
                partitions.Add(new List<int>());
                subsetsum.Add(0);
            }
            int countOfNonEmptySubSets = 0;
            bool found = false;
            canPartition(nums, 0, k, countOfNonEmptySubSets, ref subsetsum, ref partitions, ref found);
            return found;
        }
        public static void canPartition(int[] nums, int index, int k, int countOfNonEmptySubSets, ref List<int> subsetsum, ref List<List<int>> partitions, ref bool found)
        {
            if (index == nums.Length)
            {
                if (countOfNonEmptySubSets == k)
                {
                    bool ret = true;
                    for (int i = 0; i < subsetsum.Count - 1; i++)
                    {
                        if (subsetsum[i] != subsetsum[i + 1])
                        {
                            ret = false;
                            break;
                        }
                    }
                    if(ret)
                    {
                        Console.Write("[");
                        foreach(var l in partitions)
                        {
                            Console.Write("[");
                            foreach(var i in l)
                            {
                                Console.Write(i + " ");
                            }
                            Console.Write("]");

                        }
                        Console.Write("]");
                        found = true;
                    }
                }
                return;
            }

            for (int i = 0; i < partitions.Count; i++)
            {
                if (partitions[i].Count > 0)
                {
                    partitions[i].Add(nums[index]);
                    subsetsum[i] += nums[index];
                    canPartition(nums, index + 1, k, countOfNonEmptySubSets, ref subsetsum, ref partitions, ref found);
                    subsetsum[i] -= nums[index];
                    partitions[i].RemoveAt(partitions[i].Count - 1);

                }
                else
                {
                    partitions[i].Add(nums[index]);
                    subsetsum[i] += nums[index];
                    canPartition(nums, index + 1, k, countOfNonEmptySubSets + 1, ref subsetsum, ref partitions, ref found);
                    subsetsum[i] -= nums[index];
                    partitions[i].RemoveAt(partitions[i].Count - 1);
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            bool Can = CanPartitionKSubsets(new int[] {1,6,2,5,3,4}, 3);
            Console.ReadLine();            
        }
    }
}
