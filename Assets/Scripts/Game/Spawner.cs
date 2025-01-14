using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Commands;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<GameObject> towersPrefabs;
    public Transform spawnTowerRoot;
   
    public List<Image> towersUI;

    int spawnID=-1;
    public Tilemap spawnTilemap;
    private Vector3Int tilePos;
    
    void Update()
    {
        if(CanSpawn())
            DetectSpawnPoint();
    }

    bool CanSpawn()
    {
        if (spawnID == -1)
            return false;
        else
            return true;
    }

    void DetectSpawnPoint()
    {
        //Detect when mouse is clicked (first touch clicked)
        if(Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
                //check if we can spawn in that cell (collider)
                if(spawnTilemap.GetColliderType(cellPosDefault)== Tile.ColliderType.Sprite)
                {
                    int towerCost = TowerCost();
                    if(GameManager.instance.currencyManager.EnoughCurrency(towerCost)){
                        GameManager.instance.currencyManager.Use(towerCost);
                        SpawnTower(cellPosCentered, cellPosDefault);
                        spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                    }else{
                        Debug.Log("Not Enough Currency!");
                    }
                }        
            }                                  
    }

    int TowerCost(){
        switch(spawnID){
            case 1: return towersPrefabs[1].GetComponent<Gainer>().cost;
            //case 0: return towersPrefabs[1].GetComponent<Gainer>().cost;
            //case 0: return towersPrefabs[1].GetComponent<Gainer>().cost;
            default: return 0;
        }
    }
    
    void SpawnTower(Vector3 position, Vector3Int cellPosition)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;

        Debug.Log("TOWER SPAWNED...");
      
        DeselectTowers();
    }

    public void SelectTower(int id)
    {
        DeselectTowers();
        spawnID = id;
        towersUI[spawnID].color = Color.white;        
    }

    public void DeselectTowers()
    {
        spawnID = -1;
        foreach(var t in towersUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }    
}