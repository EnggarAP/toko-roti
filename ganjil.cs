using System;

namespace bilangan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Masukkan angka: ");
            int angka = Convert.ToInt32(Console.ReadLine());

            if (angka % 2 == 0)
            {
                Console.WriteLine(angka + " adalah bilangan genap");
            }
            else
            {
                Console.WriteLine(angka + " adalah bilangan ganjil");
            }
        }
    }
}
