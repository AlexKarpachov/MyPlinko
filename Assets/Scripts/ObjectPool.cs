using System.Collections.Generic;
using UnityEngine;

// the code is implementing an object pooling system for spawning and managing game objects
public class ObjectPool : MonoBehaviour
{
    // The Pool class is a simple data container that holds two properties
    [System.Serializable]
    public class Pool
    {
        public GameObject ballPrefab;
        public int amount;
    }

    public List<Pool> pools = new List<Pool>();

    float[] bouncinessValues = new float[] { 0.4f, 0.5f, 0.6f };
    float[] frictionValues = new float[] { 0.1f, 0.3f, 0.5f, 0.7f, 1 };

    Queue<GameObject> objectPool = new Queue<GameObject>();

    private void Start()
    {
        foreach (Pool pool in pools)
        {
            for (int i = 0; i < pool.amount; i++)
            {
                GameObject obj = Instantiate(pool.ballPrefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }
    }

    public void SpawnObject(Vector2 spawnPos)
    {
        GameObject objectToSpawn = objectPool.Dequeue();
        Rigidbody2D rb = objectToSpawn.GetComponent<Rigidbody2D>();
        PhysicsMaterial2D physicsMaterial2D = rb.sharedMaterial;
        float bounciness = bouncinessValues[Random.Range(0, bouncinessValues.Length)];
        float friction = frictionValues[Random.Range(0, frictionValues.Length)];

        physicsMaterial2D.bounciness = bounciness;
        physicsMaterial2D.friction = friction;

        objectToSpawn.transform.SetParent(null);
        objectToSpawn.transform.position = spawnPos;
        objectToSpawn.SetActive(true);
    }

    public void ReturnToQueue(GameObject obj)
    {
        objectPool.Enqueue(obj);
    }
}
