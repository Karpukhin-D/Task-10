using System;

public partial class SpaceShuttle
{
    partial void OnCriticalSystemAlert(string systemName, string message);

    partial void OnCriticalSystemAlert(string systemName, string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.WriteLine("!!! ТРЕВОГА БОРТОВОГО КОМПЬЮТЕРА !!!");
        Console.WriteLine($"Система: {systemName}");
        Console.WriteLine($"Сообщение: {message}");
        Console.ResetColor();
    }

    public void CheckSystems()
    {
        Console.WriteLine();
        Console.WriteLine("=== ДИАГНОСТИКА СИСТЕМ ===");

        if (_fuelKg < 500)
            OnCriticalSystemAlert("Топливная система", "Критический остаток топлива!");

        if (_hullIntegrity < 25)
            OnCriticalSystemAlert("Контур обшивки", "Опасность разрушения корпуса!");

        if (IsOperational)
            Console.WriteLine("Основные системы работоспособны.");
        else
            Console.WriteLine("ВНИМАНИЕ: шаттл неработоспособен!");
    }

    public void PrintTelemetry()
    {
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("       ТЕЛЕМЕТРИЯ КОСМИЧЕСКОГО ШАТТЛА");
        Console.WriteLine("========================================");
        Console.WriteLine($"Название шаттла:       {ShuttleName}");
        Console.WriteLine($"Топливо:               {FuelKg:F1} кг");
        Console.WriteLine($"Запас кислорода:       {_oxygenHours:F1} ч");
        Console.WriteLine($"Прочность корпуса:     {HullIntegrity}%");

        if (IsOperational)
            Console.WriteLine("Работоспособность:     Да");
        else
            Console.WriteLine("Работоспособность:     Нет");

        Console.WriteLine("========================================");
        Console.WriteLine();
    }
}
