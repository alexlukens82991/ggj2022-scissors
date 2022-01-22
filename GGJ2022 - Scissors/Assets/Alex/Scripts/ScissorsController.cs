using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float mvmtSpeed;
    [SerializeField] private float turnSpeed;

    [Header("Cache")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private WheelCollider wheel;

    private void Start()
    {
        StartCoroutine(SpeedCheck());
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            RollForward();
        }

        if (Input.GetKey("a"))
        {
            TurnLeft();
        }
        else if (Input.GetKey("d"))
        {
            TurnRight();
        }

    }

    IEnumerator SpeedCheck()
    {
        do
        {
            print(rb.velocity);
            yield return new WaitForSeconds(0.5f);
        } while (true);
    }

    private void RollForward()
    {
        if (rb.velocity.z < 30)
        {

            rb.AddForce(Vector3.forward * mvmtSpeed, ForceMode.Impulse);

            wheel.motorTorque = 1;
        }
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up, -turnSpeed);
    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up, turnSpeed);
    }

    private void ZeroZRotation()
    {
        Vector3 rot = new Vector3(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y, 0);
        rb.rotation = Quaternion.Euler(rot);
    }
}
