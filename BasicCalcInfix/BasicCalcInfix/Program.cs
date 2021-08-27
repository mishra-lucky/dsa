using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalcInfix
{
    class Program
    {
        public static int Calculate(string exp)
        {
            if (string.IsNullOrEmpty(exp)) return 0;

            List<string> tokens = ParseString(exp);
            Stack<int> operands = new Stack<int>();
            Stack<string> operators = new Stack<string>();
            foreach (string token in tokens)
            {

                int num;
                if (int.TryParse(token, out num))
                {
                    operands.Push(num);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == "+" || token == "-")
                {
                    while (operators.Any() && Precedence(operators.Peek()) >= Precedence(token))
                        ApplyOp(ref operands, ref operators);
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Any() && operators.Peek() != "(")
                        ApplyOp(ref operands, ref operators);
                    operators.Pop();
                }

            }
            while (operators.Any())
                ApplyOp(ref operands, ref operators);
            return operands.Pop();
        }
        public static int Precedence(string s1)
        {
            if (s1 == "(") return 0;
            return 1;
        }
        public static void ApplyOp(ref Stack<int> operands, ref Stack<string> operators)
        {
            int b = operands.Any() ? operands.Pop() : 0;
            int a = operands.Any() ? operands.Pop() : 0;

            string op = operators.Pop();
            if (op == "-")
                operands.Push(a - b);
            else
                operands.Push(a + b);
        }
        public static List<string> ParseString(string str)
        {
            int i = 0;
            List<string> result = new List<string>();
            while (i < str.Length)
            {
                if (str[i] == '(' || str[i] == ')' || str[i] == '+' || str[i] == '-')
                    result.Add(str[i++].ToString());                
                else if (char.IsDigit(str[i]))
                {
                    int num = 0;
                    while (i < str.Length && char.IsDigit(str[i]))
                        num = num * 10 + (str[i++] - '0');
                    result.Add(num.ToString());
                }
                else
                    i++;
            }
            return result;

        }
        static void Main(string[] args)
        {
            string str = "5 + 3 - 4 - (1 + 2 - 7 + (10 - 1 + 3 + 5 + (3 - 0 + (8 - (3 + (8 - (10 - (6 - 10 - 8 - 7 + (0 + 0 + 7) - 10 + 5 - 3 - 2 + (9 + 0 + (7 + (2 - (2 - (9) - 2 + 5 + 4 + 2 + (2 + 9 + 1 + 5 + 5 - 8 - 9 - 2 - 9 + 1 + 0) - (5 - (9) - (0 - (7 + 9) + (10 + (6 - 4 + 6)) + 0 - 2 + (10 + 7 + (8 + (7 - (8 - (3) + (2) + (10 - 6 + 10 - (2) - 7 - (2) + (3 + (8)) + (1 - 3 - 8) + 6 - (4 + 1) + (6)) + 6 - (1) - (10 + (4) + (8) + (5 + (0)) + (3 - (6)) - (9) - (4) + (2)))))) - 1))) + (9 + 6) + (0)))) + 3 - (1)) + (7))))))))";
            int res = Calculate(str);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
