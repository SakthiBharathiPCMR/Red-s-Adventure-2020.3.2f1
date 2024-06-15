using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] float yOffset=1f;
    [SerializeField] float xOffset = 1f;


    [SerializeField]
    private Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition.x+xOffset,targetPosition.y+yOffset,targetPosition.z), ref velocity, smoothTime);
    }
}
