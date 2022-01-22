using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform lookPoint;
    [SerializeField] private Transform balloonTiePoint;
    [SerializeField] private LineRenderer lineRenderer;

    private void Update()
    {
        transform.LookAt(lookPoint.position);
        lineRenderer.SetPositions(new Vector3[] { lookPoint.position, balloonTiePoint.position });
    }
}
