using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (target.transform.position.z > 47.9f && target.transform.position.z < 48.1f && target.transform.position.y < 4.0f && target.transform.position.y >= 1.0f)
        {
            offset = new Vector3(0,3.5f,9.5f);
        }

        transform.LookAt(target);
    }
}
