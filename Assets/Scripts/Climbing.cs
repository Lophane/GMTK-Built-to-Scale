using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{

    [SerializeField]
    [Header("X-Value of Leftmost Climbing Limit")]
    private float leftLimit;
    [SerializeField]
    [Header("X-Value of Rightmost Climbing Limit")]
    private float rightLimit;

    [SerializeField]
    private float movementStep;


    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.W)) {
            transform.position += new Vector3(0,movementStep,0);
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            if (transform.position.x - movementStep > leftLimit) {
                transform.position += new Vector3(-1*movementStep,0,0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            transform.position += new Vector3(0,-1*movementStep,0);
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            if (transform.position.x + movementStep < rightLimit) {
                transform.position += new Vector3(movementStep,0,0);
            }
        }
    }
}
