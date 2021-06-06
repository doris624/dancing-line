using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    [Range(0.001f, 1f)]
    public float smoothFcator=0.5f;
    public bool lookAtPlayer = false;
    private Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    void Update()
    {
        Vector3 newPos = player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFcator);
        if (lookAtPlayer)
        {
            transform.LookAt(player.transform);
        }
    }
}
