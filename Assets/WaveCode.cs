using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCode : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public Vector3 spawn1;
    public Vector3 spawn2;
    public Vector3 spawn3;
    public Vector3 spawn4;
    public Vector3 spawn5;
    public Vector3 spawn6;
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        picker(spawn1);
        picker(spawn2);
        picker(spawn3);
        picker(spawn4);
        picker(spawn5);
        picker(spawn6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void picker(Vector3 spawnpoint)
    {
        number = Random.Range(1, 3);
        if (number == 1)
        {
            Instantiate(enemy1, spawnpoint, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy2, spawnpoint, Quaternion.identity);
        }
    }
}
