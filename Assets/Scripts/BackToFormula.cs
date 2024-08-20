using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BackToFormula : MonoBehaviour
{
    [Header("Button Objects")]
    public Button btn;
    //public GameObject myPrefab;
    // Start is called before the first frame update

    private void Awake()
    {
        // adding a delegate with no parameters
        btn.onClick.AddListener(goToClimb);

        // adding a delegate with parameters
        //btn.onClick.AddListener(delegate { ParameterOnClick("Button was pressed!"); });
    }

    private void goToClimb()
    {
        SceneManager.LoadScene("TitleScreen"); //Change to scene of climby thing
    }

}
