using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreField : MonoBehaviour
{
    public TextMeshProUGUI score;

    public void Start()
    {
        float num = ((-Time.realtimeSinceStartup) + 5050);
        if(num < 0)
        {
            num = 0;
        }
        string text = num.ToString("N0");
        score.text = "YOUR SCORE: " + text;
    }
}
