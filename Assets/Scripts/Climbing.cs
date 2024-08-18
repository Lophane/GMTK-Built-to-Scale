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

    private bool alreadyMoving = false;

    private ClimbingDirection bufferedDirection = ClimbingDirection.None;


    private IEnumerator ClimbInDirection(Vector3 startPosition, Vector3 endPosition) {
        float timeElapsed = 0;
        float movementDuration = 0.3f;

        while (timeElapsed < movementDuration) {
            timeElapsed += Time.deltaTime;
            float lerpStep = timeElapsed/movementDuration;
            transform.position = Vector3.Lerp(startPosition,endPosition, lerpStep);
            yield return null;
        }
        alreadyMoving = false;

    }

    // Update is called once per frame
    void Update()
    {   
        // Debug.Log(bufferedDirection);
        
        if (alreadyMoving == false && bufferedDirection != ClimbingDirection.None) {
            // Debug.Log("use buffer to move");
            alreadyMoving = true;
            if (bufferedDirection == ClimbingDirection.Up) {
                // Debug.Log("use buffer to move up");
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(0,tileLength,0)));
                // Debug.Log("up buffer movement coroutine finished");
            }
            else if (bufferedDirection == ClimbingDirection.Left) {
                // Debug.Log("use buffer to move left");
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(-1*tileLength,0,0)));
                // Debug.Log("left buffer movement coroutine finished");
            }
            else if (bufferedDirection == ClimbingDirection.Down) {
                // Debug.Log("use buffer to move down");
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(0,-1*tileLength,0)));
                // Debug.Log("down buffer movement coroutine finished");
            }
            else if (bufferedDirection == ClimbingDirection.Right) {
                // Debug.Log("use buffer to move right");
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(tileLength,0,0)));
                // Debug.Log("right buffer movement coroutine finished");
            }
            bufferedDirection = ClimbingDirection.None;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            if (alreadyMoving == false) {
                alreadyMoving = true;
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(0,tileLength,0)));
            }
            else {
                // Debug.Log("buffered up");
                bufferedDirection = ClimbingDirection.Up;
            }

        }

        else if (Input.GetKeyDown(KeyCode.A)) {
            if (alreadyMoving == false) {
                if (transform.position.x - tileLength > leftLimit) {
                    alreadyMoving = true;
                    StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(-1*tileLength,0,0)));
                }
            }
            else {
                // Debug.Log("buffered left");
                bufferedDirection = ClimbingDirection.Left;
            }
        }

        else if (Input.GetKeyDown(KeyCode.S)) {
            if (alreadyMoving == false) {
                if (transform.position.y - tileLength >= 0) {
                    alreadyMoving = true;
                    StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(0,-1*tileLength,0)));
                }
            }
            else {
                // Debug.Log("buffered down");
                bufferedDirection = ClimbingDirection.Down;
            }
        }

        else if (Input.GetKeyDown(KeyCode.D)) {
            if (alreadyMoving == false) {
                if (transform.position.x + tileLength < rightLimit) {
                    alreadyMoving = true;
                    StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(tileLength,0,0)));
                }
            }
            else {
                // Debug.Log("buffered right");
                bufferedDirection = ClimbingDirection.Right;
            }
        }
    }
}


public enum ClimbingDirection {  
    None,
    Up,
    Down,
    Left,
    Right
}