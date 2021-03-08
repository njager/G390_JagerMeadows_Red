using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraheight : MonoBehaviour

  
{
    public static bool isChild;
    public static bool isMirror;
    // Start is called before the first frame update
    void Start()
    {
        isChild = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //GameObject.transform.position = new Vector3(x, y, z);

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Mirror")
        {
            isMirror = true;

            if (isChild == true)
            {
                isChild = false;
                isMirror = false;
            }

            if (isChild == false)
            {
                isChild = true;
                isMirror = false;
            }


        }
    }
}