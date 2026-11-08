using System.Diagnostics;

var ts = new TraceSource("Calculator")
{
    Switch = new SourceSwitch("CalculatorSwitch") { Level = SourceLevels.Information }
};

ts.Listeners.Clear();
ts.Listeners.Add(new TextWriterTraceListener("ts.log", "fileListener"));
ts.Listeners.Add(new ConsoleTraceListener());
Trace.AutoFlush = true;

try
{
    Console.Write("Введите первое число: ");
    string stringA = Console.ReadLine();
    ts.TraceEvent(TraceEventType.Verbose, 1, $"Первое число - {stringA}");

    Console.Write("Введите второе число: ");
    string stringB = Console.ReadLine();
    ts.TraceEvent(TraceEventType.Verbose, 2, $"Второе число - {stringB}");

    int a = int.Parse(stringA);
    int b = int.Parse(stringB);


    ts.TraceInformation("Складываем");
    int sum = a + b;
    Console.WriteLine($"Сумма: {sum}");
    ts.TraceInformation($"Сумма: {sum}");

    ts.TraceInformation("Вычитаем");
    int subtraction = a - b;
    Console.WriteLine($"Вычитание: {subtraction}");
    ts.TraceInformation($"Вычитание: {subtraction}");

    ts.TraceInformation("Умножаем");
    int multiplication = a * b;
    Console.WriteLine($"Умножение: {multiplication}");
    ts.TraceInformation($"Умножения: {multiplication}");

    ts.TraceInformation("Выполняется деление");
    if (b == 0)
        ts.TraceEvent(TraceEventType.Warning, 10, "Произошло деление на ноль");

    int division = a / b;
    Console.WriteLine($"Деление: {division}");
    ts.TraceInformation($"Деление: {division}");
}
catch (DivideByZeroException)
{
    ts.TraceEvent(TraceEventType.Error, 67, $"Деление на ноль");
}
catch (FormatException)
{
    ts.TraceEvent(TraceEventType.Error, 229, $"Введено некорректное число");
}
catch (Exception ex)
{
    ts.TraceEvent(TraceEventType.Error, 88, $"Ошибка - {ex.Message}");
}
finally
{
    ts.Flush();
    ts.Close();
    ts.Listeners.Clear();

    ts.TraceInformation("Несуществующее сообщение");
}

