using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartMenu : MonoBehaviour
{

    public Text Highscore;
    public int DeathsBeforeAdd;



    void Start()
    {
        if (PlayerPrefs.GetInt("NumberOfDeaths") >= DeathsBeforeAdd)
        {
            RunAdd();
            PlayerPrefs.DeleteKey("NumberOfDeaths");
        }

        Highscore.text = Convert.ToString(PlayerPrefs.GetInt("HighScore"));
      
        Time.timeScale = 0;
    }

    
    void Update()
    {
        if (Time.timeScale == 0 && Input.anyKeyDown)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
        if (Time.timeScale == 0 && Input.touchCount > 0)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }

    public void RunAdd()
    {
        Debug.Log("RunningAdd");
    }
}
