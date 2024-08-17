using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ObstacleSpawn : MonoBehaviour
{
    private int difficultyLevel = 1;
    private int nextDifficultySpikeElevation = 100;
    
    [SerializeField]
    private List<ObstacleBehavior> obstacles;
    

    // Update is called once per frame
    void Update()
    {
        ObstacleSpawningRoutine(difficultyLevel);

        if (transform.position.y > nextDifficultySpikeElevation) {
            difficultyLevel += 1;
            nextDifficultySpikeElevation += 100;
        }  
    }

    private void ObstacleSpawningRoutine(int difficultyLevel) {
        Random rnd = new Random();
        int spawnRoll  = rnd.Next(1, 11);  // creates a number between 1 and 11. if this number is bigger than the hazard level of an obstacle type, said obstacle is in the running to spawn.
        foreach (var obstacle in obstacles) {
            if (spawnRoll > obstacle.hazardLevel) {
                //change spawning below to happen at a rate that depends on difficultyLevel
                Instantiate(obstacle);
            }
        }
    }
}
