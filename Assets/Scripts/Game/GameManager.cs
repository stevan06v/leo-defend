using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singletton Pattern
    public static GameManager instance; 
    public Spawner spawner;
    public HealthManager healthManager;
    public CurrencyManager currencyManager;

    public EnemySpawner enemySpawner;

    void Awake(){
        instance = this;
    }

    void Start(){
        GetComponent<HealthManager>().Init();
        GetComponent<CurrencyManager>().Init();

        StartCoroutine(WaveStartDelay());
    }

    IEnumerator WaveStartDelay(){
        yield return new WaitForSeconds(4f);
        GetComponent<EnemySpawner>().StartSpawning();
    }
}
