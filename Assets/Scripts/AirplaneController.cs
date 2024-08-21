using UnityEngine;
using UnityEngine.InputSystem;

public class AirplaneController : MonoBehaviour
{

    public Observer<bool> Brake = new Observer<bool>(false);
    public Observer<float> ThrustPercent = new Observer<float>(0f);

    [Tooltip("Difference: With a joystick, when input is 0, there's no thrust, whereas for keyboard when input is 0 it just means you're" +
        "not holding down any button")]
    [SerializeField] bool isKeyboard = true;

    [SerializeField] float rollControlSensitivity = 0.2f;
    [SerializeField] float pitchControlSensitivity = 0.2f;
    [SerializeField] float yawControlSensitivity = 0.2f;
    //[SerializeField] float thrustControlSensitivity = 0.01f;
    [SerializeField] float flapControlSensitivity = 0.15f;

    [Header("Caps")]
    //[Range(0, 100)] [SerializeField] float tooMuchAnglePitchCapPercentage = 100;
    //[Range(0, 100)] [SerializeField] float tooHighAltitudePitchCapPercentage = 100;
    //[SerializeField] float inputPitchRange = 0.25f;
    //[SerializeField] float maxAltitude = 50;
    //[SerializeField] float maxPitchAngle;
    //bool tooHigh = false;
    //bool tooMuchPitch = false;

    float pitch;
    float yaw;
    float roll;
    float flap;

    AircraftPhysics aircraftPhysics;
    Rigidbody rb;

    bool tookOff = false;

    void Start()
    {
        aircraftPhysics = GetComponent<AircraftPhysics>();
        rb = GetComponent<Rigidbody>();

        Weather.speedMultiplier = Weather.takeOffSpeedMultiplier;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    SceneManager.LoadScene(0);
        //}

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    SetThrust(thrustPercent + thrustControlSensitivity);
        //}

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //thrustControlSensitivity *= -1;
            flapControlSensitivity *= -1;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Brake.Value = !Brake.Value;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            flap += flapControlSensitivity;
            //clamp
            flap = Mathf.Clamp(flap, 0f, Mathf.Deg2Rad * 40);
        }

        if (!tookOff)
        {
            if (Weather.GetAltitude(rb.position.y) > 20)
                tookOff = true;
        }
        else if (Weather.speedMultiplier != Weather.cruiseSpeedMultiplier)
        {
            Weather.speedMultiplier = Mathf.Lerp(Weather.speedMultiplier, Weather.cruiseSpeedMultiplier,
                Weather.speedMultiplierIncreaseRate);

            if (Mathf.Abs(Weather.speedMultiplier - Weather.cruiseSpeedMultiplier) / Weather.cruiseSpeedMultiplier < 0.01f)
                Weather.speedMultiplier = Weather.cruiseSpeedMultiplier;
        }

        //tooHigh = rb.position.y > maxAltitude;

    }

    void FixedUpdate()
    {
        aircraftPhysics.SetControlSurfecesAngles(pitch, roll, yaw, flap);
        aircraftPhysics.SetThrustPercent(ThrustPercent.Value);
        aircraftPhysics.Brake(Brake.Value);
    }

    public void OnPitchInputChanged(InputAction.CallbackContext context)
    {
        float inputPitch = pitchControlSensitivity * context.ReadValue<float>();
        pitch = inputPitch;

        //float upperCap = 0.25f;

        //if (tooHigh)
        //    upperCap = tooHighAltitudePitchCap;
        //if (tooMuchPitch && upperCap > tooMuchAnglePitchCap)
        //    upperCap = tooMuchAnglePitchCap;

        //pitch = Mathf.Clamp(inputPitch, -0.25f, upperCap);
        //print(inputPitch + ": " + pitch);
    }

    public void OnRollInputChanged(InputAction.CallbackContext context)
    {
        roll = rollControlSensitivity * context.ReadValue<float>();
    }

    public void OnYawInputChanged(InputAction.CallbackContext context)
    {
        yaw = yawControlSensitivity * context.ReadValue<float>();
    }

    public void OnThrustInputChanged(InputAction.CallbackContext context)
    {
        float val = context.ReadValue<float>();
        float thrustPercent = ThrustPercent.Value;

        if (isKeyboard)
        {
            if (val > 0)
                thrustPercent = val;
            else if (val < 0)
                thrustPercent = 0;
        }
        else
        {
            if (val > 0)
                thrustPercent = val;
            else
                thrustPercent = 0;
        }

        ThrustPercent.Value = thrustPercent;
    }

    /// <summary>
    /// Returns velocity in mps * a multiplier
    /// </summary>
    public float GetVelocity()
    {
        return rb.velocity.magnitude * 0.7f; //Weather.speedMultiplier;
    }

}