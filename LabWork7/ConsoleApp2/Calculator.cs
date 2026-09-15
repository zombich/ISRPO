class Calculator
{
    static void Main(string[] args)
    {
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
            Console.WriteLine("Ошибка: Деление на 0 невозможно");
            string logMessage = $"[{DateTime.Now}] {ex.Message}: {ex.ToString}{Environment.NewLine}";
            File.AppendAllText("log.txt", logMessage);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Ошибка: Введите число");
            string logMessage = $"[{DateTime.Now}] {ex.Message}: {ex.ToString}{Environment.NewLine}";
            File.AppendAllText("log.txt", logMessage);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Ошибка: Неккоректный ввод данных");
            string logMessage = $"[{DateTime.Now}] {ex.Message}: {ex.Message}: {ex.ToString}{Environment.NewLine}";
            File.AppendAllText("log.txt", logMessage);
        }
    }
}

