// See https://aka.ms/new-console-template for more information
//Create a program that converts between Celsius, Fahrenheit and Kelvin.
//Read the from, to and value from the keyboard and display the converted value.
using System;
class TemperatureConverter
{
    static void Main()
    {
        Console.Write("Enter the temperature you want to convert: ");
        double temperatureValue = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the initial temperature scale: ");
        string fromScale = Console.ReadLine().ToUpper();

        Console.Write("Enter the desired temperature scale: ");
        string toScale = Console.ReadLine().ToUpper();

        double convertedTemperature = ConvertTemperature(temperatureValue, fromScale, toScale);
        Console.WriteLine($"Converted temperature: {convertedTemperature} {toScale}");
    }

    static double ConvertTemperature(double value, string fromScale, string toScale)
    {
        switch (fromScale)
        {
            case "C":
                return FromCelsius(value, toScale);
            case "F":
                return FromFahrenheit(value,toScale);
            case "K":
                return FromKelvin(value, toScale);
            default:
                Console.WriteLine("Invalid scale");
                return 0;
        }
    }

    private static double FromKelvin(double value, string toScale)
    {
        switch (toScale)
        {
            case "C":
                return value-273.15;
            case "F":
                return (value-273.15)*9/5+32;
            case "K":
                return value;
            default:
                Console.WriteLine("Invalid scale");
                return 0;
        }
    }

    private static double FromFahrenheit(double value, string toScale)
    {
        switch (toScale)
        {
            case "C":
                return (value - 32) * 5 / 9;
            case "F":
                return value;
            case "K":
                return (value-32)*5/9+273.15;
            default:
                Console.WriteLine("Invalid scale");
                return 0;
        }
    }

    private static double FromCelsius(double value, string toScale)
    {
        switch (toScale)
        {
            case "C":
                return value;
            case "F":
                return (value*9/5)+32;
            case "K":
                return (value - 32) * 5 / 9 + 273.15;
            default:
                Console.WriteLine("Invalid scale");
                return 0;
        }
    }
}
