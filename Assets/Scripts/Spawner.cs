using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int objectCount = 20;
    public float spawnRadius = 10;
    void Start()
    {
        for (int i = 0; i < objectCount; ++i)
        {
            GameObject instance = GameObject.Instantiate(prefab);
            bool success = false;
            while (!success)
            {
                float x = Random.Range(-spawnRadius, spawnRadius);
                float y = Random.Range(-spawnRadius, spawnRadius);
                float z = Random.Range(-spawnRadius, spawnRadius);
                if ((new Vector2(x, y)).magnitude <= spawnRadius)
                {
                    instance.transform.position = instance.transform.position + new Vector3(x, y, z);
                    success = true;
                }
            }
            instance.transform.SetParent(transform);
        }
    }
}
