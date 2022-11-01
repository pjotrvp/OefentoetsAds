using System;
using System.Collections;
class Program
{
    static bool Evaluate(string expr)
    {
        Stack<bool> stack = new Stack<bool>();
        bool lhs, rhs;

        foreach (char c in expr)
        {
            switch (c)
            {
                case 't':
                    stack.Push(true);
                    break;
                case 'f':
                    stack.Push(false);
                    break;
                case '!':
                    if (stack.Count < 1) throw new Exception("invalid expression");
                    stack.Push(!stack.Pop());
                    break;
                case '&':
                    if (stack.Count < 2) throw new Exception("invalid expression");
                    rhs = stack.Pop();
                    lhs = stack.Pop();
                    stack.Push(lhs && rhs);
                    break;
                case '|':
                    if (stack.Count < 2) throw new Exception("invalid expression");
                    rhs = stack.Pop();
                    lhs = stack.Pop();
                    stack.Push(lhs || rhs);
                    break;
                case '?':
                    if (stack.Count < 3) throw new Exception("invalid expression");
                    bool resultFalse = stack.Pop();
                    bool resultTrue = stack.Pop();
                    stack.Push(stack.Pop() ? resultTrue : resultFalse);
                    break;
                default:
                    throw new Exception("invalid expression");
            }
        }

        if (stack.Count != 1) throw new Exception("invalid expression");

        return stack.Pop();
    }

    static void Main(string[] args)
    {
        string example1 = "tf!&";
        string example2 = "ff|ft!||";
        string example3 = "tf|tf&!f?";
        string example4 = "tf&|";
        string example5 = "tf|t";

        try
        {
            Console.WriteLine(Evaluate(example1));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Console.WriteLine(Evaluate(example2));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Console.WriteLine(Evaluate(example3));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Console.WriteLine(Evaluate(example4));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Console.WriteLine(Evaluate(example5));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
