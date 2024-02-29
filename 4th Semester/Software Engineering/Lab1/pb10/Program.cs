// See https://aka.ms/new-console-template for more information
//Write a program that continuously displays the current time and date in decimal, hexadecimal, and binary.
//The program should clear the screen each second.
using System;
using System.Threading;
class CurrentDate
{
    private static void Main()
    {
        while (true)
        {
            Console.Clear();
            DateTime currentTime = DateTime.Now;

            Console.WriteLine("Decimal: " + currentTime.ToString("yyyy - MM - dd HH: mm:ss"));

            Console.WriteLine("Hexadecimal: " + currentTime.ToString("yyyyMMddHHmmss"));
            Console.WriteLine("Binary: " + ToBinary(currentTime));

            Thread.Sleep(2000);
        }
    }

    private static string ToBinary(DateTime currentTime)
    {
        long binaryValue = ToTimestamp(currentTime);
        return Convert.ToString(binaryValue, 2);
    }

    private static long ToTimestamp(DateTime currentTime)
    {
        DateTime computeTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        TimeSpan timeSpan = currentTime - computeTime;

        return (long)timeSpan.TotalSeconds;
    }
}
