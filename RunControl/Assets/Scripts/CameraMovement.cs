using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;
    public bool isItOver;
    public GameObject cameraVSPosition;

    private void Start()
    {
        targetOffset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        if (!isItOver)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, 0.125f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, cameraVSPosition.transform.position, 0.015f);
        }
        
    }
}
