using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatarswap : MonoBehaviour
{
    public GameObject AdultModel;
    public Avatar AdultAvatar;
    public GameObject ChildModel;
    public Avatar ChildAvatar;
    public GameObject Player;
    public Animator anim;

    public static bool age;


    private void Start()
    {
        

        ChildModel.SetActive (true);
        Player.GetComponent<Animator>().avatar = ChildAvatar;
        ChildModel.transform.SetParent(Player.transform);
        ChildModel.transform.localPosition = new Vector3(0, 0, 0);
        Player.GetComponent<Animator>().Rebind();

        age = false;
    }

    // Use this for initialization


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Mirror")
        { 
            if (age == false)
            {
                ChildModel.SetActive (false);
                AdultModel.SetActive (true);
                //Destroy(anim.avatar);
                Player.GetComponent<Animator>().avatar = AdultAvatar;
                
                
                AdultModel.transform.SetParent(Player.transform);
                AdultModel.transform.localPosition = new Vector3(0, 0, 0);
                Player.GetComponent<Animator>().Rebind();

                age = true;
                Debug.Log("this is adult swap");
            }
            if (age == true)
            {
                AdultModel.SetActive (false);
                ChildModel.SetActive (true);
                //Destroy(anim.avatar);
                Player.GetComponent<Animator>().avatar = ChildAvatar;
                
                
                ChildModel.transform.SetParent(Player.transform);
                ChildModel.transform.localPosition = new Vector3(0, 0, 0);
                Player.GetComponent<Animator>().Rebind();

                age = false;
                Debug.Log("this is child swap");
            }

            
        }
    }

}
