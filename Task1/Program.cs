using System.Diagnostics;
using System;
using System.Threading;

class Task1
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess();
        }
        catch { }

        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    static void FailProcess()
    {
        //Way 1: 
        Environment.Exit(-1);

        //Way 2: 
        //Process.GetCurrentProcess().Kill();

        //Way 3: 
        //Process.GetProcesses()[^1].Kill();

        //Way 4: 
        //Environment.FailFast("Failed!");

        //Way 5 (не решение, но поток можно залочить): 
        //Thread.CurrentThread.Join(); 
    }
}