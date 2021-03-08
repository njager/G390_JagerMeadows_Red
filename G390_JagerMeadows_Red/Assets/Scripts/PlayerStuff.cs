using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour
{
    //private variables
    private Rigidbody rB;
    private bool child;
    private bool itemOneFound = false;
    private bool itemTwoFound = false;
    private bool itemThreeFound = false;
    private bool itemFourFound = false;
    private bool itemFiveFound = false;
    private bool itemSixFound = false;

    //public variables
    public Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        //start stuff as child
        rB = GetComponent<Rigidbody>();
        child = true;
        playerCam.transform.Translate(0, -0.5f, 0);
    }

    //called last every frame
    private void FixedUpdate()
    {
        //detect mouse input
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse clicked!");

            //send out a raycast to detect collisions
            Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit interactionInfo;
            if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
            {
                //check the object interacted with, if the previous object has been found then this item can now be found
                GameObject interactedObject = interactionInfo.collider.gameObject;
                if (interactedObject.tag == "ItemOne")
                {
                    itemOneFound = true;
                    Debug.Log("You found item one!");
                }
                else if (itemOneFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemTwoFound = true;
                    Debug.Log("You found item two!");
                }
                else if (itemTwoFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemThreeFound = true;
                    Debug.Log("You found item three!");
                }
                else if (itemThreeFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemFourFound = true;
                    Debug.Log("You found item four!");
                }
                else if (itemFourFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemFiveFound = true;
                    Debug.Log("You found item five!");
                }
                else if (itemFiveFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemSixFound = true;
                    Debug.Log("You found item six!");
                    //put game end function call here
                }
                else
                {
                    Debug.Log("No object!");
                }
            }
        }
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