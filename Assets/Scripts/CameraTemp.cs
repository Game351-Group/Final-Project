using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTemp : MonoBehaviour
{

    public Transform player;
    public float smoothSpeed = 0.125f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }
    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(player);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
