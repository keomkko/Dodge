﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    public int damage = 30;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();

            if(bullet != null)
            {
                Destroy(bullet.gameObject);
            }

            Destroy(gameObject);
        }
        else if(other.CompareTag("BulletSpawner"))
        {
            BulletSpawner spawner = other.GetComponent<BulletSpawner>();

            if(spawner != null)
            {
                spawner.GetDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
