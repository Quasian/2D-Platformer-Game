using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public GameObject[] healthimage;
    PlayerController playercontroller;



    void Start()
    {
        playercontroller = GetComponent<PlayerController>();
    }


    public void TakeDamage(int health)
    {
        health--;
        if (health <= 0)
        {
            Destroy(healthimage[health].gameObject);
            playercontroller.PlayerDeath();

        }
        else
        {
            Destroy(healthimage[health].gameObject);
        }
    
    
    }
}
