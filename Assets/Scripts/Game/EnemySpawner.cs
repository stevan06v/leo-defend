using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    void Awake(){instance=this;}

    //Enemy prefabs
    public List<GameObject> prefabs;
    //Enemy spawn root points
    public List<Transform> spawnPoints;
    //Enemy spawn interval
    public float spawnInterval=2f;

    public void StartSpawning()
    {
        //Call the spawn coroutine
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        //Call the spawn method
        SpawnEnemy();
        //Wait spawn interval
        yield return new WaitForSeconds(spawnInterval);
        //Recall the same coroutine
        StartCoroutine(SpawnDelay());
    }

    void SpawnEnemy()
    {
        // Select a prefab using weighted randomness
        int selectedPrefabID = GetWeightedRandomPrefabID();
        
        //Randomize the spawn point 
        int randomSpawnPointID = Random.Range(0,spawnPoints.Count);

        //Instantiate the enemy prefab
        GameObject spawnedEnemy = Instantiate(prefabs[selectedPrefabID], spawnPoints[randomSpawnPointID]);        
    }

    int GetWeightedRandomPrefabID()
    {
        // Define weights for each prefab. The last prefab gets a smaller weight.
        List<int> weights = new List<int>();
        for (int i = 0; i < prefabs.Count - 1; i++)
        {
            weights.Add(10); // Assign a higher weight to other prefabs
        }
        weights.Add(2); // Assign a smaller weight to the last prefab

        // Calculate the total weight
        int totalWeight = 0;
        foreach (int weight in weights)
        {
            totalWeight += weight;
        }

        // Generate a random number within the range of total weights
        int randomValue = Random.Range(0, totalWeight);

        // Determine which prefab corresponds to the random value
        int cumulativeWeight = 0;
        for (int i = 0; i < weights.Count; i++)
        {
            cumulativeWeight += weights[i];
            if (randomValue < cumulativeWeight)
            {
                return i;
            }
        }

        return 0; // Fallback (should not reach here)
    }
}
