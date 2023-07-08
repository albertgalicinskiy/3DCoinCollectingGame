using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target; // Target would be our Ball


    private void FixedUpdate() 
    {
        // Camera will move with the target
        transform.LookAt(target);
    }
}
