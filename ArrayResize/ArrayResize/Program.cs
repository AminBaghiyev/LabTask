int[] array1 = [1, 2, 3];
int length = 10;
int[] array2 = new int[length];

for (int i = 0; i < array1.Length; i++)
{
    array2[i] = array1[i];
}

foreach (int i in array2)
{
    Console.Write($"{i} ");
}