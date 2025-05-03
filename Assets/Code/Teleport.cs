using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportPoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
             other.transform.position = teleportPoint.position;
        }      
    }
}
