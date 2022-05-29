using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float spawnTime = 3f; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemySpawner());
    }

    IEnumerator enemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        int randomValue = Random.Range(0, enemy.Length);
        float randomPos = Random.Range(-1.7f, 1.7f);

        Instantiate(enemy[randomValue], new Vector2(randomPos, transform.position.y), Quaternion.identity);
    }
}
