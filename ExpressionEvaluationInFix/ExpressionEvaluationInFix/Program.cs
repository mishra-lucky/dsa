using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluationInFix
{
    class Program
    {
        static void Main(string[] args)
        {
            string exp = "(1+(4+5+2)-3)+(6+8)";
            int res = EvaluateInfix(exp);
            Console.WriteLine(res);
            Console.ReadLine();
        }

        private static int EvaluateInfix(string exp)
        {
            if(string.IsNullOrEmpty(exp)) return 0;

            Stack<char> operators = new Stack<char>();
            Stack<int> operands = new Stack<int>();
            foreach (char c in exp)
            {
                if (isOperand(c))
                    operands.Push(c - '0');
                else if(c == '(')
                    operators.Push(c);
                else if (isOperator(c))
                {
                    while (operators.Any() && Precedence(operators.Peek()) >= Precedence(c))
                        Operate(ref operators, ref operands);
                    operators.Push(c);
                }
                else if(c == ')')
                {
                    while (operators.Peek() != '(')
                        Operate(ref operators, ref operands);
                    operators.Pop();
                }
                 
            }
            while(operators.Any())
            {
                Operate(ref operators, ref operands);
            }
            return operands.Pop();
        }

        private static void Operate(ref Stack<char> operators, ref Stack<int> operands)
        {
            char oper = operators.Pop();
            int b = operands.Pop();
            int a = operands.Pop();

            int res = 0;

            switch(oper)
            {
                case '+':
                    res = a + b;
                    break;
                case '-':
                    res = a - b;
                    break;
                case '*':
                    res = a * b;
                    break;
                case '/':
                    res = (b != 0 ? a / b : 0);
                    break;
                default:
                    res = 0;
                    break;
            }

            operands.Push(res);
        }

        public static int Precedence(char c)
        {
            switch(c)
            {
                case '*':
                case '/':
                    return 2;
                case '+':
                case '-':
                    return 1;               
                default:
                    return 0;
            }
        }
        public static bool isOperator(char c)
        {
            return (c == '+' || c == '-' || c == '*' || c == '/');
        }
        public static bool isOperand(char c)
        {
            return (c >= '0' && c <= '9');
        }
    }
}
