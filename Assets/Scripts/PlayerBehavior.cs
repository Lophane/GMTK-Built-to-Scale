using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    //stats
    private int maxHealth = 1;
    private int currentHealth;
    private int cooldownReducer = 0;
    [SerializeField]
    private List<AbilityType> abilities;


    //the below are all the game objects and stuff that'll be used for the variaous abilities
    //a given layout for the robot might not need all of these cuz it wont necessarily have all the corresponding abilities, but we still pass them in regardless
    [SerializeField]
    FlameBehavior flameBehavior;


    
    public void depleteHealth(int damage) {
        currentHealth -= damage;
        if (currentHealth < 0) {
            currentHealth = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 

        foreach (var ability in abilities) {
            StartCoroutine(AbilityActivatingCoroutine(ability));
        }
    }

    private IEnumerator AbilityActivatingCoroutine(AbilityType ability) {
        if (ability == AbilityType.Flamethrower) {
            float timeElapsed = 0;
            while(timeElapsed < 3) {
                timeElapsed += Time.deltaTime;
                Instantiate(flameBehavior);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(40-cooldownReducer);
            StartCoroutine(AbilityActivatingCoroutine(ability));
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) {
            //this is where to add the code for what happens when game ends. below is just a placeholder.
            Debug.Log("teehee you are dead");
        }   
    }
}


public enum AbilityType {  //obstacletype of the obstacle the script is attached to will affect the obstacles behavior
    None,
    Flamethrower,
    Shield
}
