using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header("Cache")]
    [SerializeField] private Animator animator;


    private void Update()
    {
        if (Input.GetKey("a"))
        {
            animator.SetInteger("Dir", -1);
        }
        else if (Input.GetKey("d"))
        {
            animator.SetInteger("Dir", 1);
        }
        else
        {
            animator.SetInteger("Dir", 0);
        }
    }


    
}
