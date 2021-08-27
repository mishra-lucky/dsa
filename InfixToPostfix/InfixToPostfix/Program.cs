using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixToPostfix
{
    class Program
    {
        static void Main(string[] args)
        {
            string infix = "x^y/(5*z)+2";
            string postfix = ConvertToPostFix(infix);
            Console.WriteLine(postfix);
        }

        private static string ConvertToPostFix(string infix)
        {
            if (string.IsNullOrEmpty(infix)) return null;
            StringBuilder sb = new StringBuilder();

            Stack<char> s = new Stack<char>();

            foreach (char c in infix)
            {
                if (isOperand(c))
                {
                    sb.Append(c);
                }
                else if (c == '(')
                    s.Push(c);
                else if (c == ')')
                {
                    while (s.Peek() != '(')
                    {
                        sb.Append(s.Pop());
                    }
                    s.Pop();
                }
                else if (isOperator(c))
                {

                    while (s.Any() && precedence(s.Peek()) > precedence(c))
                    {
                        sb.Append(s.Pop());
                    }

                    s.Push(c);
                }
            }
            while (s.Any())
                sb.Append(s.Pop());
            return sb.ToString();
        }

        private static int precedence(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 0;
            }
        }

        private static bool isOperand(char c)
        {
            return char.IsLetterOrDigit(c);
        }
        private static bool isOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
                return true;
            return false;
        }
    }
}
