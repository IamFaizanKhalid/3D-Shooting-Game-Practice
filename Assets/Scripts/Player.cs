﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float movementSpeed;
    public GameObject playerObj;

    public GameObject bullet;
    public GameObject bulletSpwanPoint;
    public float waitTime;

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


        // Player movement
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);


        // Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet.transform, bulletSpwanPoint.transform.position, Quaternion.identity);
    }
}