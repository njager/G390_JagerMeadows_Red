using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endofgame : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Application.Quit();
        Debug.Log("Game has ended");
    }
}

