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
    public GameObject explosion;
    public float rotationspeed = 90f; //degrees per second (speed) of rotation
    public Vector3 rotationaxis = Vector3.up; //the axis to rotate around
    private float damageTimer;
    public GameManagerScript gm;
    public Material damageMat;
    public Material defaultMat;
    public GameObject expDamage;
    public float turnSpeed = 20f;
    public Health health;
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
            
            Vector3 relativePos = player.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;

            //then it follows the player around with the line above
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
        /*
        if (Vector3.Distance(transform.position, player.position) < rangeboom)
        {
            player.gameObject.GetComponent<Health>().currentHP -= 4;
        }
        */
        Instantiate(expDamage, transform.position, Quaternion.identity);
        Instantiate(explosion, transform.position, Quaternion.identity);
        health.TakeDamage(10);//here it kills itselfs
        
                            //add a damagin line here if you want player to take damage 
                            //also if you want add an animation somwhere here of fish going boom
    }

    public void damage()
    {
        
        damageTimer = 0.1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        explode();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
