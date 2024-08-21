using UnityEngine;

public static class Weather
{

    public static float takeOffSpeedMultiplier = 0.5462f;
    public static float cruiseSpeedMultiplier = 2.305f;
    public static float speedMultiplierIncreaseRate = 0.005f;

    public static float speedMultiplier = 0.5462f; // For taking off at 110 Knots: 0.8462f, for cruise speed: 2.3077f
    public static float verticalDistanceMultiplier = 5;

    public static float planeStartPos;

    public static void Initialize(float planeYPos)
    {
        planeStartPos = planeYPos;
        speedMultiplier = takeOffSpeedMultiplier;
    }

    /// <summary>
    /// Altitude in metres
    /// </summary>
    public static float GetAltitude(float yPos)
    {
        float knots = (yPos) * verticalDistanceMultiplier;
        return knots;
    }


    /// <summary>
    /// Temperature in Kelvin
    /// </summary>
    public static float GetTemperature(float yPos)
    {
        float altitude = GetAltitude(yPos);
        float altitudeInFeet = Utility.MetresToFeet(altitude);
        float farenheit = 59 - 0.00356f * altitudeInFeet;

        float kelvin = Utility.FarenheitToKelvin(farenheit);

        return kelvin;
    }


    /// <summary>
    /// Altitude pressure in Pa
    /// </summary>
    public static float GetAirPressure(float yPos)
    {
        float altitude = GetAltitude(yPos);
        float kelvin = GetTemperature(yPos);
        
        float g = -9.80665f;
        float pressureAtSea = 101325f;
        float molarMassOfDryAir = 0.02896968f;
        float gasConstant = 8.31446f;

        float power = (g * altitude * molarMassOfDryAir) / (kelvin * gasConstant);

        float pressure = pressureAtSea * Mathf.Exp(power);

        return pressure;
    }


    /// <summary>
    /// Altitude in Air density in kg/m^3
    /// </summary>
    public static float GetAirDensity(float yPos)
    {
        float pressure = GetAirPressure(yPos);
        float kelvin = GetTemperature(yPos);

        float molecularMassByBoltzmann = 3.3484f * Mathf.Pow(10, -3);
        float airDensity = molecularMassByBoltzmann * pressure / kelvin;

        return airDensity;
    }

}
