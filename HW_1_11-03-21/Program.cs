using System;

namespace HW_1_11_03_21
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write($"1.Create\n" +
                              $"2.Read\n" +
                              $"3.Update\n" +
                              $"4.Delete\n" +
                              $"Ваш выбор: ");
                switch (Console.ReadLine())
                {
                    case "1": Operation.Create(); break;
                    case "2": Operation.Read(); break;
                    case "3": Operation.Update(); break;
                    case "4": Operation.Delete(); break;
                    default: break;
                }
            }
        }
    }
}
