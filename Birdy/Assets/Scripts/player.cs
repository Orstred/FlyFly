using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{


    int currentpos = 1;
    public int Health = 1;
    public List<Transform> Positions;
    public Transform Target;
    public float LerpSpeed;
 

    private Vector3 starttouchposition = Vector3.zero;
    private Vector3 endtouchposition = Vector3.zero;

    private void Start()
    {
#if PLATFORM_ANDROID
#if !UNITY_EDITOR
        LerpSpeed = 15;
#endif
#endif

        Target.position = Positions[currentpos].position;
        Target.parent = null;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PlayerPrefs.DeleteKey("HighScore");


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            GoUp();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            GoDown();
        }


        //Touch Inputs
        MoveWithtouch();

        #region Deprecated
        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
           starttouchposition = Input.GetTouch(0).position;

        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
           endtouchposition = Input.GetTouch(0).position;

            if (endtouchposition.y > starttouchposition.y + 0.1f)
            {
                GoUp();

            }

            else if (endtouchposition.y < starttouchposition.y - 0.1f)
            {
                GoDown();
            }
                
        }
        */
        #endregion
    }


    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, LerpSpeed * Time.deltaTime);
    }


    public void MoveWithtouch()
    {
        if(Input.touchCount > 0)
        {
            Vector3 tempv3 = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y, transform.position.z);
            
            foreach (Transform t in Positions)
            {
               if(Vector3.Distance(t.position,tempv3) < Vector3.Distance(Target.position, tempv3))
               {
                    Target = t;
               }
            }
          
        }
    }

    public void GoUp()
    {
        if(currentpos + 2 <= Positions.Count)
        {
            currentpos++;
            Target.position = Positions[currentpos].position;
           
        }
    }
    public void GoDown()
    {
        if (currentpos - 1 >= 0)
        { 
           currentpos--;
           Target.position = Positions[currentpos].position;
         
        }
    }


    public void LooseHealth(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            //OnDeath
            Debug.Log("You died");

            PlayerPrefs.SetInt("NumberOfDeaths", PlayerPrefs.GetInt("NumberOfDeaths") + 1);

            if(PlayerPrefs.GetInt("HighScore") < ScoreHandler.instance.Score)
            ScoreHandler.instance.SaveHighScore();

            SceneManager.LoadScene(0);
        }
    }
}
