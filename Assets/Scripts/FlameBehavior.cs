using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehavior : MonoBehaviour
{
    private Transform flameSource;
    private FlameDirection direction = FlameDirection.Up;
    private float flameStrength = 0.01f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("fire spawned");
        flameSource = GameObject.Find("Player").transform;
        transform.position = flameSource.position + new Vector3(0f, 0.1f, 0f);
        StartCoroutine(FlameMovementCoroutine(direction, 5f));
    }

    private IEnumerator FlameMovementCoroutine(FlameDirection direction, float flameDuration) {
        float timeElapsed = 0;
        while (timeElapsed < flameDuration) {
            timeElapsed += Time.deltaTime;
            float lerpStep = timeElapsed/flameDuration;
            transform.position = Vector3.Lerp(flameSource.position + new Vector3(0f, 0.1f, 0f), flameSource.position  + new Vector3(0f, 0.1f, 0f) + new Vector3(0f, 30f, 0f), lerpStep);
            yield return null;
        }
        
        Destroy(this.gameObject);
        
    }


    void Update()
    {
        // foreach (var obstacle in FindObjectsOfType<ObstacleBehavior>()) {
        //     if (this.GetComponent<Collider2D>().IsTouching(obstacle.GetComponent<Collider2D>())) {
        //         obstacle.depleteDurability(flameStrength);
        //     }
        // }
        if (transform.position.y > flameSource.transform.position.y + 5) {
            Destroy(this.gameObject);
        }
  
    }

    private void OnParticleCollision(GameObject obstacle)
    {
        // Debug.Log("fire collision");
        if (obstacle.gameObject.GetComponent<ObstacleBehavior>() != null)
        {
            // Debug.Log("collision fire and object");
            obstacle.gameObject.GetComponent<ObstacleBehavior>().depleteDurability(flameStrength);
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
