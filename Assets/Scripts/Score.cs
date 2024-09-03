using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ballCounter;

    public static int score;

    void Update()
    {
        ballCounter.text = "Score: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }
}
