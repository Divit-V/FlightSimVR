using UnityEngine;
using UnityEngine.InputSystem;

public class MovableCam : MonoBehaviour
{

    [SerializeField] float rotSpeed = 25;

    Vector2 input;

    void Update()
    {
        if (input.magnitude > 0)
        {
            Vector3 rot = transform.localEulerAngles;
            rot.y += input.x * rotSpeed * Time.deltaTime;
            rot.x -= input.y * rotSpeed * Time.deltaTime;
            transform.localEulerAngles = rot;
        }
    }

    public void OnInputChange(InputAction.CallbackContext context) => input = context.ReadValue<Vector2>();

}