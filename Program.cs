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
