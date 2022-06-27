using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreHandler : MonoBehaviour
{
    #region Singleton
    public static ScoreHandler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    #endregion

    public int Score;

    public int HighScore;

    Text scoredisplay;

    private void Start()
    {
        scoredisplay = GetComponent<Text>();
    }

    public void GetPoint(int point)
    {
        Score += point;

        scoredisplay.text = Convert.ToString(Score);
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", Score);
    }


}
