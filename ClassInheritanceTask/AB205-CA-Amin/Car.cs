namespace AB205_CA_Amin;

internal class Car : Vehicle
{
    public string Brand;
    public string Model;
    public double FuelCapacity;
    public double FuelFor1Km;
    public double CurrentFuel;

    public Car(int year, string brand, string model, double fuelFor1Km, double fuelCapacity) : base(year)
    {
        Brand = brand;
        Model = model;
        FuelCapacity = fuelCapacity;
        FuelFor1Km = fuelFor1Km;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"FuelCapacity: {FuelCapacity}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"FuelFor1Km: {FuelFor1Km}");
        Console.WriteLine($"CurrentFuel: {CurrentFuel}");
    }

    public void Drive(double km)
    {
        double fuelForDesiredKm = FuelFor1Km * km;
        if (fuelForDesiredKm <= CurrentFuel)
        {
            CurrentFuel -= fuelForDesiredKm;
            Console.WriteLine(CurrentFuel);
        }
        else
        {
            Console.WriteLine($"Masina {fuelForDesiredKm - CurrentFuel} litr benzin lazimdir");
        }
    }
}