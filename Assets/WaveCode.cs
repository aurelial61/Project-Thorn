using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveCode : MonoBehaviour
{
    public UnityEvent EndWave;
    public GameObject enemy1;
    public GameObject enemy2;
    public Vector3[] locations;
    public int number;
    public List<GameObject> enemiesList = new List<GameObject>();
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Picker(Vector3 spawnpoint, int mode)
    {
        number = Random.Range(1, 3);
        GameObject spawnedEnemy;
        if ((number == 1 && mode != 2) || (mode == 1))
        {
            spawnedEnemy = Instantiate(enemy1, spawnpoint, Quaternion.identity);
            
        }
        else
        {
            spawnedEnemy = Instantiate(enemy2, spawnpoint, Quaternion.identity);
        }
        enemiesList.Add(spawnedEnemy);
        Health spawnedEnemyhealth = spawnedEnemy.GetComponent<Health>();
        spawnedEnemyhealth.onDeath.AddListener(() =>
        {
            onEnemyDeath(spawnedEnemy);
        });
    }
    private void onEnemyDeath(GameObject enemy)
    {
        enemiesList.Remove(enemy);
        if (enemiesList.Count == 0)
        {
            //spawnwave();  old piece of code
            //add an event here to signal that player killed all enemies in teh wave
            EndWave.Invoke();
        }
    }
    public void spawnwave(Vector3[] enemyLocations, int[] enemyMode)
    {
        // enemyMode 0 = random. enemyMode 1 = all spear enemies. enemyMode 2 = all bombfish
        for (int i = 0; i < enemyLocations.Length; i++)
        {
            Picker(enemyLocations[i], enemyMode[i]);
        }
    }
    
    public void spawnwave(int enemyMode)
    {
        int[] mode = new int[locations.Length];
        for (int i = 0; i < locations.Length; i++)
        {
            mode[i] = enemyMode;
        }
        spawnwave(locations, mode);
    }
}
