using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawnerManager : MonoBehaviour
{

    public Spawner SP1;
    public Spawner SP2;
    public Spawner SP3;

    public float WaveSpeed;
    float timer;

    private void Start()
    {
        timer = WaveSpeed;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SummonWave(Random.Range(0,6));
            timer = WaveSpeed;
        }
    }

    public void SummonWave(int Pattern = 0)
    {
        switch (Pattern)
        {
            case 0:
                SP1.FireMissile();
                break;
            case 1:
                SP2.FireMissile();
                break;
            case 2:
                SP3.FireMissile();
                break;
            case 3:
                SP1.FireMissile();
                SP3.FireMissile();
                break;
            case 4:
                SP1.FireMissile();
                SP2.FireMissile();
                break;
            case 5:
                SP2.FireMissile();
                SP3.FireMissile();
                break;
            case 6:
                //Do nothing
                break;
        
        }

    }
}
