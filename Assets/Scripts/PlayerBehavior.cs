using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{

    //stats/condition
    public GregoryStats stats;

    public bool alive = true;
    public bool isVulnerable = true;
    public bool isHigh = false;
    private int maxHealth;
    private int currentHealth;
    private int cooldownReducer;
    AbilityType[] possibleAbilities = {AbilityType.None, AbilityType.Flamethrower, AbilityType.Shield, AbilityType.Regeneration};
    private AbilityType ability;

    //sound effect stuff
    AudioSource[] audioSources;
    private AudioSource DeathAudioSource;
    [SerializeField]
    private AudioClip lowElevationDeathClip;
    [SerializeField]
    private AudioClip highElevationDeathClip;

    private AudioSource SpawnAudioSource;
    [SerializeField]
    private AudioClip spawnClip;


    //the below are all the game objects and stuff that'll be used for the variaous abilities
    //a given layout for the robot might not need all of these cuz it wont necessarily have all the corresponding abilities, but we still pass them in regardless
    [SerializeField]
    FlameBehavior flameBehavior;
    
    public void ToggleShieldOn() {
        // this.gameObject.transform.GetChild(0).SetActive(true);
        Debug.Log("shield on");
        FindObjectOfType<ShieldBehavior>(includeInactive: true).gameObject.SetActive(true);  
        Debug.Log("sprite should be on");
        // gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void ToggleShieldOff() {
        Debug.Log("shield off");
        // gameObject.transform.GetChild(0).gameObject.SetActive(false);
        FindObjectOfType<ShieldBehavior>(includeInactive: true).gameObject.SetActive(false);  
    }

    private IEnumerator ChangeColorBack() {
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
    }

    public void PlayDeathSound()
    {
        if (transform.position.y < 500) {
            DeathAudioSource.clip = lowElevationDeathClip;
        }
        else {
            DeathAudioSource.clip = highElevationDeathClip;
        }
        DeathAudioSource.Play();
    }
    public void PlaySpawnSound()
    {
        SpawnAudioSource.clip = spawnClip;
        SpawnAudioSource.Play();
    }

    public void SetHealth(int health) {
        currentHealth = health;
        GameObject.Find("UI").GetComponent<HealthUI>().UpdateHealthUI(currentHealth);
    }
    
    public void DepleteHealth(int damage) {
        currentHealth -= damage;
        if (currentHealth < 0) {
            currentHealth = 0;
        }
        GameObject.Find("UI").GetComponent<HealthUI>().UpdateHealthUI(currentHealth);
        GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 1f);
        StartCoroutine(ChangeColorBack());
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        SpawnAudioSource = audioSources[0];
        DeathAudioSource = audioSources[1]; 
        ToggleShieldOff();

        PlaySpawnSound();


        maxHealth = stats.health;
        currentHealth = maxHealth; 
        GameObject.Find("UI").GetComponent<HealthUI>().UpdateHealthUI(currentHealth);
        cooldownReducer = stats.cooldownReduction;
        ability = possibleAbilities[stats.ability];
        if (ability != AbilityType.None) {
            StartCoroutine(AbilityActivatingCoroutine(ability));
        }
    }

    private IEnumerator AbilityActivatingCoroutine(AbilityType ability) {
        //yield return null : Pauses the coroutine until the next frame. yield return new WaitForSeconds(float seconds) : Pauses the coroutine for a specified number of seconds.
        if (ability == AbilityType.Flamethrower) {
            Debug.Log("flamethrower");
            float timeElapsed = 0;
            while(timeElapsed < 0.3f) {
                timeElapsed += Time.deltaTime;
                Instantiate(flameBehavior);
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(20-cooldownReducer);
            StartCoroutine(AbilityActivatingCoroutine(ability));
        }

        if (ability == AbilityType.Shield) {
            // Debug.Log("SHIELD WOOO");
            float timeElapsed = 0;
            isVulnerable = false;
            ToggleShieldOn();
            while (timeElapsed < 10) {
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            ToggleShieldOff();
            isVulnerable = true;
            yield return new WaitForSeconds(20-cooldownReducer);
            StartCoroutine(AbilityActivatingCoroutine(ability));
        }

        if (ability == AbilityType.Regeneration) {
            Debug.Log("regenerating");
            if (currentHealth < maxHealth) {
                SetHealth(currentHealth+1);
                GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 0f, 1f);
                StartCoroutine(ChangeColorBack());
            }

            yield return new WaitForSeconds(15-cooldownReducer);
            StartCoroutine(AbilityActivatingCoroutine(ability));
        }


    }

    public void Death() {
        alive = false;
        // Debug.Log("YOU DIED BOZOOOO");
        //this is where to add the code for what happens when game ends.
        PlayDeathSound();
        //then switch scene to gameover scene
        SceneManager.LoadScene("GameOverScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true && currentHealth <= 0) {
            Death();
        }   
    }


}


public enum AbilityType {  //obstacletype of the obstacle the script is attached to will affect the obstacles behavior
    None,
    Flamethrower,
    Shield,
    Regeneration
}
