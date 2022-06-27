using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dontdest : MonoBehaviour
{

    #region singleton
    public static Dontdest instance;
        private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
            instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
    DontDestroyOnLoad(gameObject);
    }


}
