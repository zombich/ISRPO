try
{
    Console.WriteLine("Введите первое число: ");
    int a = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите второе число: ");
    int b = int.Parse(Console.ReadLine());

    Console.WriteLine($"{a} + {b} = {a + b}");
    Console.WriteLine($"{a} - {b} = {a - b}");
    Console.WriteLine($"{a} * {b} = {a * b}");
    Console.WriteLine($"{a} / {b} = {a / b}");
}
catch (DivideByZeroException ex)
{
    LogException(ex, "Деление на 0 невозможно");
}
catch (FormatException ex)
{
    LogException(ex, "Введите число");
}
catch (OverflowException ex)
{
    LogException(ex, "Неккоректный ввод данных");
}
catch (Exception ex)
{
    LogException(ex, "Возникла непредвиденная ошибка");
}

static void LogException(Exception ex, string error)
{
    Console.WriteLine($"Ошибка: {error}");
    string logMessage = $"[{DateTime.Now}] {ex.Message}: {ex}\n";
    File.AppendAllText("log.txt", logMessage);
}