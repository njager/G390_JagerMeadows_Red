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
    public GameObject AdultModel;
    public GameObject ChildModel;
    public GameObject Mirror;
    public AudioClip chime;
    public AudioClip pop;
    public AudioClip woosh;
    AudioSource audioSource;
    public GameObject finaldoor;
    public Animator finalanim;
    public GameObject cabinet;
    public Animator cabinetanim;
    public Material NextRed;
    public GameObject tag2mat;
    public GameObject tag3mat;
    public GameObject tag4mat;
    public GameObject tag5mat;
    public GameObject tag6mat;
    public GameObject i1;
    public GameObject i2;
    public GameObject i3;
    public GameObject i4;
    public GameObject i5;
    public GameObject i6;
    public GameObject tag2mat2;
    public GameObject tag3mat2;
    public GameObject tag4mat2;
    public GameObject tag5mat2;
    public GameObject tag6mat2;
    public GameObject i12;
    public GameObject i22;
    public GameObject i32;
    public GameObject i42;
    public GameObject i52;
    public GameObject i62;

    //public variables
    public Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        //start stuff as child
        rB = GetComponent<Rigidbody>();
        child = true;
        playerCam.transform.Translate(0, -0.5f, 0);
        audioSource = GetComponent<AudioSource>();
        finalanim = finaldoor.GetComponent<Animator>();
        cabinetanim = cabinet.GetComponent<Animator>();
        
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
                    audioSource.PlayOneShot(chime, 0.5F);
                    tag2mat.GetComponent<MeshRenderer>().material = NextRed;
                    i1.SetActive(false);
                    tag2mat2.GetComponent<MeshRenderer>().material = NextRed;
                    i12.SetActive(false);

                }
                else if (itemOneFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemTwoFound = true;
                    Debug.Log("You found item two!");
                    audioSource.PlayOneShot(chime, 0.5F);
                    tag3mat.GetComponent<MeshRenderer>().material = NextRed;
                    i2.SetActive(false);
                    tag3mat2.GetComponent<MeshRenderer>().material = NextRed;
                    i22.SetActive(false);
                }
                else if (itemTwoFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemThreeFound = true;
                    Debug.Log("You found item three!");
                    audioSource.PlayOneShot(chime, 0.5F);
                    tag4mat.GetComponent<MeshRenderer>().material = NextRed;
                    i3.SetActive(false);
                    tag4mat2.GetComponent<MeshRenderer>().material = NextRed;
                    i32.SetActive(false);
                }
                else if (itemThreeFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemFourFound = true;
                    Debug.Log("You found item four!");
                    audioSource.PlayOneShot(chime, 0.5F);
                    tag5mat.GetComponent<MeshRenderer>().material = NextRed;
                    i4.SetActive(false);
                    tag5mat2.GetComponent<MeshRenderer>().material = NextRed;
                    i42.SetActive(false);
                }
                else if (itemFourFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemFiveFound = true;
                    Debug.Log("You found item five!");
                    audioSource.PlayOneShot(chime, 0.5F);
                    cabinetanim.SetTrigger("OpenClose");
                    tag5mat.GetComponent<MeshRenderer>().material = NextRed;
                    i5.SetActive(false);
                    tag5mat2.GetComponent<MeshRenderer>().material = NextRed;
                    i52.SetActive(false);
                }
                else if (itemFiveFound == true && interactedObject.tag == "ItemTwo")
                {
                    itemSixFound = true;
                    Debug.Log("You found item six!");
                    audioSource.PlayOneShot(chime, 0.5F);
                    finalanim.SetTrigger("OpenClose");
                    i6.SetActive(false);
                    i62.SetActive(false);
                    //put game end function call here
                }
                else
                {
                    audioSource.PlayOneShot(pop, 0.2F);
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
            playerCam.transform.Translate(0, 1.5f, 0, Space.World);
            //Mirror.transform.Translate(0, 0, 1);
            Mirror.transform.Rotate(0, 180, 0);
            Debug.Log("You're an adult!");
            ChildModel.SetActive(false);
            AdultModel.SetActive(true);
            audioSource.PlayOneShot(woosh, 0.7F);
        }
        //if currently a adult, become an child
        else if (child == false && other.CompareTag("Mirror"))
        {
            child = true;
            playerCam.transform.Translate(0, -1.5f, 0, Space.World);
            //Mirror.transform.Translate(0, 0, -1);
            Mirror.transform.Rotate(0, -180, 0);
            Debug.Log("You're a child!");
            AdultModel.SetActive(false);
            ChildModel.SetActive(true);
            audioSource.PlayOneShot(woosh, 0.7F);
        }
    }

}