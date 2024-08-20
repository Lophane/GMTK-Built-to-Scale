using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverTG : MonoBehaviour
{
    public Transform levelCanvas;

    int up1 = 1;
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < up1; j++)
        {
            var mytext = CreateText(levelCanvas);
            mytext.text = "Game Over";
            mytext.color = new Color(255, 0, 0, 100);
            mytext.transform.position = new Vector3(1000, 1000, 0);
            Instantiate(mytext, new Vector3(440, 193, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    static TextMeshPro CreateText(Transform parent)
    {
        var go = new GameObject();
        go.transform.parent = parent;
        var text = go.AddComponent<TextMeshPro>();
        text.fontSize = 400;
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(209, 20);
        //text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        return text;
    }
    void Update()
    {

    }
}
