using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header("Cache")]
    [SerializeField] private Transform lookObj;
    [SerializeField] private CinemachineComposer cam;


    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            if (cam.m_TrackedObjectOffset != Vector3.left)
            {
                //cam.m_TrackedObjectOffset == Vector3.left;
            }
        }
    }
}
