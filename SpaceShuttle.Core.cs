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
