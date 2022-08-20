using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScoreView : MonoBehaviour
{
    private TextMeshProUGUI textResultScore;

    void Awake()
    {
        textResultScore = GetComponent<TextMeshProUGUI>();
        int score = PlayerPrefs.GetInt("Score");
        textResultScore.text = "Reuslt Score " + score;
    }
}
