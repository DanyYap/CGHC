using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject smallBullet;
    public GameObject largeBullet;
    public float healthbar = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            healthbar--;
        }
        if (collision.gameObject.tag == "big bullet")
        {
            healthbar = healthbar - 3f;
        }
        
    }

    private void life()
    {
        if (healthbar <= 0)
        {
            Destroy(gameObject);
        }
    }
}
