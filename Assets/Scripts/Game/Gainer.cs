using System.Collections;
using UnityEngine;

public class Gainer: MonoBehaviour{
    public int cost;

    public int health;
    public int incomeValue; 
    public float intervall;

    public GameObject obj_coin;

    void Start(){
        StartCoroutine(Intervall());
    }

    IEnumerator Intervall()
    {
        yield return new WaitForSeconds(intervall);
        IncreseIncome();
        StartCoroutine(Intervall());
    }

    public void IncreseIncome(){
        GameManager.instance.currencyManager.Gain(incomeValue);
        Debug.Log("INCOME INCREASED...");
    }

    // trigger animation above head --> TODO
    IEnumerator CoinIndication(){
        obj_coin.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        obj_coin.SetActive(false);

    }
    public void LoseHealth(){
        health--;

        if(health<=0){
            Die();
        }
    }

    public void Die(){
        Debug.Log("Game Object is destroyed");
        Destroy(gameObject);
    }
}
