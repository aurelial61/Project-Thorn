using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaves : MonoBehaviour
{
    public GameObject gm;
    public WaveCode spawn;
    public int option;
    bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        gm.GetComponent<WaveCode>().enabled = false;
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
          //  gm.GetComponent<WaveCode>().enabled = true;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ! spawned)
        {
            spawn.spawnwave(option);
            spawned = true;
        }
    }
}
