using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Script : MonoBehaviour
{
    int score;

    private static int enemies;

    public Text scoreCount;

    void Start()
    {

    }

    private void Update()
    {
        SetScoreText();
        score = Wave_Manager.EnemiesLeft;
    }


    void SetScoreText()
    {
        scoreCount.text = "Enemies : " + score.ToString();
    }
}
