#region Task-1
int[] numbers = { 8, 2, 6, 10, 12, 102, 11, 102, 102, 102 };
int biggest = 0;

foreach (int number in numbers)
{
    if (number > biggest && number % 2 == 0)
    {
        biggest = number;
    }
}

Console.WriteLine($"En boyuk: {biggest}");
#endregion

#region Task-2
int smallest = 0;

for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] % 2 != 0)
    {
        smallest = numbers[i];
        break;
    }
}

foreach (int number in numbers)
{
    if (number < smallest && number % 2 != 0)
    {
        smallest = number;
    }
}

Console.WriteLine($"En kicik: {smallest}");
#endregion

#region Task-3
int[] reversedNumbers = new int[numbers.Length];
Console.Write("Yeni array: ");
for (int i = 0; i < numbers.Length; i++)
{
    reversedNumbers[i] = numbers[^(i+1)];
    Console.Write(reversedNumbers[i] + ", ");
}
#endregion

#region Task-4
int count = 0;

foreach (int number in numbers)
{
    count++;
}

Console.WriteLine($"\nArrayin elementlerinin sayi: {count}");
#endregion

#region Task-5
int element = 102;
foreach (int number in numbers)
{
    if (number == element)
    {
        Console.WriteLine($"{element} arrayin icinde var");
        break;
    }
    else if (numbers[^1] == number)
    {
        Console.WriteLine($"{element} arrayin icinde yoxdur");
    }
}
#endregion

#region Task-6
element = 102;
count = 0;

foreach (int number in numbers)
{
    if (number == element)
    {
        count++;
    }
}
if (count == 0)
{
    Console.WriteLine($"{element} arrayin icinde yoxdur");
} else
{
    Console.WriteLine($"{element} arrayin icinde {count} sayda var");
}
#endregion