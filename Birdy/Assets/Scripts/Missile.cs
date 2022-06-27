using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 1;
    public int Damage = 1;
    public GameObject Explosion;

    float staytime = 2f;


    void Update()
    {
        transform.position = new Vector3(transform.position.x + -speed * Time.deltaTime, transform.position.y, transform.position.z);


        staytime -= Time.deltaTime;
        if(staytime <= 0)
        {
            ScoreHandler.instance.GetPoint(1);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            HitPlayer(collision.transform.GetComponent<player>());
        }
    }

    public void HitPlayer(player pl)
    {
        pl.LooseHealth(1);
        Instantiate(Explosion,transform.position,Quaternion.identity);
    Destroy(gameObject);
    }
}
