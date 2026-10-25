using System;

public partial class SpaceShuttle
{
    public void ExecuteOrbitalBurn(double burnTimeSeconds, double thrustPower)
    {
        double fuelConsumption = burnTimeSeconds * thrustPower * 2.5;

        Console.WriteLine();
        Console.WriteLine("=== МАРШЕВЫЙ ДВИГАТЕЛЬ ===");

        if (FuelKg < fuelConsumption)
        {
            Console.WriteLine("Ошибка: недостаточно топлива для маневра!");
            return;
        }

        FuelKg -= fuelConsumption;

        int hullDamage = (int)(burnTimeSeconds / 10);
        HullIntegrity -= hullDamage;

        Console.WriteLine($"Время работы: {burnTimeSeconds} сек.");
        Console.WriteLine($"Расход топлива: {fuelConsumption:F1} кг");
        Console.WriteLine($"Износ корпуса: {hullDamage}%");
        Console.WriteLine("Маневр успешно выполнен.");
    }

    public void PerformAtmosphericEntry()
    {
        Random random = new Random();
        int hullDamage = random.Next(10, 26);

        Console.WriteLine();
        Console.WriteLine("=== ВХОД В АТМОСФЕРУ ===");

        HullIntegrity -= hullDamage;
        _oxygenHours -= 1.5;

        if (_oxygenHours < 0)
            _oxygenHours = 0;

        Console.WriteLine($"Повреждение корпуса: {hullDamage}%");
        Console.WriteLine("Расход кислорода: 1,5 часа");
    }
}
