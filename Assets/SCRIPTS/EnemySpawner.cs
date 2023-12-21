using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;

    public float spawnInterval = 2f;
    public float minY1 = -1f;
    public float maxY1 = 0f;
    public float minY2 = 0f;
    public float maxY2 = 5f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomY;
        GameObject selectedPrefab;

        if (Random.Range(0, 2) == 0)
        {
            randomY = Random.Range(minY1, maxY1);
            selectedPrefab = enemyPrefab1;
        }
        else
        {
            randomY = Random.Range(minY2, maxY2);
            selectedPrefab = enemyPrefab2;
        }

        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        Quaternion fixedRotation = Quaternion.Euler(0f, 180f, 0f);
        Instantiate(selectedPrefab, spawnPosition, fixedRotation);
    }
}
