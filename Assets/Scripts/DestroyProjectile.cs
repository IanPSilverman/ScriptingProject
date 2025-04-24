using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyProj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator destroyProj()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}