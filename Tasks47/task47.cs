/* Программа задаёт двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n
 = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/

Console.Clear();

int rows = EnterSizeOfArray("Введите количество строк двумерного массива: ");
int columns = EnterSizeOfArray("Введите количество столбцов двумерного массива: ");

double[,] array = GetArray(rows, columns);

PrintArray(rows, columns, array);

//--------------------------------FUNCTIONS----------------------------
// Функция возвращает размер формируемого массива
static int EnterSizeOfArray(string message)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine() ?? "", out int userNumber) && userNumber > 0;
        if (isCorrect)
            return userNumber;
        Console.WriteLine("Ошибка ввода!");
    }
}
//---------------------------------------------------------------------------------
// Функция возвращает двумерный массив, заполненный случайными вещественными числами
static double[,] GetArray(int m, int n)
{
    double[,] arr = new double [m, n]; 
    Random rnd = new Random();
    for(int i = 0; i < m; i++)
    {
        for(int j = 0; j < n; j++)
        {
            arr[i, j] = Math.Round((rnd.NextDouble() * (1 - 10) + 10), 2);
        }
    }
    return arr;
}
//---------------------------------------------------------------------------------
// Функция ввыводит в консоль сформированный программой двумерный массив

static void PrintArray(int m, int n
, double[,] arr)
{
    for(int i = 0; i < m; i++)
    {
        for(int j = 0; j < n; j++)
        {
            Console.Write($"{arr[i, j]} ");
        }
        Console.WriteLine();
    }
}