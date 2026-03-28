using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomfish : MonoBehaviour
{
    public GameObject me;
    public Transform player;
    public float speed;
    public float rangedetect; //change range values to liking
    public float rangeboom;
    public Transform orbit; 
    public float rotationspeed = 90f; //degrees per second (speed) of rotation
    public Vector3 rotationaxis = Vector3.up; //the axis to rotate around
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < rangedetect) //it takes distance from player to fish and constantly checks if it is lower than range
        { //therefore when it is lower than range, means it is in range
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.LookAt(player); //then it follows the player around with the line above
        } // and rotates to look at player with line above
        else
        {
            
        }
        if (Vector3.Distance(transform.position, player.position) < rangeboom) 
        {
            me.GetComponent<Health>().TakeDamage(1000000);
            DestroyImmediate(gameObject, true);
        }
        if (orbit != null) //basically means that if orbit exist, go and do the code below (at least i think)
        {
            //rotate around the orbit
            transform.RotateAround(orbit.position, rotationaxis, rotationspeed * Time.deltaTime);
        }
    } 
}
