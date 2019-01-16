using System;
using CameliaCalculator;

namespace testDLL
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Veuillez renseigner le 1er nombre de l'opération:");
            string op1 = Console.ReadLine();
            Console.WriteLine("Veuillez renseigner   second nombre de l'opération:");
            string op2 = Console.ReadLine();
            Console.WriteLine(op1 + " + " + op2 + " = " + Calculator.additions(int.Parse(op1), int.Parse(op2)).ToString());
            Console.WriteLine(op1 + " - " + op2 + " = " + Calculator.soustractions(int.Parse(op1), int.Parse(op2)).ToString());
            Console.WriteLine(op1 + " x " + op2 + " = " + Calculator.multiplications(int.Parse(op1), int.Parse(op2)).ToString());
        }
    }
}
