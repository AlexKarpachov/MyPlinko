using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    [SerializeField] Vector2 rightSpawnPos;
    [SerializeField] Vector2 leftSpawnPos;

    public void SpawnBall()
    {
        Vector2[] spawnPositions = new Vector2[] { rightSpawnPos, leftSpawnPos };
        Vector2 spawnPos = spawnPositions[Random.Range(0, spawnPositions.Length)];

        pool.SpawnObject(spawnPos);
    }

}
