using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 10;
    public int maxHealth = 10;
    public int coins = 0;
    public GameObject fireballPrefab;
    public Transform attackPoint;

    public void GetCoin()
    {
        coins++;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        print("Çהמנמגüו:" + health);
        if(health <= 0)
        {
            int sceneIndex = 0;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, attackPoint.position, attackPoint.rotation);
        }
    }
}
