using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutCollider : MonoBehaviour
{
    public GameObject cutScene;
    private void Start()
    {
        cutScene.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cutScene.SetActive(true);
        }
    }
}
