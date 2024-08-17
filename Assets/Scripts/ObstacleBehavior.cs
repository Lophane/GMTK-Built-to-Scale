using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public ObstacleType obstacleType;
    public int hazardLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        if (obstacleType == ObstacleType.Boulder) {
            hazardLevel = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ObstacleType {  //obstacletype of the obstacle the script is attached to will affect the obstacles behavior
    None,
    Boulder,
    Spider,
    Fire
}
