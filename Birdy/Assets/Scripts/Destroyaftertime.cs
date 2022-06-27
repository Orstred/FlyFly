using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyaftertime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Erase", 2f);
    }

  
    public void Erase()
    {
        Destroy(gameObject);
    }

}
