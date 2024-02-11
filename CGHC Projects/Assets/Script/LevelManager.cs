using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public Transform enemyParent;
    public GameObject keyPrefab;
    public Transform keySpawnPosition;
    public bool hasKey;
    private bool isKeySpawned;

    private void Awake()
    {
        if (Instance != null) Destroy(this.gameObject);
        else Instance = this;
    }


    public void CheckEnemies()
    {
        if (isKeySpawned) return;


        StopAllCoroutines();
        StartCoroutine(CheckEnemiesAfterTime());
    }

    IEnumerator CheckEnemiesAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        if (enemyParent.childCount == 0)
        {
            SpawnKey();
        }
    }

    private void SpawnKey()
    {
        Instantiate(keyPrefab, keySpawnPosition.position, Quaternion.identity);
        isKeySpawned = true;
    }
}
