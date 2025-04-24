using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool destroyOnCollision = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (destroyOnCollision)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
