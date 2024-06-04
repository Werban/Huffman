using System;

namespace Huffman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Huffman huffman = new Huffman();

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Сжать файл");
            Console.WriteLine("2. Распаковать файл");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите имя файла для сжатия:");
                    string fileToCompress = Console.ReadLine();
                    Console.WriteLine("Введите имя для сжатого файла:");
                    string compressedFile = Console.ReadLine();
                    huffman.CompressFile(fileToCompress, compressedFile);
                    break;
                case 2:
                    Console.WriteLine("Введите имя сжатого файла для распаковки:");
                    string fileToDecompress = Console.ReadLine();
                    Console.WriteLine("Введите имя для распакованного файла:");
                    string decompressedFile = Console.ReadLine();
                    huffman.DecompressFile(fileToDecompress, decompressedFile);
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}
