﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Variables
    public float bulletSpeed;
    private float maxDistance = 0;
    public float damage;

    private GameObject triggeringEnemy;
    private GameObject player;

    // Methods
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        maxDistance += Time.deltaTime;

        if (maxDistance >= 5)
            Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            player.GetComponent<Player>().health -= 20;
            Destroy(this.gameObject);
        }

    }
}
