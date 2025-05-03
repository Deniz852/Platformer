using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Robot" || other.tag == "Player")
        {

        }
        else if (other.tag == "Pillar")
        {
            Pillar pillar = other.GetComponent<Pillar>();
            pillar.TakeDamage(1);
            Destroy(gameObject);
        }
        else
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }      
    }
}
