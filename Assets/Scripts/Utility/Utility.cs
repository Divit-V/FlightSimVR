public static class Utility
{

    public static float MetresToFeet(float val)
    {
        return val * 3.28084f;
    }

    public static float FarenheitToCelcius(float temp)
    {
        return (temp - 32) * 5 / 9.0f;
    }

    public static float CelciusToKelvin(float celcius)
    {
        return celcius + 273.15f;
    }

    public static float FarenheitToKelvin(float farenheit)
    {
        float celcius = FarenheitToCelcius(farenheit);
        return CelciusToKelvin(celcius);
    }

    public static float KelvinToCelcius(float kelvin)
    {
        return kelvin - 273.15f;
    }

    public static float mpsToKnots(float speed)
    {
        return speed * 1.9438f;
    }

    public static float PaToInchesOfMercury(float pascals)
    {
        return pascals / 3386f;
    }

}
