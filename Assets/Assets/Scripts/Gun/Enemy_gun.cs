using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_gun : MonoBehaviour {

    public GameObject sleeve;
    public GameObject bullet;
    public float fireRateLimit = 0.9f;

    private GameObject bulletSpawnPoint;
    private GameObject sleeveSpawnPoint;
    private float randomShooting;
    private float fireCount;


    void Start()
    {
        bulletSpawnPoint = Custom.findChildWithTag(gameObject, "bulletSpawn");
        sleeveSpawnPoint = Custom.findChildWithTag(gameObject, "sleeveSpawn");

    }

    private void FixedUpdate()
    {
        randomShooting = (Random.Range(0f, 1f));


        if (randomShooting > fireRateLimit)
        {
            Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);

            Instantiate(sleeve, sleeveSpawnPoint.transform.position, sleeveSpawnPoint.transform.rotation);
        }


    }



}
