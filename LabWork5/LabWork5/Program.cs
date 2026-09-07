FirstMethod();

void FirstMethod()
{
    int[] numbers = [1, 2, 3];
    Console.WriteLine(numbers.Sum());
    SecondMethod("input");
}

void SecondMethod(string input)
{
    Console.WriteLine(input.Length);
    ThirdMethod(3);
}

void ThirdMethod(int a)
{
	try
	{
        Console.WriteLine(a / 0);
    }
	catch (Exception ex)
	{
        string filePath = Path.Combine(Environment.CurrentDirectory, "log.txt");
        File.WriteAllText(filePath, ex.StackTrace);
        return;
	}
}