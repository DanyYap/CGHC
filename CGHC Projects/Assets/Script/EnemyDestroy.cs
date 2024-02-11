using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject smallBullet;
    public GameObject largeBullet;
    public float healthbar = 4f;

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
            LevelManager.Instance.CheckEnemies();
            Destroy(gameObject);
        }
    }
}
