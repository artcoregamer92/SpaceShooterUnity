using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public float spawnInterval = 3f;
    public float spawnRangeX = 8f;
    public float spawnRangeY = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnCollectible", 1f, spawnInterval);
    }

    void SpawnCollectible()
    {
        float x = Random.Range(-spawnRangeX, spawnRangeX);
        float y = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 spawnPosition = new Vector2(x, y);
        Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
    }
}

