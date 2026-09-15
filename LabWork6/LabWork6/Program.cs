using NLog;

namespace LabWork6
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException() : base("Отрицательное число"){ }
        public NegativeNumberException(string message) : base(message) { }
        public NegativeNumberException(string message, Exception innerException) : base(message, innerException) { }
    }

    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
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

            try
            {
                Console.WriteLine("Введите возраст: ");
                int age = int.Parse(Console.ReadLine());

                if (age < 0)
                {
                    throw new NegativeNumberException();
                }
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine("Отрицательное число");
            }
        }
    }

}