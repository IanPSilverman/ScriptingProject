using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootInterval = 2f;
    public float projectileSpeed = 5f;

    [Header("Sound Sources")]
    public AudioClip shootClip;

    [Header("Sound Settings")]
    public float shootVolume = 0.8f;

    private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.loop = false;
        _source.playOnAwake = false;

        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            _source.clip = shootClip;
            _source.volume = shootVolume;
            _source.Play();

            Vector3 direction = (player.transform.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position),Time.deltaTime);
        }
    }
}