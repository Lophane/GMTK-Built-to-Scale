using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField]
    private BackgroundMusicType backgroundMusicType;
    [SerializeField]
    private AudioClip lowElevationClimbingMusicClip;
    [SerializeField]
    private AudioClip highElevationClimbingMusicClip;
    [SerializeField]
    private AudioClip customizationMusicClip;

    // Start is called before the first frame update
    void Awake()
    {
        if (backgroundMusicType == BackgroundMusicType.Climbing) {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = lowElevationClimbingMusicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        if (backgroundMusicType == BackgroundMusicType.Customization) {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = customizationMusicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (backgroundMusicType == BackgroundMusicType.Climbing) {
            PlayerBehavior player = FindObjectOfType<PlayerBehavior>();
            // if (player.isHigh == false && player.transform.position.y > 500) {
            //     player.isHigh = true;
            //     audioSource.clip = highElevationClimbingMusicClip;
            //     audioSource.Play();
            // }

            if (player.alive == false) {
                audioSource.Stop();
            }
        }
    }
}

public enum BackgroundMusicType {  
    None,
    Climbing,
    Customization
}
