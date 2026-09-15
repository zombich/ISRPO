using System.Diagnostics;

string filePath = "log.txt";

Stopwatch readFileStopwatch = new();
readFileStopwatch.Start();

ExecuteReadFile(filePath);
ExecuteReadFile(filePath);
ExecuteReadFile(filePath);

readFileStopwatch.Stop();

Stopwatch calculationStopwatch = new();
calculationStopwatch.Start();

ExecuteMathCalculations();
ExecuteMathCalculations();
ExecuteMathCalculations();

calculationStopwatch.Stop();

Console.WriteLine($"Общее время: {calculationStopwatch.ElapsedMilliseconds + readFileStopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"Среднее время чтения файла: {readFileStopwatch.ElapsedMilliseconds / 3.0} ms");
Console.WriteLine($"Среднее время вычислений: {calculationStopwatch.ElapsedMilliseconds / 3.0} ms");


void ExecuteReadFile(string filePath)
{
    Stopwatch stopWatch = new();

    stopWatch.Start();

    string content = File.ReadAllText(filePath);

    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;

    LogTimings(ts, "read file");
}

void ExecuteMathCalculations()
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

    LogTimings(ts, "calculation");
}

static void LogTimings(TimeSpan ts, string operation)
{
    Debug.WriteLine($"Операция ({operation}) завершена. Время выполнения: {ts.Milliseconds} ms");
    string logMessage = $"[{DateTime.Now}] Operation= {operation}, Elapsed= {ts.Milliseconds} ms\n";
    File.AppendAllText("timings.log", logMessage);
}