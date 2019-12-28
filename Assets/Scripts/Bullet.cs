using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    private float maxDistance = 0;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        maxDistance += Time.deltaTime;

        if (maxDistance >= 5)
            Destroy(this.gameObject);
    }
}
