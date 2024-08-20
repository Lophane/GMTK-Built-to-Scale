using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JButtons : MonoBehaviour
{

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("moving to " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void BuildGregory(string sceneName)
    {
        Debug.Log("moving to " + sceneName);
        playerStats.PushGregoryStats();
        SceneManager.LoadScene(sceneName);
    }


    public void QuitApplication()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
