using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public int index;
    // public string levelName;
    public Image black;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("pressed R");
            StartCoroutine(Fading());// + move * 10.0f * d * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Fading());// + move * 10.0f * d * Time.deltaTime;
        }
    }
    IEnumerator Fading()
    {
        Debug.Log("fading");
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        // yield return new WaitForSeconds(1);
        Debug.Log(index);
        SceneManager.LoadScene(index);
        //anim.SetBool("Fade", false);
    }
    IEnumerator FadingOther()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}