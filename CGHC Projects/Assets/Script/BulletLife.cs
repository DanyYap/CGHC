using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float lifespan = 2f;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bullet")) return;

        Destroy(gameObject);
    }
}
