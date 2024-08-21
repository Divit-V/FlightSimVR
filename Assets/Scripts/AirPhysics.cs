using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPhysics : MonoBehaviour
{
    static Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public static float GetLiftForce(float yPos)
    {
        float LiftCoff = 0.08f;
        //float LiftF = LiftCoff * Weather.GetAirDensity(yPos) * Mathf.Pow(rb.velocity.magnitude * 3.6f, 2) * Weather.GetAltitude(yPos);
        float LiftF = LiftCoff * Weather.GetAirDensity(yPos) * Mathf.Pow(rb.velocity.magnitude * 3.6f, 2) * 30.6f;


        return LiftF;
    }

    public static float GetDragForce(float yPos)
    {
        float DragCoff = 0.021f;
        float DragF = DragCoff * Weather.GetAirDensity(yPos) * Mathf.Pow(rb.velocity.magnitude * 3.6f, 2) * Weather.GetAltitude(yPos);
        return DragF;
    }
}
