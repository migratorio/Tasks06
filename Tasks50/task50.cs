/*Программа заполняет двумерный массив случайными числами, принимает на вход позиции элемента массива, 
и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
[5, 7] -> такого числа в массиве нет
*/

Console.Clear();

int rows = 0;
int columns = 0;
for(;;)
{
    rows = EnterParametrOfArrayOrSeachElement("Введите количество строк двумерного массива: ", "Ошибка ввода!");
    columns = EnterParametrOfArrayOrSeachElement("Введите количество столбцов двумерного массива: ", "Ошибка ввода!");
    if(rows < 0 || columns < 0) //Проверяем правильность ввода колтчества строк и столбцов
        Console.WriteLine("Ошибка ввода!");
    else
    break;  
}

int minValue = 0;
int maxValue = 0;
while(maxValue <= minValue)
{
    minValue = EnterParametrOfArrayOrSeachElement("Введите минимальное значение массива: ", "Ошибка ввода!");
    maxValue = EnterParametrOfArrayOrSeachElement("Введите максимальное значение массива: ", "Ошибка ввода!");
    if(maxValue - minValue <= 0)
        Console.WriteLine("Ошибка ввода!");
}

int[,] array = GetArray(rows, columns, minValue, maxValue);

int seachRow = EnterParametrOfArrayOrSeachElement("Введите номер искомого ряда: ", "Ошибка ввода!");
int seachColumn = EnterParametrOfArrayOrSeachElement("Введите номер искомого столбца: ", "Ошибка ввода!");


PrintResult(seachRow, seachColumn, rows, columns, array);

//------------------------------FUNCTION--------------------------------------
//Функция возвращает размеры массива и индексы искомого элемента
static int EnterParametrOfArrayOrSeachElement(string message, string messageError) 
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine() ?? "", out int mn);
        if(isCorrect)
            return mn;
        Console.WriteLine(messageError);
    }
}

//----------------------------------------------------------------------------
//Функция принимает параметры массива и возвращает массив, заполненный случайными числами 
static int[,] GetArray(int m, int n, int minValue, int maxValue)
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
//----------------------------------------------------------------------------
// Функция проверяет, не выходят ли индексы искомых элементов за рамки массива 
// и выводит в консоль массив и искомый элемент
static void PrintResult(int sR, int sC, int m, int n, int[,] arr)
{
    for(int i = 0; i < m; i++)
    {
        for(int j = 0; j < n; j++)
        {
            Console.Write("{0}\t", arr[i, j]);  //Выводим массив красиво
        }
        Console.WriteLine();
    }
    if(sR > m || sC > n)
        Console.WriteLine("Индекс выходит за пределы массива!");
    else
    {
        Console.Write($"Элемент с индексами [{sR}, {sC}] -> {arr[sR - 1, sC - 1]} ");
    }

}
