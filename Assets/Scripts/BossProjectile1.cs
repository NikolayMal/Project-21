﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossProjectile1 : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;

    private Transform player;

    private Vector2 target;
    public LayerMask whatIsSolid;

    public int damage;
    public GameObject destroyEffect;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

        Invoke("DestroyProjectile", lifetime);
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); // Position to move projectile too
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid); // Creates raycast for the projectile 

        if (hitInfo.collider != null) 
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Player Must Take Damage!");
                hitInfo.collider.GetComponent<Movement>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        /*
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider == player.transform)
            {
                DestroyProjectile();
            }
        } */
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}