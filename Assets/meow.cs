using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meow : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 vel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vel;
        vel.x += 0.0001f;
        transform.localScale += new Vector3(vel.x, vel.x, vel.x);
    }
}
