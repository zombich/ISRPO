string filePath = "1.txt";

StreamReader? reader = null;

try
{
    reader = new StreamReader(filePath);

    Console.WriteLine("Четные числа:");
    string? line;
    while ((line = reader.ReadLine()) != null)
        if (int.TryParse(line, out int number) && number % 2 == 0)
            Console.WriteLine(number);
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Файл {ex.FileName} не найден.");
}
finally
{
    reader?.Dispose();
    Console.WriteLine("Проверка завершена");
}

