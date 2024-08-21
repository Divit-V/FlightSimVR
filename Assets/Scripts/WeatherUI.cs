using TMPro;
using UnityEngine;

public class WeatherUI : MonoBehaviour
{

    [SerializeField] Rigidbody planeRb;
    [SerializeField] TextMeshProUGUI weatherText;
    [SerializeField] AirplaneController airplaneController;

    void Update()
    {
        string speed = Utility.mpsToKnots(airplaneController.GetVelocity()).ToString("0.00");
        string altitude = Weather.GetAltitude(planeRb.position.y).ToString("0.00");
        string temp = Utility.KelvinToCelcius(Weather.GetTemperature(planeRb.position.y)).ToString("0.00");
        string airPressure = Weather.GetAirPressure(planeRb.position.y).ToString("0.00");
        string airDensity = Weather.GetAirDensity(planeRb.position.y).ToString("0.00");

        weatherText.text = $"Speed: {speed} knots\nAltitude: {altitude} m\nTemperature: {temp} C" +
            $"\nAir Pressure: {airPressure} Pa\nAir Density: {airDensity} Kg/m^3";
    }
}
