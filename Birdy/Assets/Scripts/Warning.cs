using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Warning : MonoBehaviour
{

    public Text CountDown;
    public Transform Missile;
    public Transform Spawner;
    Image img;
    float timer;

    private void Update()
    {
        CountDown.text = Convert.ToString(timer);

        timer -= Time.deltaTime;
     
        if(timer <= 0)
        {
            Instantiate(Missile, Spawner.position, Spawner.rotation);
        }
    }

   

}
