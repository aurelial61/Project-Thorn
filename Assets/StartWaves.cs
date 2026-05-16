using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaves : MonoBehaviour
{
    public GameObject gm;
    // Start is called before the first frame update
    void Start()
    {
        gm.GetComponent<WaveCode>().enabled = false;
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
        if (other.CompareTag("Player"))
        {
            gm.GetComponent<WaveCode>().enabled = true;
        }
    }
}
