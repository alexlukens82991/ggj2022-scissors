using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorAttack : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float power;
    [SerializeField] private float yPower;
    [SerializeField] private LayerMask ignoreLayer;

    [Header("Cache")]
    [SerializeField] private Camera playerCam;
    [SerializeField] private ScissorsController scissorsController;
    private Rigidbody rb;

    private void Start()
    {
        rb = scissorsController.GetRb();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        //if (rb.velocity.z < scissorsController.GetMaxSpeed())
        //{
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100, ~ignoreLayer))
            {
                Vector3 dir = hit.point - transform.position;
                dir.Normalize();
                rb.AddRelativeForce((dir + (Vector3.up * yPower)) * power, ForceMode.Impulse);

            }
        //}
        
    }
}
