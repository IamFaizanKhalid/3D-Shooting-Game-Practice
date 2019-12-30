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

    public float waitTime;
    private float currentWait;
    private bool shot;

    public GameObject bullet;
    public GameObject bulletSpwanPoint;
    private Transform bulletSpwaned;

    // Methods
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Update()
    {
        if (health<=0)
            Die();

        this.transform.LookAt(player.transform);

        if (currentWait==0)
            Shoot();
        if (shot && currentWait < waitTime)
            currentWait += 1 * Time.deltaTime;

        if (currentWait >= waitTime)
            currentWait = 0;
    }

    private void Shoot()
    {
        shot = true;
        bulletSpwaned = Instantiate(bullet.transform, bulletSpwanPoint.transform.position, Quaternion.identity);
        bulletSpwaned.rotation = this.transform.rotation;
    }

    public void Die()
    {
        player.GetComponent<Player>().points += pointsToGive;
        Destroy(this.gameObject);
    }
}
