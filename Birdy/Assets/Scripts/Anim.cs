using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{

    Animator ani;

    float previousheight;
    Transform Target;

    private void Start()
    {
        ani = GetComponent<Animator>();
        Target = GetComponentInParent<player>().Target;
    }

    private void Update()
    {

        

        if (previousheight < transform.position.y - 0.01f)
        {
            Clearani();
            ani.SetBool("GoingUp", true);
        }
        else if (previousheight > transform.position.y + 0.01f)
        {
            Clearani();
            ani.SetBool("GoingDown", true);
        }

        if( Vector3.Distance(transform.parent.transform.position, Target.position) < 0.05f)
            Clearani();
    }

    private void LateUpdate()
    {
        previousheight = transform.position.y;
    }

    public void Clearani()
    {
        ani.SetBool("GoingUp", false);
        ani.SetBool("GoingDown", false);
    }
}
