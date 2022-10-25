/* Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/
Console.Clear();

label1: //Оператор "goto" оставил сознательно для сравнения с нижеследующим способом проверки условия (строки 16 - 24)
//и возвращения к началу в случае ошибочного ввода.
int rows = EnterParametrOfArray("Введите количество строк массива:      ", "Ошибка ввода!");
int columns = EnterParametrOfArray("Введите количество столбцов массива:   ", "Ошибка ввода!");
if(rows < 0 || columns < 0)
{
    Console.WriteLine("Ошибка ввода!");   
    goto label1;
}

int minValue = 0;
int maxValue = 0;
while(maxValue - minValue <= 0) //Проверяем правильность ввода границ значений массива
{
    minValue = EnterParametrOfArray("Введите минимальное значение массива:  ", "Ошибка ввода!");
    maxValue = EnterParametrOfArray("Введите максимальное значение массива: ", "Ошибка ввода!");
    if(maxValue - minValue <= 0)
        Console.WriteLine("Ошибка ввода!");
}

int[,] array = GetArray(rows, columns);

PrintResult(array, rows, columns);


//------------------------------FUNCTION--------------------------------------

static int EnterParametrOfArray(string message, string messageError)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine() ?? "", out int parametr);
        if(isCorrect)
            return parametr;
        Console.WriteLine(messageError);
    }
}
//----------------------------------------------------------------------------

int[,] GetArray(int m, int n)
{
   int[,] arr = new int[m, n];
   for(int i = 0; i < m; i++)
   {
        for(int j = 0; j < n; j++)
        {
            arr[i, j] = new Random().Next(minValue, maxValue + 1);
        }
   }
   return arr; 
}
//---------------------------------------------------------------------------
static void PrintResult(int[,] arr, int m, int n)
{
    double[] arithmeticMean = new double[n];
    for(int i = 0; i < m; i++)
    {
        for(int j = 0; j < n; j++)
        {
           Console.Write("{0}\t", arr[i, j]);   //Выводим массив в консоль СТРОЙНЫМИ РЯДАМИ!
           arithmeticMean[j] += arr[i, j];
        }
        Console.WriteLine();
    }
    Console.WriteLine(new string('-', n * 7));
    for(int j = 0; j < n; j++)
    {
        Console.Write("{0}\t", Math.Round((Double)arithmeticMean[j]/m, 2)); //Округляем среднее 
        // арифметическое до 2-х знаков после запятой и выводим в консоль
    }
} 
