using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionscript : MonoBehaviour
{
    public GameObject AdultModel;
    public GameObject ChildModel;
    public GameObject AdultCamera;
    public GameObject ChildCamera;
    public static bool age;
    // Start is called before the first frame update
    void Start()
    {
        age = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraheight.isMirror == true)
        {

            if (cameraheight.isChild == true)
            {
                if (age == false)
                {
                    ChildModel.SetActive(false);
                    AdultModel.SetActive(true);
                    ChildCamera.SetActive(false);
                    AdultCamera.SetActive(true);
                    age = true;
                }

            }
            if (cameraheight.isChild == false)
            {
                if (age == true)
                {
                    AdultModel.SetActive(false);
                    ChildModel.SetActive(true);
                    AdultCamera.SetActive(false);
                    ChildCamera.SetActive(true);
                    age = true;
                }

            }
        }

        
    }
    
}
