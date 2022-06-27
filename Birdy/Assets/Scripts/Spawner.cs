using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Missile;

 


    public void FireMissile()
    {
        Instantiate(Missile,transform.position, transform.rotation);
      
    }
}
