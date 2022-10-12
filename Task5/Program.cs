using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        var out_ = Console.Out;
        TransformToElephant();
        Console.WriteLine("Муха");
        //... custom application code
        Console.SetOut(out_);
        Console.WriteLine(123);
    }

    static void TransformToElephant()
    {
        Console.WriteLine("Слон");
        Console.SetOut(new StreamWriter("text.txt"));
    }
}
