using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundScript : MonoBehaviour
{
    [Header("Sound Sources")]
    public AudioClip jumpClip;
    public List<AudioClip> randomContainerHurt;
    public AudioClip deathClip;
    public AudioClip collectClip;
    public AudioClip projectileHitClip;

    [Header("Sound Settings")]
    public float jumpVolume = 0.5f;
    public float hurtVolume = 0.5f;
    public float collectVolume = 0.5f;
    public float projHitVolume = 0.5f;

    private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.loop = false;
        _source.playOnAwake = false;
    }

    public void playerJumpSound()
    {
        _source.clip = jumpClip;
        _source.volume = jumpVolume;
        _source.Play();
    }

    public void PlayerRandomHurtSound()
    {
        int index = Random.Range(0, randomContainerHurt.Count);
        _source.clip = randomContainerHurt[index];
        _source.volume = hurtVolume;
        _source.Play();
    }

    public void PlayerCollectSound()
    {
        _source.clip = collectClip;
        _source.volume = collectVolume;
        _source.Play();
    }

    public void PlayerProjectileHitSound()
    {
        _source.clip = projectileHitClip;
        _source.volume = projHitVolume;
        _source.Play();
    }
}
