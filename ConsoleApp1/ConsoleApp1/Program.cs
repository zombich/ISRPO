using NLog;

internal class Program
{
    private static Logger logger = LogManager.GetCurrentClassLogger();
    static void Main(string[] args)
    {
        logger.Debug("This is a Debug Message");
        try
        {
            Console.WriteLine("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine());

            int result = num1 / num2;
            Console.WriteLine($"Результат деления: {result}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Ошибка: введен текст вместо числа");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Ошибка: деление на 0");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }
}

