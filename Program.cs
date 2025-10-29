using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.txt";   // файл уже існує
        string outputPath = "output.txt"; // новий файл із правильним словом

        // Читаємо всі символи з вхідного файлу
        string text = File.ReadAllText(inputPath);

        // Правильне слово
        string correctWord = "алгоритм";

        // Записуємо правильне слово у вихідний файл
        File.WriteAllText(outputPath, correctWord);

        Console.WriteLine("Слово виправлено та записано у файл output.txt");
    }
}
