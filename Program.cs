using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";   // Вхідний файл
        string outputFile = "output.txt"; // Файл з правильним словом

        string correctWord = "алгоритм"; // Правильне слово

        try
        {
            // Якщо input.txt не існує, створимо його з хаотичною версією
            if (!File.Exists(inputFile))
            {
                string scrambledWord = Shuffle(correctWord); // Перемішуємо літери
                File.WriteAllText(inputFile, scrambledWord);
                Console.WriteLine("Файл input.txt створено з хаотичними лiтерами: " + scrambledWord);
            }

            // Зчитуємо символи з input.txt
            string content = File.ReadAllText(inputFile).Replace("\n", "").Replace("\r", "").Replace(" ", "");
            Console.WriteLine("Зчитаний вмiст input.txt: " + content);

            // Записуємо правильне слово у output.txt
            File.WriteAllText(outputFile, correctWord);
            Console.WriteLine("Новий файл output.txt створено з правильним словом: " + correctWord);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    // Метод для випадкового перемішування літер
    static string Shuffle(string word)
    {
        char[] chars = word.ToCharArray();
        Random rand = new Random();
        for (int i = chars.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }
        return new string(chars);
    }
}
