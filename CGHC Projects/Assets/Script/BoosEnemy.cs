using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BoosEnemy : MonoBehaviour
{
    public GameObject smallBullet;
    public GameObject largeBullet;
    public float healthbar = 15f;
    public float enemyCount = 1f;
    void Update()
    {
        life();
        if (enemyCount <= 0)
        {
            SceneManager.LoadScene("WinMenu");
        }
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
            enemyCount--;
            gameObject.SetActive(false);
        }
    }
}
