using System;

internal class Program
{
    static int[] stack = new int[100]; 
    static int stackpointer = -1;

    static void Main(string[] args)
    {
        Push('$');
        string operatör = "-+/*"; // Operatörler
        string postfix =  "abc*-"; // Postfix bunu infix'e çevireceğiz.
        //"abc*d/+f-h+"
        string değişkenler = "$abc";
        int ifade = 0;
        int[] değerler = {0, 1, 2, 3};
        for (int i = 0; i < postfix.Length; i++)
        { 
            char ch = postfix[i];
            int indis = operatör.IndexOf(ch);
            if (indis == -1)
            {
                Push(değerler[değişkenler.IndexOf(ch)]);
                continue;
            }

            int operand2 = Pop();
            int operand1 = Pop();
            if (ch == '-')
            {
                ifade = operand1-operand2;
            }
            if (ch == '+')
            {
                ifade = operand1 + operand2;
            }
           if (ch == '*')
            {
                ifade = operand1 * operand2;
            }
            if (ch == '/')
            {
                ifade = operand1 / operand2;
            }
            Push(ifade);
        }

        Console.WriteLine(Pop());
        

    }
    
    static int Top()
    {
        return stack[stackpointer];
    }

    // Yığına eleman ekleme
    static void Push(int data)
    {
        stackpointer++;
        stack[stackpointer] = data;
    }

    // Yığından eleman çıkarma
    static int Pop()
    {
        int value = stack[stackpointer];
        stackpointer--;
        return value;
    }
}