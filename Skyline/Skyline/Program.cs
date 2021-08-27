using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline
{  
    public class Point:IComparable<Point>
    {
        public int XCoordinate { get; set; }
        public int Height { get; set; }
        public bool Start { get; set; }

        public int CompareTo(Point other)
        {
            //first compare by x.
            //If they are same then use this logic
            //if two starts are compared then higher height building should be picked first
            //if two ends are compared then lower height building should be picked first
            //if one start and end is compared then start should appear before end
            if (this.XCoordinate != other.XCoordinate)
                return this.XCoordinate - other.XCoordinate;
            if(this.Start)
            {
                if(other.Start)
                    return this.Height > other.Height ? -1 : 1;
                else
                    return -1;
            }
            else
            {
                if (other.Start)
                    return 1; 
                else
                    return this.Height > other.Height ? 1 : -1;
            }
        }
    } 
    class Program
    {
        static void Main(string[] args)
        {
            //[[4,9,10],[4,9,15],[4,9,12],[10,12,10],[10,12,8]]
            //int[][] b = { new int[] { 2, 9, 10 }, new int[] { 3, 7, 15 }, new int[] { 5, 12, 12 }, new int[] { 15, 20, 10 }, new int[] { 19, 24, 8 } };
            int[][] b = { new int[] { 4, 9, 10 }, new int[] { 4, 9, 15 }, new int[] { 4, 9, 12 }, new int[] { 10, 12, 10 }, new int[] { 10, 12, 8 } };

            List<Point> allPoints = new List<Point>();
            foreach(int[] arr in b)
            {
                Point start = new Point(); start.XCoordinate = arr[0]; start.Height = arr[2]; start.Start = true;
                Point end = new Point(); end.XCoordinate = arr[1]; end.Height = arr[2]; end.Start = false;
                allPoints.Add(start);
                allPoints.Add(end);
            }

            List<List<int>> result = CreateSkyline(ref allPoints);
           
        }

        private static List<List<int>> CreateSkyline(ref List<Point> allPoints)
        {
            allPoints.Sort();
            List<List<int>> result = new List<List<int>>();
            SortedDictionary<int,int> hp = new SortedDictionary<int, int>();
            int previousMaxHeight = 0;
            int currentMaxHeight = 0;
            hp.Add(0,1);
            foreach(var point in allPoints)
            {
                if(point.Start)
                {
                    if (!hp.ContainsKey(point.Height))
                        hp.Add(point.Height, 1);
                    else
                        hp[point.Height]++;                 
                }
                else
                {
                    if (hp.ContainsKey(point.Height) && hp[point.Height] > 1)
                        hp[point.Height]--;
                    else if(hp[point.Height] == 1)
                        hp.Remove(point.Height);
                }

                currentMaxHeight = hp.Keys.Last();
                if (currentMaxHeight != previousMaxHeight)
                {
                    result.Add(new List<int> { point.XCoordinate,currentMaxHeight });
                    previousMaxHeight = currentMaxHeight;
                }
            }
            return result;
        }
    }
}
