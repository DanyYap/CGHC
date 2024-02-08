using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject smallBullet;
    public GameObject largeBullet;
    public float healthbar = 3f;
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
        if (smallBullet)
        {
            healthbar--;
        }
        if (largeBullet)
        {
            healthbar--; ;
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
