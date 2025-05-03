using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EToEnter : MonoBehaviour
{
    public Transform teleportPoint;
    public GameObject text;
    private void Start()
    {
        text.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") text.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                other.transform.position = teleportPoint.position;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
}
