using System;
using System.Collections;

namespace BooleanCalculator;
internal class Program
{
    static bool Evaluate(string expr)
    {
        var stack = new Stack<bool>();
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

    private static void Main(string[] args)
    {
        var example1 = "tf!&";
        var example2 = "ff|ft!||";
        var example3 = "tf|tf&!f?";
        var example4 = "tf&|";
        var example5 = "tf|t";

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
