int number = 62951;
int copyOfNumber = number;
int length = 0;
int digit = 0;
int nextDigit = 0;
int position = 0;

while (copyOfNumber > 0)
{
    copyOfNumber /= 10;
    length++;
}

for (int i = length - 1; i >= 0; i--)
{
    digit = (int)(number / Math.Pow(10, i) % 10);
    for (int j = length - 1; j >= 0; j--)
    {
        nextDigit = (int)(number / Math.Pow(10, j) % 10);
        if (nextDigit >= digit)
        {
            digit = nextDigit;
            position = j;
        }
    }
    number -= (int)(digit * Math.Pow(10, position));
    copyOfNumber += digit;
    copyOfNumber *= 10;
}

copyOfNumber /= 10;

Console.WriteLine(copyOfNumber);