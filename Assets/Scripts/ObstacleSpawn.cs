using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ObstacleSpawn : MonoBehaviour
{
    public int difficultyLevel = 1;
    public int nextDifficultySpikeElevation = 100;
    public float maxWaitTime = 5;
    
    [SerializeField]
    private List<ObstacleBehavior> obstacles;
    
    void Start() {
        StartCoroutine(ObstacleSpawningCoroutine(difficultyLevel));
    }

    void Update()
    {
        if (transform.position.y > nextDifficultySpikeElevation) {
            difficultyLevel += 1;
            if (maxWaitTime > 1) {
                maxWaitTime -= 0.2f;
            }
            nextDifficultySpikeElevation += 100;
        }  
    }

    private IEnumerator ObstacleSpawningCoroutine(int difficultyLevel) {
        Random rnd = new Random();
        foreach (var obstacle in obstacles) {
            
                int hazardRoll  = rnd.Next(1, 11);  // creates a number between 1 and 10. if this number is >= than the hazard level of an obstacle type, obstacle that satisfies this is the next obstacle that will spawn.
                
                if (hazardRoll >= obstacle.hazardLevel) {
                    //60% chance of spawning an obstacle ever time an obstacle is considered in the running
                    int spawnRoll  = rnd.Next(1, 11);
                    if (spawnRoll > 4) {
                        Instantiate(obstacle);
                    }
                }
            
        }

        yield return new WaitForSeconds((float) rnd.NextDouble()*maxWaitTime);
        StartCoroutine(ObstacleSpawningCoroutine(difficultyLevel));
    }
}
