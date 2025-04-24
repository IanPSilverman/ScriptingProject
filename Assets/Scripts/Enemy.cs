using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool destroyOnCollision = false;
    public int damageToPlayer = 10;

    public Transform[] waypoints;
    public float speed = 3f;

    private int _currentWaypointIndex = 0;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            dealDamage(collision);
        }
    }

    private void dealDamage(Collider2D player)
    {
        PlayerHealth playerHealth = player.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damageToPlayer);
        }

        if (destroyOnCollision)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (waypoints.Length > 0)
        {
            Vector2 targetPosition = waypoints[_currentWaypointIndex].position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
                if(_spriteRenderer.flipX)
                {
                    _spriteRenderer.flipX = false;
                }
                else
                {
                    _spriteRenderer.flipX = true;
                }
            }
        }
    }
}