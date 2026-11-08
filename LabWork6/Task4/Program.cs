AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

throw new InvalidOperationException("errr");

void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
{
    if (e.ExceptionObject is Exception ex)
    {
        string log = $"{DateTime.Now} - {ex.Message}\n";
        File.AppendAllText("crash.log", log);
    }
    Console.WriteLine("Произошла ошибка. Подробности в логах.");
}