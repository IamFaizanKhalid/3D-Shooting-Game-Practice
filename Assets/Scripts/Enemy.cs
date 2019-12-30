using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables
    public float health;

    public GameObject player;
    public float pointsToGive;


    // Methods
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Update()
    {
        if (health<=0)
        {
            Die();
        }
    }

    public void Die()
    {
        player.GetComponent<Player>().points += pointsToGive;
        Destroy(this.gameObject);
    }
}
