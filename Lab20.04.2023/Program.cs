using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var calculator = new Calculator();
        var printer = new Printer();
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        calculator.Add(a, b);
        calculator.Subtract(a, b); 
        calculator.Multiply(a, b); 
        calculator.Divide(a, b); 

        calculator.Added += printer.PrintResult;
        calculator.Subtracted += printer.PrintResult;
        calculator.Multiplied += printer.PrintResult;
        calculator.Divided += printer.PrintResult;
    }
}

class Calculator
{
    public event EventHandler<int> Added;
    public event EventHandler<int> Subtracted;
    public event EventHandler<int> Multiplied;
    public event EventHandler<int> Divided;

    public void Add(int a, int b)
    {
        int result = a + b;
        Added?.Invoke(this, result);
    }

    public void Subtract(int a, int b)
    {
        int result = a - b;
        Subtracted?.Invoke(this, result);
    }

    public void Multiply(int a, int b)
    {
        int result = a * b;
        Multiplied?.Invoke(this, result);
    }

    public void Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Делить на 0, чел");
        }
        int result = a / b;
        Divided?.Invoke(this, result);
    }
}


class Printer
{
    public void PrintResult(object sender, int result)
    {
        EventHandler<int> handler = sender as EventHandler<int>;
        if (handler != null)
        {
            string eventName = handler.Method.Name;
            Console.WriteLine($"{eventName}: {result}");
        }
    }
}