# Практическая работа №10: Частичные классы (partial classes) и методы в C#
## Выполнил студент группы П25-2.1 Карпухин Дмитрий
---

> * Файл 1: SpaceShuttle.Core.cs (Ядро и данные)
```csharp
using System;

public partial class SpaceShuttle
{
    private double _fuelKg;
    private double _oxygenHours;
    private int _hullIntegrity;

    public string ShuttleName { get; set; }

    public double FuelKg
    {
        get { return _fuelKg; }
        set
        {
            if (value >= 0)
                _fuelKg = value;
        }
    }

    public int HullIntegrity
    {
        get { return _hullIntegrity; }
        set
        {
            if (value < 0)
                _hullIntegrity = 0;
            else if (value > 100)
                _hullIntegrity = 100;
            else
                _hullIntegrity = value;
        }
    }

    public bool IsOperational
    {
        get { return _hullIntegrity > 15 && _oxygenHours > 0; }
    }

    public SpaceShuttle(string shuttleName, double fuelKg,
        double oxygenHours, int hullIntegrity)
    {
        this.ShuttleName = shuttleName;
        this.FuelKg = fuelKg;
        this._oxygenHours = oxygenHours;
        this.HullIntegrity = hullIntegrity;
    }
}
```

> * Файл 2: SpaceShuttle.Engines.cs (Двигатели и физика полета)
```csharp
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
```

> * Файл 3: SpaceShuttle.Diagnostics.cs (Диагностика и события)
```csharp
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
```

> * Файл 4: Program.cs (Точка входа)
```csharp
using System;

class Program
{
    static void Main()
    {
        SpaceShuttle shuttle = new SpaceShuttle(
            "Буран-Next", 2400.0, 48.0, 100);

        Console.WriteLine("=== НАЧАЛО МИССИИ ===");

        shuttle.PrintTelemetry();

        shuttle.ExecuteOrbitalBurn(15, 8.0);
        shuttle.CheckSystems();

        shuttle.ExecuteOrbitalBurn(60, 15.0);
        shuttle.PerformAtmosphericEntry();

        shuttle.CheckSystems();
        shuttle.PrintTelemetry();

        Console.WriteLine("=== КОНЕЦ МИССИИ ===");
    }
}
```

> * Программный комплекс «Бортовой модуль космического шаттла»
```csharp

using System;

public partial class SpaceShuttle
{
    private double _fuelKg;
    private double _oxygenHours;
    private int _hullIntegrity;

    public string ShuttleName { get; set; }

    public double FuelKg
    {
        get { return _fuelKg; }
        set
        {
            if (value >= 0)
                _fuelKg = value;
        }
    }

    public int HullIntegrity
    {
        get { return _hullIntegrity; }
        set
        {
            if (value < 0)
                _hullIntegrity = 0;
            else if (value > 100)
                _hullIntegrity = 100;
            else
                _hullIntegrity = value;
        }
    }

    public bool IsOperational
    {
        get { return _hullIntegrity > 15 && _oxygenHours > 0; }
    }

    public SpaceShuttle(string shuttleName, double fuelKg,
        double oxygenHours, int hullIntegrity)
    {
        this.ShuttleName = shuttleName;
        this.FuelKg = fuelKg;
        this._oxygenHours = oxygenHours;
        this.HullIntegrity = hullIntegrity;
    }

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

class Program
{
    static void Main()
    {
        SpaceShuttle shuttle = new SpaceShuttle(
            "Буран-Next", 2400.0, 48.0, 100);

        Console.WriteLine("=== НАЧАЛО МИССИИ ===");

        shuttle.PrintTelemetry();

        shuttle.ExecuteOrbitalBurn(15, 8.0);
        shuttle.CheckSystems();

        shuttle.ExecuteOrbitalBurn(60, 15.0);
        shuttle.PerformAtmosphericEntry();

        shuttle.CheckSystems();
        shuttle.PrintTelemetry();

        Console.WriteLine("=== КОНЕЦ МИССИИ ===");
    }
}
```
