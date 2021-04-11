using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Randomly instantiate enimies and collectable with fixed distance on the Z axis 
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] collectables;
    public SpawnLocationManager[] spawnLocations;

    public HashSet<int> avaliableLocation;

    public float zPosition = 25.0f; // where enemies and collectable should start along z axies 
    public float xRange = 20.0f; // a random range for enemies and collectable to be generated at 

    public float collectableSpawnTime = 3.0f;  
    public float enemiesSpawnTime = 1.0f;
    private float startDelay = 1.0f; // the delay before starting an invokerepoeating that generate enemies and collectable 


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onGameStateChange += onGameStateChange;
        /*
        InvokeRepeating("SpawnEnemies", startDelay, enemiesSpawnTime);
        InvokeRepeating("SpawnCollectable", startDelay
            +5, collectableSpawnTime);
        */
    }

    private void OnDestroy()
    {
        GameManager.Instance.onGameStateChange -= onGameStateChange;
    }

    private void onGameStateChange(GameManager.GameState from, GameManager.GameState to)
    {
        if(from == GameManager.GameState.PreGame && to == GameManager.GameState.Playing)
        {
            StartSpawn();
        }
        if(from == GameManager.GameState.Playing && to == GameManager.GameState.GameOver)
        {
            StopSpawn();
        }
    }

    private void StopSpawn()
    {
        CancelInvoke("SpawnEnemies");
        CancelInvoke("SpawnCollectable");

    }

    void StartSpawn()
    {
        InvokeRepeating("SpawnEnemies", startDelay, enemiesSpawnTime);
        InvokeRepeating("SpawnCollectable", startDelay
            + 5, collectableSpawnTime);
    }

    void SpawnEnemies()
    {
        if(enemies.Length == 0)
        {
            return; // enmies array is empty
        }
         int randomIndex = Random.Range(0, enemies.Length);
         
        InstantiateItem(enemies[randomIndex]);
    }
    void SpawnCollectable()
    {
        if (collectables.Length == 0)
        {
            return; // enmies array is empty
        }

        int randomIndex = Random.Range(0, collectables.Length);
        
        InstantiateItem(collectables[randomIndex]);
        
    }

    void InstantiateItem(GameObject item)
    {
        //check if there is a location avaliable 
        if (!isLocationAvaliable())
        {
            Debug.Log("No spawn location is avaliable");
            return;
        }
        

        Instantiate(item, new Vector3(getSpawnLocation(), item.transform.position.y, zPosition), item.transform.rotation);

    }
    bool isLocationAvaliable()
    {
        List<SpawnLocationManager> temp = new List<SpawnLocationManager>();
        foreach (SpawnLocationManager location in spawnLocations)
        {
            if (!location.isOccupied)
            {
                temp.Add(location);
            }
        }
        if(temp.Count == 0)
        {
            return false;
        }
        
        return true;
    }
    float getSpawnLocation()
    {

        List<SpawnLocationManager> temp = new List<SpawnLocationManager>();
        foreach (SpawnLocationManager location in spawnLocations)
        {
            if (!location.isOccupied)
            {
                temp.Add(location);
            }
        }
        int randomIndex = Random.Range(0, temp.Count);
        float xPosition = temp[randomIndex].gameObject.transform.position.x;

        return xPosition;
    }

}



