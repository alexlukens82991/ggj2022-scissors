using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float mvmtSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float animationSpeed;

    [Header("Cache")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private WheelCollider wheel;

    private void Start()
    {
        StartCoroutine(SpeedCheck());
    }

    private void FixedUpdate()
    {
        float turnSpeed = (Mathf.Abs(rb.velocity.z) + Mathf.Abs(rb.velocity.x)) / animationSpeed;

        if (Input.GetKey("w"))
        {
            RollForward();
        }

        else if (Input.GetKey("s"))
        {
            RollReverse();
            turnSpeed *= -1;
        }

        if (Input.GetKey("a"))
        {
            TurnLeft();
        }
        else if (Input.GetKey("d"))
        {
            TurnRight();
        }



        animator.SetFloat("Speed", turnSpeed);
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
        if (rb.velocity.z < maxSpeed)
        {

            rb.AddRelativeForce(Vector3.forward * mvmtSpeed, ForceMode.Impulse);

            wheel.motorTorque = 1;
        }
    }

    private void RollReverse()
    {
        if (rb.velocity.z < maxSpeed)
        {

            rb.AddRelativeForce(-Vector3.forward * mvmtSpeed, ForceMode.Impulse);

            wheel.motorTorque = -1;
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

    public Rigidbody GetRb() { return rb; }
    public float GetMaxSpeed() { return maxSpeed; }
}
