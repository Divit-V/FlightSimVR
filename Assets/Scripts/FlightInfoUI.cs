using TMPro;
using UnityEngine;

public class FlightInfoUI : MonoBehaviour
{

    [SerializeField] AirplaneController airplaneController;
    [SerializeField] TextMeshProUGUI flightInfoText;

    bool isBreak = false;
    float thrustPercent = 0;

    void Start()
    {
        airplaneController.Brake.AddListener(OnBrakeChange);
        airplaneController.ThrustPercent.AddListener(OnThrustPercentChange);
    }

    void OnBrakeChange(bool _isBreak)
    {
        isBreak = _isBreak;
        UpdateText();
    }

    void OnThrustPercentChange(float _thrustPercent)
    {
        thrustPercent = _thrustPercent * 100;
        UpdateText();
    }

    void UpdateText()
    {
        flightInfoText.text = string.Format("Thrust: {0}%\nBreak: {1}", thrustPercent.ToString("0"), isBreak ? "ON" : "OFF");
    }

}
