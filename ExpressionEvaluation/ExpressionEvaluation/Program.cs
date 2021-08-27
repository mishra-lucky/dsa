using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluationPostFix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            int res = EvaluatePostFixExpression(tokens);
            Console.WriteLine(res);
            Console.ReadLine();
        }

        private static int EvaluatePostFixExpression(string[] tokens)
        {
            if (tokens == null || tokens.Length == 0) return 0;
            Stack<int> operands = new Stack<int>();
            foreach(string s in tokens)
            {
                if(!isOperator(s))
                {
                    int x = Convert.ToInt32(s);
                    operands.Push(x);
                }
                else
                {
                    Operate(s, ref operands);
                }
            }
            if (operands.Count == 1)
                return operands.Pop();
            return 0;
                
        }

        private static void Operate(string s, ref Stack<int> operands)
        {
            int b = operands.Pop();
            int a = operands.Pop();

            int res = 0;
            switch(s)
            {
                case "+":
                    res = a + b;
                    break;
                case "-":
                    res = a - b;
                    break;
                case "*":
                    res = a * b;
                    break;
                case "/":
                    res = (b != 0? a/b : 0);
                    break;
                default:
                    res = 0;
                    break;
            }
            operands.Push(res);
        }

        private static bool isOperator(string s)
        {
            if (s == "+" || s == "-" || s == "*" || s == "/")
                return true;
            return false;
        }
       
    }
}
