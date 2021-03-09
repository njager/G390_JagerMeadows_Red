using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dooropen : MonoBehaviour
{
    public Component[] Lights;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "rollydude")
        {
            //add the code you want to execute on collision

            Animator anim = GetComponentInChildren<Animator>();
            anim.SetTrigger("OpenClose");


            //to access the Ball gameObject use : col.gameObject
            foreach (Light l in this.GetComponentsInChildren<Light>())
                l.intensity = 7;

        }
        else
        {
            
            foreach (Light l in this.GetComponentsInChildren<Light>())
                l.intensity = 0;
        }

        }
    }
