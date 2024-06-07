using System;
using System.IO;

namespace Huffman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Huffman huffman = new Huffman();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Сжать файл");
                Console.WriteLine("2. Распаковать файл");
                Console.WriteLine("3. Удалить файл");
                Console.WriteLine("4. Выйти из программы");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CompressFile(huffman);
                        Clear();
                        break;
                    case 2:
                        DecompressFile(huffman);
                        Clear();
                        break;
                    case 3:
                        Console.WriteLine("Введите имя файла для удаления:");
                        string fileToDelete = Console.ReadLine();
                        DeleteFile(fileToDelete);
                        Clear();
                        break;
                    case 4:
                        Console.WriteLine("Программа завершена.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Clear();
                        break;
                }
            }
        }

        static void CompressFile(Huffman huffman)
        {
            Console.WriteLine("Введите имя файла для сжатия:");
            string fileToCompress = Console.ReadLine();
            Console.WriteLine("Введите имя для сжатого файла:");
            string compressedFile = Console.ReadLine();

            if (File.Exists(fileToCompress))
            {
                huffman.CompressFile(fileToCompress, compressedFile);
                PrintCompressionDetails(fileToCompress, compressedFile);
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }

        static void DecompressFile(Huffman huffman)
        {
            Console.WriteLine("Введите имя сжатого файла для распаковки:");
            string fileToDecompress = Console.ReadLine();
            Console.WriteLine("Введите имя для распакованного файла:");
            string decompressedFile = Console.ReadLine();

            if (File.Exists(fileToDecompress))
            {
                huffman.DecompressFile(fileToDecompress, decompressedFile);
                PrintDecompressionDetails(fileToDecompress, decompressedFile);
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }

        static void PrintCompressionDetails(string fileToCompress, string compressedFile)
        {
            long originalFileSize = new FileInfo(fileToCompress).Length;
            long compressedFileSize = new FileInfo(compressedFile).Length;
            double compressionRatio = (double)compressedFileSize / originalFileSize;

            Console.WriteLine("Время выполнения операции: {0}", DateTime.Now);
            Console.WriteLine("Коэффициент сжатия: {0}", compressionRatio);
            Console.WriteLine("Размер исходного файла: {0} байт", originalFileSize);
            Console.WriteLine("Размер сжатого файла: {0} байт", compressedFileSize);
        }

        static void PrintDecompressionDetails(string fileToDecompress, string decompressedFile)
        {
            long compressedFileSize = new FileInfo(fileToDecompress).Length;
            long decompressedFileSize = new FileInfo(decompressedFile).Length;

            Console.WriteLine("Время выполнения операции: {0}", DateTime.Now);
            Console.WriteLine("Размер сжатого файла: {0} байт", compressedFileSize);
            Console.WriteLine("Размер распакованного файла: {0} байт", decompressedFileSize);
        }
        static void DeleteFile(string fileToDelete)
        {
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
                Console.WriteLine("Файл успешно удален.");
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }
        static void Clear()
        {
            Console.ReadLine();
            Console.Clear();
        }

    }
}