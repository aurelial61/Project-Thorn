using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomfish : MonoBehaviour
{
    public Transform player; // make sure to assign the player
    public float speed;
    public float rangedetect; //change range values to liking
    public float rangeboom;
    public Transform orbit;
    public GameObject explosion;
    public float rotationspeed = 90f; //degrees per second (speed) of rotation
    public Vector3 rotationaxis = Vector3.up; //the axis to rotate around
    private float damageTimer;
    public Material damageMat;
    public Material defaultMat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
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
            explode();
        }
        if (orbit != null) //basically means that if orbit exist, go and do the code below (at least i think)
        {
            //rotate around the orbit
            transform.RotateAround(orbit.position, rotationaxis, rotationspeed * Time.deltaTime);
        }

        if(damageTimer > 0)
        {

            gameObject.GetComponent<MeshRenderer>().material = damageMat;
            damageTimer -= Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = defaultMat;
        }

    } 

    public void explode()
    {
        if (Vector3.Distance(transform.position, player.position) < rangeboom)
        {
            player.gameObject.GetComponent<Health>().currentHP -= 4;
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);//here it kills itselfs
                            //add a damagin line here if you want player to take damage 
                            //also if you want add an animation somwhere here of fish going boom
    }

    public void damage()
    {
        
        damageTimer = 0.1f;
    }
}
