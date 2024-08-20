using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public GameObject targetObject;  
    public TMP_Text targetText;     
    public int offset = -3;     

    void Update()
    {
         int verticalPosition = ((int) targetObject.transform.position.y + offset)/2;

         targetText.text = "Height: " + verticalPosition.ToString();
        
    }
}
