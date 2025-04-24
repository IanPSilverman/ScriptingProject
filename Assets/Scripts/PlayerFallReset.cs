using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerFallReset : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerRespawn();
        }
    }
    public void PlayerRespawn()
    {
        var goPlayer = GameObject.FindGameObjectWithTag("Player");
        var _player = goPlayer.GetComponent<Transform>();

        _player.transform.position = respawnPoint.position;
    }
}
