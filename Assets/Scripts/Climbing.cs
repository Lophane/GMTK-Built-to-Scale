using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour   
{

    [Header("X-Value of Leftmost Climbing Limit")]
    public float leftLimit;
    [Header("X-Value of Rightmost Climbing Limit")]
    public float rightLimit;

    [SerializeField]
    private float tileLength;


    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.W)) {
            transform.position += new Vector3(0,tileLength,0);
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            if (transform.position.x - tileLength > leftLimit) {
                transform.position += new Vector3(-1*tileLength,0,0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            transform.position += new Vector3(0,-1*tileLength,0);
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            if (transform.position.x + tileLength < rightLimit) {
                transform.position += new Vector3(tileLength,0,0);
            }
        }
    }
}
