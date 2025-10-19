using System;
using System.IO;

class Program
{
    static string inputFile = "input.txt";   // Файл з хаотичним словом
    static string outputFile = "output.txt"; // Файл з правильним словом
    static string word = "алгоритм";         // Початкове слово

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1 - Ввести нове слово");
            Console.WriteLine("2 - Видалити слово (очистити файли)");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть нове слово: ");
                    string newWord = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newWord))
                    {
                        Console.WriteLine("❌ Ви нічого не ввели!");
                        break;
                    }

                    word = newWord.Trim();
                    string scrambled = Shuffle(word);
                    File.WriteAllText(inputFile, scrambled);
                    File.WriteAllText(outputFile, word);

                    Console.WriteLine($"✅ Нове слово збережено: {word}");
                    Console.WriteLine($"📁 Створено input.txt (хаотично): {scrambled}");
                    Console.WriteLine($"📁 Створено output.txt (правильне): {word}");
                    break;

                case "2":
                    if (File.Exists(inputFile)) File.Delete(inputFile);
                    if (File.Exists(outputFile)) File.Delete(outputFile);
                    Console.WriteLine("🗑 Файли очищено. Слово видалено.");
                    break;

                case "0":
                    Console.WriteLine("Програму завершено.");
                    return;

                default:
                    Console.WriteLine("❌ Невірний вибір! Введіть 0, 1 або 2.");
                    break;
            }
        }
    }

    // Метод для перемішування літер у слові
    static string Shuffle(string word)
    {
        char[] chars = word.ToCharArray();
        Random rand = new Random();
        for (int i = chars.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            (chars[i], chars[j]) = (chars[j], chars[i]);
        }
        return new string(chars);
    }
}
