﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Variables
    public float movementSpeed;
    public GameObject playerObj;

    public GameObject bullet;
    public GameObject bulletSpwanPoint;
    //public float waitTime;
    //private float currentWait = 0;

    private Transform bulletSpwaned;

    public float points;
    public Text pointsText;

    public float health;
    public Text healthText;

    // Methods

    void Update()
    {

        // Player facing mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint, transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        // Shooting
        if (Input.GetMouseButtonDown(0))
            Shoot();
        /*
        if (Input.GetMouseButton(0))
            if (currentWait == 0)
                Shoot();
        if (currentWait < waitTime)
           currentWait += 1 * Time.deltaTime;

        if (currentWait >= waitTime)
            currentWait = 0;
        */

        // Player movement
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody myPlayer = this.GetComponent<Rigidbody>();
            if (myPlayer.transform.position.y<0.2f)
                myPlayer.AddForce(0, 1, 0, ForceMode.Impulse);
        }

        healthText.text = "Health: " + health;
        pointsText.text = "Score: " + points;

        if (health <= 0)
            Die();
    }

    private void Shoot()
    {
        bulletSpwaned = Instantiate(bullet.transform, bulletSpwanPoint.transform.position, Quaternion.identity);
        bulletSpwaned.rotation = bulletSpwanPoint.transform.rotation;
    }


    public void Die()
    {
        Destroy(this.gameObject);
    }
}
