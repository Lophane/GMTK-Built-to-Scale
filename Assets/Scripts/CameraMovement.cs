using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 4f, -10f);

    [SerializeField]
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(0, target.position.y, 0) + offset;
        transform.position =  targetPosition;
    }
}
