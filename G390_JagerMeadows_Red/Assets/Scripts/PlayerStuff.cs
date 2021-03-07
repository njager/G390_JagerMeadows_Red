using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour
{
    //private variables
    private Rigidbody rB;
    private bool child;

    //public variables
    public Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        child = true;
        playerCam.transform.Translate(0, -0.5f, 0);
    }

    //called last every frame
    private void FixedUpdate()
    {
        
    }

    //detect going through the mirror
    private void OnTriggerEnter(Collider other)
    {
        //if currently a child, become an adult
        if (child == true && other.CompareTag("Mirror"))
        {
            child = false;
            playerCam.transform.Translate(0, 0.5f, 0);
            Debug.Log("You're an adult!");
        }
        //if currently a adult, become an child
        else if (child == false && other.CompareTag("Mirror"))
        {
            child = true;
            playerCam.transform.Translate(0, -0.5f, 0);
            Debug.Log("You're a child!");
        }
    }
}
