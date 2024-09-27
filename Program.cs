using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_playground;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main()");
        // ShowMeList();
        // ShowEnvironmentVariables();
        // FunWithStringBuilder();
        // SwitchWithGoto();
        // ArrayInitialization();
        // ArrayIndicesAndRanges();
        // AddWrapper(1, 2);
        // AddWrapperWithSideEffect(1, 2);
        // AddWrapperWithStatic(1, 2);
        SwapStringsWrapper();
    }

    static void ShowMeList()
    {
        /* MeList example */
        var myParty = new MeList<int>();
        myParty.Add(1);
        myParty.Add(2);
        myParty.Add(3);
        myParty.Add(4);
        myParty.Add(5);
        IEnumerator<int> enr = myParty.GetEnumerator();
        while (enr.MoveNext())
        {
            Console.Write($"{enr.Current} ");
        }

        Console.WriteLine();
        enr.Dispose();
    }

    static void ShowEnvironmentVariables()
    {
        Console.WriteLine($"args: {string.Join(", ", Environment.GetCommandLineArgs())}");
        Console.WriteLine($"Drives: {string.Join(", ", Environment.GetLogicalDrives())}");
        Console.WriteLine($"OS: {Environment.OSVersion}");
        Console.WriteLine($"Processor count: {Environment.ProcessorCount}");
    }

    static void FunWithStringBuilder()
    {
        /* Strings are immutable and can tank performance when frequently changing strings.
        Use a string builder to directly modify internal character data */
        Console.WriteLine("=> Using the StringBuilder:");
        var sb = new StringBuilder("**** Fantastic Games ****");
        sb.Append("\n");
        sb.AppendLine("Half Life");
        sb.AppendLine("Deus Ex" + "2");
        Console.WriteLine(sb.ToString()); /* Output the entire string */
        sb.Replace("2", " Invisible War");
        Console.WriteLine(sb.ToString()); /* Output the entire string again */
        Console.WriteLine("sb has {0} chars.", sb.Length);
        Console.WriteLine();
    }

    static void SwitchWithGoto()
    {
        int rand = new Random().Next(1, 4);
        Console.WriteLine($"rand: {rand}");
        switch (rand)
        {
            case 1:
                Console.WriteLine("case 1");
                goto case 2;
            case 2:
                Console.WriteLine("case 2");
                break;
            case 3:
                Console.WriteLine("case 3");
                goto default;
            default:
                Console.WriteLine("case default");
                break;
        }
    }

    static void ArrayInitialization()
    {
        Console.WriteLine("=> Array Initialization.");
        // Array initialization syntax using the new keyword.
        // string[] stringArray = new string[] { "one", "two", "three" }; // auto format rewrites this.

        // Array initialization syntax without using the new keyword.
        bool[] boolArray = { false, false, true };

        // Array initialization with new keyword and size.
        int[] intArray = new int[4] { 20, 22, 23, 0 };
        Console.WriteLine("intArray has {0} elements", intArray.Length);
    }

    static void ArrayIndicesAndRanges()
    {
        string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };
        for (int i = 0; i < gothicBands.Length; i++)
        {
            Index idx = i;
            // Print a name
            Console.Write(gothicBands[idx] + ", ");
        }

        Console.WriteLine();
        for (int i = 1; i <= gothicBands.Length; i++)
        {
            // Note that i = 1 intially. ^i represents "i" positions from the end
            // arr[^1] accesses the last element, arr[^2] the second last, and so on.
            Index idx = ^i;
            Console.Write(gothicBands[idx] + ", ");
        }

        Console.WriteLine();
        // [inclusive..exclusive]
        Index idx1 = 0;
        Index idx2 = ^0;
        Range r = idx1..idx2;
        foreach (string itm in gothicBands[r])
        {
            // Print a name
            Console.Write(itm + ", ");
        }

        Console.WriteLine("\n");
    }

    int AddWrapper(int x, int y)
    {
        // Do some validation here
        return Add();

        // Local function
        int Add()
        {
            Console.WriteLine(x + y);
            return x + y;
        }
    }

    static int AddWrapperWithSideEffect(int x, int y)
    {
        //Do some validation here
        return Add();

        int Add()
        {
            // Local function is referencing x and y and could accidentally change the original values.
            // Add static keyword to prevent this
            x += 1;
            Console.WriteLine(x + y);
            return x + y;
        }
    }

    static int AddWrapperWithStatic(int x, int y)
    {
        //Do some validation here
        return Add(x, y);

        static int Add(int x, int y)
        {
            return x + y;
        }
    }

    static void OutAndRef()
    {
        int ans;
        AddUsingOutParam(90, 90, out ans);
        AddUsingOutParam(90, 90, out int secondAns);

        // Output parameters must be assigned by the called method.
        static void AddUsingOutParam(int x, int y, out int ans)
        {
            ans = x + y;
        }

        // Discard values example.
        FillTheseValues(out int a, out _, out _);

        // Returning multiple output parameters.
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }
    }

    static void SwapStringsWrapper()
    {
        string str1 = "Flip";
        string str2 = "Flop";
        Console.WriteLine("Before: {0}, {1} ", str1, str2);
        SwapStrings(ref str1, ref str2);
        Console.WriteLine("After: {0}, {1} ", str1, str2);

        // Reference parameters.
        static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }
    }

    static int AddReadOnly(in int x, in int y)
    {
        // Prevent modifiying the arguments.

        // Error CS8331 Cannot assign to variable 'in int' because it is a readonly variable
        // x = 10000;
        // y = 88888;
        int ans = x + y;
        return ans;
    }

    static void ThrowNullException(string message, string owner = "Programmer")
    {
        ArgumentNullException.ThrowIfNull(message);
        Console.WriteLine("Error: {0}", message);
        Console.WriteLine("Owner of Error: {0}", owner);
    }
}
