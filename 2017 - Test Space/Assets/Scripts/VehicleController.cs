using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    public InputAction accelerate;
    public InputAction brake;
    public InputAction steer;

    public float accelerationValue;
    public float brakeValue;
    public float steerValue;
    public float decelerationValue = 4.0f;

    public float currentSpeed;
    public float maxSpeed;

    const float ACCELERATION_FACTOR = 10.0f;
    const float BRAKE_FACTOR = 5.0f;
    const float STEER_FACTOR = 25.0f;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        accelerate.Enable();
        brake.Enable();
        steer.Enable();

        accelerate.performed += AccelerateInput;
        accelerate.canceled += AccelerateInput;

        brake.performed += BrakeInput;
        brake.canceled += BrakeInput;

        steer.performed += SteerInput;
        steer.canceled += SteerInput;
    }

    public void AccelerateInput(InputAction.CallbackContext c)
    {
        accelerationValue = c.ReadValue<float>() * ACCELERATION_FACTOR;
    }

    public void BrakeInput(InputAction.CallbackContext c)
    {
        brakeValue = c.ReadValue<float>() * BRAKE_FACTOR;
    }

    public void SteerInput(InputAction.CallbackContext c)
    {
        steerValue = c.ReadValue<float>() * STEER_FACTOR;
    }

    private void Update()
    {

        currentSpeed -= decelerationValue * Time.deltaTime;
        currentSpeed += accelerationValue * Time.deltaTime;
        currentSpeed -= brakeValue * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        if (Mathf.Abs(currentSpeed) > 0.01f)
        {
            float steer = steerValue * Mathf.Sign(currentSpeed);
            transform.Rotate(0f, steer * Time.deltaTime, 0f);
        }

        Vector3 tmp = transform.forward * (currentSpeed);
        rb.linearVelocity = tmp;
    }

    public void SpeedBoost(float boost_)
    {
        StartCoroutine(BoostTimer(boost_, 10f));
    }

    private IEnumerator BoostTimer(float boost_, float duration_)
    {
        currentSpeed += boost_;
        maxSpeed += boost_ * 2;
        yield return new WaitForSeconds(duration_);
        currentSpeed -= boost_;
        maxSpeed -= boost_ * 2;
    }
}