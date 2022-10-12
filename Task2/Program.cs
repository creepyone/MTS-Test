using System;
using System.Globalization;

class Program
{
	static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

	class Number
	{
		readonly int _number;

		public Number(int number)
		{
			_number = number;
		}

		public override string ToString()
		{
			return _number.ToString(_ifp);
		}

		public static string operator +(Number n1, string n2)
        {
			return (n1._number + Convert.ToInt32(n2)).ToString(); 
        }

		public static string operator +(string n1, Number n2)
		{
			return (n2._number + Convert.ToInt32(n1)).ToString();
		}
	}

	static void Main(string[] args)
	{
		int someValue1 = 5;
		int someValue2 = 10;

		string result = new Number(someValue1) + someValue2.ToString(_ifp);
		Console.WriteLine(result);
		Console.ReadKey();
	}
}

