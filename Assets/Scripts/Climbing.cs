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
    private bool alreadyFalling = false;

    private GameObject Player;

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

    void Awake() {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        if (alreadyFalling == false && (transform.position.x < leftLimit || transform.position.x > rightLimit)) {
            alreadyFalling = true;
            Rigidbody2D tempRigidBody = Player.AddComponent<Rigidbody2D>();
        }
        if (alreadyFalling == true && !(transform.position.x < leftLimit || transform.position.x > rightLimit)) {
            alreadyFalling = false;
            Destroy(Player.GetComponent<Rigidbody2D>());
        }

        if(transform.position.y < 0 && Player.GetComponent<PlayerBehavior>().alive == true) {
            Player.GetComponent<PlayerBehavior>().Death();
        }
        
        if (alreadyMoving == false && bufferedDirection != ClimbingDirection.None) {
            alreadyMoving = true;
            if (bufferedDirection == ClimbingDirection.Up) {
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(0,tileLength,0)));
            }
            else if (bufferedDirection == ClimbingDirection.Left) {
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(-1*tileLength,0,0)));
            }
            else if (bufferedDirection == ClimbingDirection.Down) {
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(0,-1*tileLength,0)));
            }
            else if (bufferedDirection == ClimbingDirection.Right) {
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(tileLength,0,0)));
            }
            bufferedDirection = ClimbingDirection.None;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            if (alreadyMoving == false) {
                alreadyMoving = true;
                StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(0,tileLength,0)));
            }
            else {
                bufferedDirection = ClimbingDirection.Up;
            }

        }

        else if (Input.GetKeyDown(KeyCode.A)) {
            if (alreadyMoving == false) {
                // if (transform.position.x - tileLength > leftLimit) {
                    alreadyMoving = true;
                    StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(-1*tileLength,0,0)));
                // }
            }
            else {
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
                bufferedDirection = ClimbingDirection.Down;
            }
        }

        else if (Input.GetKeyDown(KeyCode.D)) {
            if (alreadyMoving == false) {
                // if (transform.position.x + tileLength < rightLimit) {
                    alreadyMoving = true;
                    StartCoroutine(ClimbInDirection(transform.position, transform.position + new Vector3(tileLength,0,0)));
                // }
            }
            else {
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