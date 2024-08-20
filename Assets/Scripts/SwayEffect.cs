using UnityEngine;

public class SkyboxSway : MonoBehaviour
{
    public float swayAmount = 0.5f; 
    public float swaySpeed = 0.5f; 
    private Vector3 initialLocalPosition;

    void Start()
    {
        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {
        float swayX = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        float swayY = Mathf.Sin(Time.time * swaySpeed * 0.7f) * swayAmount;

        transform.localPosition = new Vector3(initialLocalPosition.x + swayX, initialLocalPosition.y + swayY, initialLocalPosition.z);
    }
}
