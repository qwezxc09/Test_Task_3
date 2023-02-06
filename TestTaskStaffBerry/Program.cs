

//1 задание
using TestTaskStaffBerry;

var asyncClass = new AsyncClass();
Console.WriteLine("///////////////////////////");
Console.WriteLine("Работа асинхронного класса из 1 задания");
asyncClass.AddTask(() => { Thread.Sleep(1000); Console.WriteLine("1 метод"); });
asyncClass.AddTask(() => { Thread.Sleep(1000); Console.WriteLine("2 метод"); });
asyncClass.AddTask(() => { Thread.Sleep(1000); Console.WriteLine("3 метод"); });
asyncClass.AddTask(() => { Thread.Sleep(1000); Console.WriteLine("4 метод"); });
asyncClass.ExecuteTasksAsync();
Thread.Sleep(4500);
//ожидание выполнения всех задач асинхронного класса
Console.WriteLine("Работа Асинхронного класса, ожидание завершения всех задач в Main");
await asyncClass.ExecuteTasksAsync();

//Второе задание
Console.WriteLine("///////////////////////////");
double[] inputArray2 = new double[] { 1, 2, 3, 4, 5 };
Console.WriteLine("Второе задание, входные данные: "+ string.Join(",", inputArray2));
Console.WriteLine("Второе задание, итог: " + string.Join(",",GetRowSums(inputArray2)));


//Четвертое задание
int[] inputArray4 = new int[] { 3, 1, 8, 11, 5, 4 };
Console.WriteLine("///////////////////////////");
Console.WriteLine("Четвертое задание, входные данные: " + string.Join(", ", inputArray4));
Console.Write("Введите число для проверки: ");
string inputValue = Console.ReadLine();
if (Int32.TryParse(inputValue, out int inputNumber))
{
    Console.WriteLine(checkSetOfNumbersShort(inputNumber, inputArray4, 0, -1) ? "Можно представить в виде суммы чисел массива" : "Нельзя представить в виде суммы чисел массива");
    Console.WriteLine("///////////////////////////");
}
else
    Console.WriteLine("Введено неверное число");






//2 задание
IEnumerable<double> GetRowSums(IEnumerable<double> row)
{
    var resList = new List<double>();
    for(int i = 1; i <= row.Count(); i++)
        resList.Add(row.Take(i).Aggregate((x,y)=>x+y));
    return resList;
}


//4 задание
bool checkSetOfNumbersShort(int inputNumber, int[] inputArray, int sum, int position)
{
    position++;
    if (position == inputArray.Length)
    {
        if (sum == inputNumber)
            return true;
        else
            return false;
    }
    return checkSetOfNumbersShort(inputNumber, inputArray, sum + inputArray[position], position) || checkSetOfNumbersShort(inputNumber, inputArray, sum, position);
}