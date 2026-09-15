using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "log.txt";

        Console.WriteLine("Выберите операцию:\n1 - Чтение данных из файла\n2 - Выполнить длительный математический расчёт");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ExecuteReadFile(filePath);
                break;
            case "2":
                ExecuteMathCalculations();
                break;
        }
    }

    static void ExecuteReadFile(string filePath)
    {
        Stopwatch stopWatch = new();

        stopWatch.Start();

        string content = File.ReadAllText(filePath);

        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;

        Debug.WriteLine($"Чтение завершено. Время чтения: {ts}");
        //string logMessage = $"[{DateTime.Now}] Operation=: {Environment.NewLine}";
        File.AppendAllText("timings.log", logMessage);
    }

    static void ExecuteMathCalculations()
    {
        Stopwatch stopWatch = new();

        stopWatch.Start();

        double result = 0;
        int iterations = 500000;

        for (int i = 1; i < iterations; i++)
        {
            result += Math.Sqrt(i) * Math.Sin(i);
        }

        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;

        Debug.WriteLine($"Расчёт завершён. Среднее время расчёта: {ts}");
    }
}
