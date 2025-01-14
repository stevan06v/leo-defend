using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    //singleton baby
    void Awake(){instance =this;}
    public List <GameObject> prefabs;
    public List <Transform> spawnPoints;

    public float spawnInterval=2f;


    // will trigger spawning can be used before spawining enemies for dialougs
    public void StartSpawning(){
        StartCoroutine(SpawnDelay());
    }

    // Call Spawn Methode & Wait Intervall & Recall -> create spawn loop 
    IEnumerator SpawnDelay()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnDelay());

    }

    public void SpawnEnemy(){
        int randomPrefabID = Random.Range(0, prefabs.Count);
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count);
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID]);

        Debug.Log("Enemy spawned successfully: " + randomSpawnPointID);
    }


}
