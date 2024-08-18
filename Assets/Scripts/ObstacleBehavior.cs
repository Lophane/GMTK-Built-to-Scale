using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ObstacleBehavior : MonoBehaviour
{
    //these below variables will be set in the inspector for the prefabs of each unique obstacletype
    public ObstacleType obstacleType;
    public int hazardLevel;
    private int durability;
    private GameObject target;
    
    private void Awake()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        target = GameObject.Find("Player");
        Climbing climbing = target.GetComponent<Climbing>();
        if (obstacleType == ObstacleType.Boulder) {
            hazardLevel = 1;
            durability = 1;
        }
        if (obstacleType == ObstacleType.Gargoyle) {
            hazardLevel = 3;
            durability = 3;
        }
        Random rnd = new Random();
        transform.position = new Vector3(((float) rnd.NextDouble()) * (climbing.rightLimit - climbing.leftLimit) + climbing.leftLimit, target.transform.position.y + 20f, 0f);

        StartCoroutine(ObstacleMovementCoroutine(obstacleType));
    }

    public void depleteDurability(int damage) {
        durability -= damage;
        if (durability < 0) {
            durability = 0;
        }
    }

    private IEnumerator ObstacleMovementCoroutine(ObstacleType obstacleType) {
        ObstacleSpawn obstacleSpawn = target.GetComponent<ObstacleSpawn>();

        if (obstacleType == ObstacleType.Boulder) {
            Vector3 startPosition = transform.position;
            float timeElapsed = 0;
            float fallDuration = 5f - obstacleSpawn.difficultyLevel/5;
            if (fallDuration <= 0) {
                fallDuration = 0.5f;
            }

            while (timeElapsed < fallDuration) {
                timeElapsed += Time.deltaTime;
                float lerpStep = timeElapsed/fallDuration;
                transform.position = Vector3.Lerp(startPosition,startPosition + new Vector3(0f, -30f, 0f), lerpStep);
                yield return null;
            }
        }

        if (obstacleType == ObstacleType.Gargoyle) {
            Vector3 startPosition = transform.position;
            float timeElapsed = 0;
            float fallDuration = 5f - obstacleSpawn.difficultyLevel/5;
            if (fallDuration <= 0) {
                fallDuration = 0.5f;
            }

            while (timeElapsed < fallDuration) {
                timeElapsed += Time.deltaTime;
                float lerpStep = timeElapsed/fallDuration;
                if (startPosition.x < 0) {
                    transform.position = Vector3.Lerp(startPosition, startPosition + new Vector3(10f, -40f, 0f), lerpStep);
                }
                if (startPosition.x > 0) {
                    transform.position = Vector3.Lerp(startPosition, startPosition + new Vector3(-10f, -40f, 0f), lerpStep);
                }
                yield return null;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if obstacle hits player, damage player and blow up obstacle
        PlayerBehavior playerBehavior = target.GetComponent<PlayerBehavior>();
        if (this.GetComponent<Collider2D>().IsTouching(target.GetComponent<Collider2D>())) {
            playerBehavior.depleteHealth(hazardLevel);
            if (obstacleType == ObstacleType.Boulder) {
                // play different animation
                Destroy(this.gameObject);
            }
            if (obstacleType == ObstacleType.Gargoyle) {
                // play different animation
                Destroy(this.gameObject);
            }
        }

        if (durability <= 0) {
            Destroy(this.gameObject);
        }



        Climbing climbing = target.GetComponent<Climbing>();
        if (transform.position.y < climbing.transform.position.y - 20f) {
            Destroy(this.gameObject);
        }
    }
}

public enum ObstacleType {  //obstacletype of the obstacle the script is attached to will affect the obstacles behavior
    None,
    Boulder,
    Gargoyle,
    Fire
}
