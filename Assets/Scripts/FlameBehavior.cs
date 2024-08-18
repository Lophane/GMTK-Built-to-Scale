using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehavior : MonoBehaviour
{
    private Transform flameSource;
    private FlameDirection direction = FlameDirection.Up;
    private int flameStrength = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        flameSource = GameObject.Find("Player").transform;
        transform.position = flameSource.position + new Vector3(0f, 1f, 0f);
        StartCoroutine(FlameMovementCoroutine(direction, 5f));
    }

    private IEnumerator FlameMovementCoroutine(FlameDirection direction, float flameDuration) {
        float timeElapsed = 0;
        while (timeElapsed < flameDuration) {
            timeElapsed += Time.deltaTime;
            float lerpStep = timeElapsed/flameDuration;
            transform.position = Vector3.Lerp(flameSource.position + new Vector3(0f, 1f, 0f), flameSource.position  + new Vector3(0f, 1f, 0f) + new Vector3(0f, 30f, 0f), lerpStep);
            yield return null;
        }
        Destroy(this.gameObject);
        
    }


    void Update()
    {
        foreach (var obstacle in FindObjectsOfType<ObstacleBehavior>()) {
            if (this.GetComponent<Collider2D>().IsTouching(obstacle.GetComponent<Collider2D>())) {
                obstacle.depleteDurability(flameStrength);
            }
        }
  
    }



}

public enum FlameDirection {  
    None,
    Up,
    Down,
    Left,
    Right
}
