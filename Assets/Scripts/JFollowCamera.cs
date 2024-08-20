using UnityEngine;

public class JFollowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public float swayAmount = 0.1f;
    public float swaySpeed = 1.0f;
    public Vector3 offset = Vector3.zero;

    public bool lockX = false; 
    public bool lockY = false; 

    private Vector3 initialOffset;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        initialOffset = transform.position - cameraTransform.position;
    }

    void Update()
    {
        Vector3 targetPosition = cameraTransform.position + initialOffset + offset;

        targetPosition.x += Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        targetPosition.y += Mathf.Cos(Time.time * swaySpeed * 0.5f) * swayAmount;

        if (lockX)
        {
            targetPosition.x = transform.position.x;
        }
        if (lockY)
        {
            targetPosition.y = transform.position.y;
        }

        transform.position = targetPosition;
    }
}
